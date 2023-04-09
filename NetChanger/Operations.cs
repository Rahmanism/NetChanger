using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace NetChanger
{
    class Operations
    {
        // the file that contains profiles data.
        public const string PROFILES = "profiles.json";
        public const string STARTUP = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

        #region Fields
        NotifyIcon notifyIcon;
        Icon normalIcon;
        #endregion

        #region Public Fields
        public NetProperties Net;
        public ProxySettings Proxy;
        public List<Profile> Profiles;
        public List<string> ResultsLog = new();
        #endregion

        public Operations()
        {
            Initialize();
        }

        #region Context Menu Event Handlers
        void QuitToolStripMenuItemClick(object sender, EventArgs e)
        {
            notifyIcon.Dispose();
            Application.Exit();
        }

        /// <summary>
        /// Gets if this app is added to startup via Windows Registry.
        /// </summary>
        /// <returns>True if it's in the startup.</returns>
        static bool IsInStartup()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(STARTUP, true);
            var exeName = Path.GetFileNameWithoutExtension(Environment.ProcessPath);
            var value = key.GetValue(exeName);
            return value != null;
        }

        /// <summary>
        /// Puts the app in startup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void StartupToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem m = (ToolStripMenuItem)sender;
            m.Checked = !m.Checked;
            bool set = m.Checked;

            var exeName = Path.GetFileNameWithoutExtension(Environment.ProcessPath);
            var key = Registry.CurrentUser.OpenSubKey(STARTUP, true);

            // If menu checked puts the shortcut of app to startup folder,
            // else deletes the shortcut
            if (set) {
                key.SetValue(exeName, "\"" + Environment.ProcessPath + "\"");
            }
            else {
                try {
                    key.DeleteValue(exeName);
                }
                catch { }
            }
        }

        /// <summary>
        /// When user clicks (selects) a profile, changes happens here.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ProfileToolStripMenuItemClick(object sender, EventArgs e)
        {
            UpdateRadioMenu((ToolStripMenuItem)sender);

            // Change the active profile in app settings.
            Properties.Settings.Default.ActiveProfile = ((ToolStripMenuItem)sender).Text;
            Properties.Settings.Default.Save();

            // Change the current (active) profile to the selected for runtime.
            Net.Profile = FindProfile();

            Log(Cmd.Execute(Net.Do));
        }

        /// <summary>
        /// Language menu items event listener.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void LanguageSelect(object sender, EventArgs e)
        {
            var item = (ToolStripMenuItem)sender;
            UpdateRadioMenu(item);

            Properties.Settings.Default.Language = item.Tag.ToString();
            Properties.Settings.Default.Save();

            Program.SwitchLanguage();
        }

        /// <summary>
        /// Turn the proxy on menu item event listener
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TurnProxyOn(object sender, EventArgs e)
        {
            var onItem = (ToolStripMenuItem)sender;
            onItem.Checked = true;

            var offItem = (ToolStripMenuItem)notifyIcon.ContextMenuStrip.Items.Find(
                "proxyOffToolStripMenuItem", true)[0];
            offItem.Checked = false;

            Log(new string[] { Proxy.TurnOn() });
        }

        /// <summary>
        /// Turn the proxy off menu item event listener
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TurnProxyOff(object sender, EventArgs e)
        {
            var offItem = (ToolStripMenuItem)sender;
            offItem.Checked = true;

            var onItem = (ToolStripMenuItem)notifyIcon.ContextMenuStrip.Items.Find(
                "proxyOnToolStripMenuItem", true)[0];
            onItem.Checked = false;

            Log(new string[] { Proxy.TurnOff() });
        }
        #endregion

        #region Initializers
        /// <summary>
        /// Runs initialization methods
        /// </summary>
        private void Initialize()
        {
            // make a new instance of net properties.
            Net = new NetProperties();
            Proxy = new ProxySettings();
            // This should be run first
            LoadSettings();
            // LoadIcons must be run before ShowNotificationIcon
            LoadIcons();
            // ShowNotificationIcon() must run after the LoadIcons() method.
            ShowNotificationIcon();
            CreateContextMenu();
        }

        /// <summary>
        /// Load default icons from PNG files
        /// </summary>
        private void LoadIcons()
        {
            normalIcon = Properties.Resources.MainIcon;
        }

        /// <summary>
        /// Create notification tray icon
        /// </summary>
        private void ShowNotificationIcon()
        {
            // Show notification tray icon
            notifyIcon = new NotifyIcon() {
                Icon = normalIcon,
                Text = Resources.Resources.slogan,
                Visible = true
            };
        }

        /// <summary>
        /// Create a context menu and assingn it to notfication tray icon
        /// </summary>
        private void CreateContextMenu()
        {
            // Create context menu and assign it to notification icon
            var progNameToolStripMenuItem = new ToolStripMenuItem(
                $"{Resources.Resources.netchagner}" +
                $" - v{Assembly.GetExecutingAssembly().GetName().Version.ToString()}");

            // Profiles menu
            var profilesToolStripMenuItem = new ToolStripMenuItem {
                Text = Resources.Resources.profiles,
                Name = "profilesToolStripMenuItem"
            };
            var profileCreateToolStripMenuItem = new ToolStripMenuItem {
                Text = Resources.Resources.create_new_profile,
                Name = "createProfileToolStripMenuItem"
            };
            var editCurrentProfileToolStripMenuItem = new ToolStripMenuItem {
                Text = Resources.Resources.edit_current_profile,
                Name = "editCurrentProfileToolStripMenuItem"
            };
            var profileManageToolStripMenuItem = new ToolStripMenuItem {
                Text = Resources.Resources.manage_profiles,
                Name = "profilesManageToolStripMenuItem"
            };
            profilesToolStripMenuItem.DropDownItems.Add(profileCreateToolStripMenuItem);
            profilesToolStripMenuItem.DropDownItems.Add(editCurrentProfileToolStripMenuItem);
            profilesToolStripMenuItem.DropDownItems.Add(profileManageToolStripMenuItem);
            profilesToolStripMenuItem.DropDownItems.Add("-");

            // adding profiles to the sub menu again.
            foreach (var item in Profiles) {
                var ToolStripMenuItem = new ToolStripMenuItem {
                    Text = item.Name,
                    Name = item.Name + "ToolStripMenuItem",
                    //RadioCheck = true,
                    Checked = Net.Profile == null || Net.Profile.Name == null ||
                        Net.Profile.Name.Equals(item.Name)
                };
                ToolStripMenuItem.Click += ProfileToolStripMenuItemClick;
                profilesToolStripMenuItem.DropDownItems.Add(ToolStripMenuItem);
            }

            // Language menu
            var languageToolStripMenuItem = new ToolStripMenuItem {
                Text = Resources.Resources.language,
                Name = "languageToolStripMenuItem"
            };

            var englishLanguageToolStripMenuItem = new ToolStripMenuItem {
                Text = Resources.Resources.en,
                Name = "englishLanguageToolStripMenuItem",
                Tag = "en-US",
                //RadioCheck = true,
                Checked = Thread.CurrentThread.CurrentCulture.Name == "en-US",
            };
            englishLanguageToolStripMenuItem.Click += LanguageSelect;
            var persianLanguageToolStripMenuItem = new ToolStripMenuItem {
                Text = Resources.Resources.fa,
                Name = "persianLanguageToolStripMenuItem",
                Tag = "fa-IR",
                //RadioCheck = true,
                Checked = Thread.CurrentThread.CurrentCulture.Name == "fa-IR"
            };
            persianLanguageToolStripMenuItem.Click += LanguageSelect;

            languageToolStripMenuItem.DropDownItems.Add(englishLanguageToolStripMenuItem);
            languageToolStripMenuItem.DropDownItems.Add(persianLanguageToolStripMenuItem);

            // Proxy menu
            var proxyToolStripMenuItem = new ToolStripMenuItem {
                Text = Resources.Resources.proxy,
                Name = "proxyToolStripMenuItem"
            };
            var proxyOnToolStripMenuItem = new ToolStripMenuItem {
                Text = Resources.Resources.on,
                Name = "proxyOnToolStripMenuItem",
                Checked = Proxy.IsOn()
            };
            var proxyOffToolStripMenuItem = new ToolStripMenuItem {
                Text = Resources.Resources.off,
                Name = "proxyOffToolStripMenuItem",
                Checked = !Proxy.IsOn()
            };
            proxyToolStripMenuItem.DropDownItems.Add(proxyOnToolStripMenuItem);
            proxyToolStripMenuItem.DropDownItems.Add(proxyOffToolStripMenuItem);

            // Other menus
            var showLogToolStripMenuItem = new ToolStripMenuItem {
                Text = Resources.Resources.show_log,
                Name = "showLogToolStripMenuItem"
            };

            var startupToolStripMenuItem = new ToolStripMenuItem {
                Text = Resources.Resources.put_in_startup,
                Name = "startupToolStripMenuItem"
            };

            var aboutToolStripMenuItem = new ToolStripMenuItem {
                Text = Resources.Resources.about,
                Name = "aboutToolStripMenuItem"
            };
            var quitToolStripMenuItem = new ToolStripMenuItem(Resources.Resources.quit);

            // Context menu for notify icon (aka main menu)
            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add(progNameToolStripMenuItem);
            contextMenu.Items.Add("-");
            contextMenu.Items.Add(profilesToolStripMenuItem);
            contextMenu.Items.Add(languageToolStripMenuItem);
            contextMenu.Items.Add(proxyToolStripMenuItem);
            contextMenu.Items.Add("-");
            contextMenu.Items.Add(showLogToolStripMenuItem);
            contextMenu.Items.Add(startupToolStripMenuItem);
            contextMenu.Items.Add(aboutToolStripMenuItem);
            contextMenu.Items.Add("-");
            contextMenu.Items.Add(quitToolStripMenuItem);
            notifyIcon.ContextMenuStrip = contextMenu;

            // If there is a shortcut of app in startup folder put check mark for the menu item
            var exeName = Path.GetFileNameWithoutExtension(Environment.ProcessPath);
            // TODO: maybe should check with registry, if PutInStartupFolder made that way.
            startupToolStripMenuItem.Checked = IsInStartup();

            #region Context Menu Events Wire Up
            // Wire up menu items event handlers
            quitToolStripMenuItem.Click += QuitToolStripMenuItemClick;
            startupToolStripMenuItem.Click += StartupToolStripMenuItemClick;

            // Wire up create profiles menu item to show profile form (settings actually)
            profileCreateToolStripMenuItem.Click += (s, e) => {
                var createProfile = new SettingsForm(SettingsForm.NEW);
                createProfile.Show();
            };

            // Wire up edit current profile menu item to show profile form (settings actually) for the active profile
            editCurrentProfileToolStripMenuItem.Click += (s, e) => {
                var editCurrentProfile = new SettingsForm(SettingsForm.EDIT_CURRENT);
                editCurrentProfile.Show();
            };

            // Wire up manage profiles menu item to show the form
            profileManageToolStripMenuItem.Click += (s, e) => {
                var manageProfiles = new ManageProfiles();
                manageProfiles.Show();
            };

            // Wire up show log menu item to show the form
            showLogToolStripMenuItem.Click += (s, e) => {
                var showLog = new ShowLog();
                showLog.Show();
            };

            // Wire up about menu item to show about form
            aboutToolStripMenuItem.Click += (s, e) => {
                var about = new AboutForm();
                about.Show();
            };

            // Wire up proxy on menu item to turn on the proxy
            proxyOnToolStripMenuItem.Click += (s, e) => {
                TurnProxyOn(s, e);
            };

            // Wire up proxy off menu item to turn on the proxy
            proxyOffToolStripMenuItem.Click += (s, e) => {
                TurnProxyOff(s, e);
            };
            #endregion
        }

        /// <summary>
        /// Load configuration from file
        /// </summary>
        private void LoadSettings()
        {
            // TODO: load current system setting as a new profile names AutoProfile.

            string path = AppDomain.CurrentDomain.BaseDirectory + PROFILES;

            // If there's no file, extract the default one from resources.
            if (!File.Exists(path)) {
                File.WriteAllBytes(path, Properties.Resources.profiles);
            }

            // Load data from file.
            Profiles = MyJson.ReadData<List<Profile>>(path);

            Net.Profile = FindProfile();
            if (Net.Profile == null && Profiles.Count > 0) {
                Net.Profile = Profiles[0];

                // Change the active profile in app settings.
                Properties.Settings.Default.ActiveProfile = Net.Profile.Name;
                Properties.Settings.Default.Save();
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Changes notification icon to alert (or normal)
        /// </summary>
        /// <param name="alert">
        /// If true (default) icon changes to red (alert) icon
        /// else to normal icon
        /// </param>
        private void ChangeNotifyIcon(bool alert = true)
        {
            //notifyIcon.Icon = alert ? alertIcon : normalIcon;
        }

        /// <summary>
        /// Changes the state of radio check in all sibling menu items
        /// </summary>
        /// <param name="sender">This menu item will be checked</param>
        private static void UpdateRadioMenu(ToolStripMenuItem sender)
        {
            foreach (ToolStripMenuItem item in sender.GetCurrentParent().Items) {
                item.Checked = false;
            }
            sender.Checked = true;
        }

        /// <summary>
        /// Updates profiles sub menu.
        /// </summary>
        /// <param name="firstTime"></param>
        private void LoadProfilesMenu()
        {
            //byte? ToolStripMenuItemIndex = null;
            ToolStripMenuItem profilesToolStripMenuItem = new ToolStripMenuItem();

            // find the profiles submenu
            foreach (ToolStripMenuItem item in notifyIcon.ContextMenuStrip.Items) {
                if (item.Name == "profilesToolStripMenuItem") {
                    //ToolStripMenuItemIndex = (byte)item.Index;
                    profilesToolStripMenuItem = item;
                    break;
                }
            }

            // find and remove profiles menu items.
            List<ToolStripMenuItem> indices = new();
            foreach (ToolStripMenuItem item in profilesToolStripMenuItem.DropDownItems) {
                if (item.Checked)
                    indices.Add(item);
            }
            for (int i = indices.Count - 1; i > -1; i--) {
                profilesToolStripMenuItem.DropDownItems.Remove(indices[i]);
            }

            // adding profiles to the sub menu again.
            foreach (var item in Profiles) {
                var ToolStripMenuItem = new ToolStripMenuItem {
                    Text = item.Name,
                    Name = item.Name + "ToolStripMenuItem",
                    //Check = true,
                    Checked = Net.Profile != null && Net.Profile.Name != null ?
                        Net.Profile.Name.Equals(item.Name) : true
                };
                ToolStripMenuItem.Click += ProfileToolStripMenuItemClick;
                profilesToolStripMenuItem.DropDownItems.Add(ToolStripMenuItem);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Show the message in balloon tooltip at system tray
        /// and tell it to user with speech synthesizer
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public void Message(string message, string title = "", bool mute = false)
        {
            ShowBallonMessage(message, title);
        }

        /// <summary>
        /// Show the message in balloon tooltip at system tray
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public void ShowBallonMessage(string message, string title = "")
        {
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.BalloonTipText = message;
            notifyIcon.BalloonTipTitle = title == "" ?
                Resources.Resources.netchagner : title;

            notifyIcon.ShowBalloonTip(1000);
        }

        /// <summary>
        /// Adds the text (and time) to the resutls list. (doesn't save on hdd)
        /// </summary>
        /// <param name="str"></param>
        public void Log(string[] str)
        {
            ResultsLog.Add(DateTime.Now.ToString());
            ResultsLog.AddRange(str);
        }

        /// <summary>
        /// Updates profiles menu, and saves the profiles in RAM
        /// (after delete/edit/new from other forms) to the json file.
        /// </summary>
        public void UpdateProfilesFull()
        {
            // reload profiles submenu.
            LoadProfilesMenu();

            // Write data to Json FILE.
            string path = AppDomain.CurrentDomain.BaseDirectory + Operations.PROFILES;
            MyJson.WriteData(path, Program.operations.Profiles);
        }

        /// <summary>
        /// It will make a copy from the given profile.
        /// </summary>
        /// <param name="profileName"></param>
        public void Duplicate(string profileName)
        {
            var sourceProfile = FindProfile(profileName);
            var newProfile = new Profile(sourceProfile);
            Profiles.Add(newProfile);
        }

        /// <summary>
        /// Returns profile using ActiveProfile name from app settings
        /// or with the given name.
        /// </summary>
        /// <returns>A Profile</returns>
        public Profile FindProfile(string name = null)
        {
            var pName = (name ?? Properties.Settings.Default.ActiveProfile).ToLower();
            return Profiles.Find(
                    p => p.Name.ToLower().Equals(pName)
                ) ?? new Profile();
        }
        #endregion
    }
}
