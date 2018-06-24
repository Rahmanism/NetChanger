using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace NetChanger
{
    class Operations
    {
        // the file that contains profiles data.
        public const string PROFILES = "profiles.json";

        #region Fields
        NotifyIcon notifyIcon;
        Icon normalIcon;
        #endregion

        #region Public Fields
        public NetProperties Net;
        public List<Profile> Profiles;
        public List<string> ResultsLog = new List<string>();
        #endregion

        public Operations()
        {
            Initialize();
        }

        #region Context Menu Event Handlers
        void QuitMenuItemClick(object sender, EventArgs e)
        {
            notifyIcon.Dispose();
            Application.Exit();
        }

        /// <summary>
        /// Puts the app in startup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void StartupMenuItemClick(object sender, EventArgs e)
        {
            MenuItem m = (MenuItem)sender;
            m.Checked = !m.Checked;
            bool set = m.Checked;

            var exeName = System.IO.Path.GetFileNameWithoutExtension(
                System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName );

            // If menu checked puts the shortcut of app to startup folder,
            // else deletes the shortcut
            if ( set ) {
                Rahmanism.ir.Common.PutInStartupFolder();
            }
            else {
                try {
                    System.IO.File.Delete(
                        Environment.GetFolderPath( Environment.SpecialFolder.Startup ) + $"\\{exeName}.lnk" );
                }
                catch { }
            }
        }

        /// <summary>
        /// When user clicks (selects) a profile, changes happens here.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ProfileMenuItemClick(object sender, EventArgs e)
        {
            UpdateRadioMenu( (MenuItem)sender );

            // Change the active profile in app settings.
            Properties.Settings.Default.ActiveProfile = ( (MenuItem)sender ).Text;
            Properties.Settings.Default.Save();

            // Change the current (active) profile to the selected for runtime.
            Net.Profile = Profiles.Find(
                    p => p.Name.ToLower().Equals( Properties.Settings.Default.ActiveProfile )
                );

            Log( Cmd.Execute( Net.Do ) );
        }

        /// <summary>
        /// Language menu items event listener.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void LanguageSelect(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            UpdateRadioMenu( item );

            Properties.Settings.Default.Language = item.Tag.ToString();
            Properties.Settings.Default.Save();

            Program.SwitchLanguage();
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
            var progNameMenuItem = new MenuItem(
                $"{Resources.Resources.netchagner}" +
                $" - v{Assembly.GetExecutingAssembly().GetName().Version.ToString()}" );

            var profilesMenuItem = new MenuItem {
                Text = Resources.Resources.profiles,
                Name = "profilesMenuItem"
            };
            var profileCreateMenuItem = new MenuItem {
                Text = Resources.Resources.create_new_profile,
                Name = "createProfileMenuItem"
            };
            var editCurrentProfileMenuItem = new MenuItem {
                Text = Resources.Resources.edit_current_profile,
                Name = "editCurrentProfileMenuItem"
            };
            var profileManageMenuItem = new MenuItem {
                Text = Resources.Resources.manage_profiles,
                Name = "profilesManageMenuItem"
            };
            profilesMenuItem.MenuItems.Add( profileCreateMenuItem );
            profilesMenuItem.MenuItems.Add( editCurrentProfileMenuItem );
            profilesMenuItem.MenuItems.Add( profileManageMenuItem );
            profilesMenuItem.MenuItems.Add( "-" );

            // adding profiles to the sub menu again.
            foreach ( var item in Profiles ) {
                var menuItem = new MenuItem {
                    Text = item.Name,
                    Name = item.Name + "MenuItem",
                    RadioCheck = true,
                    Checked = Net.Profile.Name.Equals( item.Name )
                };
                menuItem.Click += ProfileMenuItemClick;
                profilesMenuItem.MenuItems.Add( menuItem );
            }

            var languageMenuItem = new MenuItem {
                Text = Resources.Resources.language,
                Name = "languageMenuItem"
            };

            var englishLanguageMenuItem = new MenuItem {
                Text = Resources.Resources.en,
                Name = "englishLanguageMenuItem",
                Tag = "en-US",
                RadioCheck = true,
                Checked = Thread.CurrentThread.CurrentCulture.Name == "en-US",
            };
            englishLanguageMenuItem.Click += LanguageSelect;
            var persianLanguageMenuItem = new MenuItem {
                Text = Resources.Resources.fa,
                Name = "persianLanguageMenuItem",
                Tag = "fa-IR",
                RadioCheck = true,
                Checked = Thread.CurrentThread.CurrentCulture.Name == "fa-IR"
            };
            persianLanguageMenuItem.Click += LanguageSelect;

            languageMenuItem.MenuItems.Add( englishLanguageMenuItem );
            languageMenuItem.MenuItems.Add( persianLanguageMenuItem );

            var showLogMenuItem = new MenuItem {
                Text = Resources.Resources.show_log,
                Name = "showLogMenuItem"
            };

            var startupMenuItem = new MenuItem {
                Text = Resources.Resources.put_in_startup,
                Name = "startupMenuItem"
            };

            var aboutMenuItem = new MenuItem {
                Text = Resources.Resources.about,
                Name = "aboutMenuItem"
            };
            var quitMenuItem = new MenuItem( Resources.Resources.quit );
            var contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add( progNameMenuItem );
            contextMenu.MenuItems.Add( "-" );
            contextMenu.MenuItems.Add( profilesMenuItem );
            contextMenu.MenuItems.Add( languageMenuItem );
            contextMenu.MenuItems.Add( "-" );
            contextMenu.MenuItems.Add( showLogMenuItem );
            contextMenu.MenuItems.Add( startupMenuItem );
            contextMenu.MenuItems.Add( aboutMenuItem );
            contextMenu.MenuItems.Add( "-" );
            contextMenu.MenuItems.Add( quitMenuItem );
            notifyIcon.ContextMenu = contextMenu;

            // If there is a shortcut of app in startup folder put check mark for the menu item
            var exeName = System.IO.Path.GetFileNameWithoutExtension(
                System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName );
            startupMenuItem.Checked =
                System.IO.File.Exists(
                    Environment.GetFolderPath( Environment.SpecialFolder.Startup ) + $"\\{exeName}.lnk" );

            #region Context Menu Events Wire Up
            // Wire up menu items event handlers
            quitMenuItem.Click += QuitMenuItemClick;
            startupMenuItem.Click += StartupMenuItemClick;

            // Wire up create profiles menu item to show profile form (settings actually)
            profileCreateMenuItem.Click += (s, e) => {
                var createProfile = new SettingsForm( SettingsForm.NEW );
                createProfile.Show();
            };

            // Wire up edit current profile menu item to show profile form (settings actually) for the active profile
            editCurrentProfileMenuItem.Click += (s, e) => {
                var editCurrentProfile = new SettingsForm( SettingsForm.EDIT_CURRENT );
                editCurrentProfile.Show();
            };

            // Wire up manage profiles menu item to show the form
            profileManageMenuItem.Click += (s, e) => {
                var manageProfiles = new ManageProfiles();
                manageProfiles.Show();
            };

            // Wire up show log menu item to show the form
            showLogMenuItem.Click += (s, e) => {
                var showLog = new ShowLog();
                showLog.Show();
            };

            // Wire up about menu item to show about form
            aboutMenuItem.Click += (s, e) => {
                var about = new AboutForm();
                about.Show();
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
            if ( !File.Exists( path ) ) {
                File.WriteAllBytes( path, Properties.Resources.profiles );
            }

            // Load data from file.
            Profiles = MyJson.ReadData<List<Profile>>( path );

            Net.Profile = Profiles.Find(
                    p => p.Name.ToLower().Equals( Properties.Settings.Default.ActiveProfile )
                );
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
        private static void UpdateRadioMenu(MenuItem sender)
        {
            foreach ( MenuItem item in sender.Parent.MenuItems ) {
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
            byte? menuItemIndex = null;
            MenuItem profilesMenuItem = new MenuItem();

            // find the profiles submenu
            foreach ( MenuItem item in notifyIcon.ContextMenu.MenuItems ) {
                if ( item.Name == "profilesMenuItem" ) {
                    menuItemIndex = (byte)item.Index;
                    profilesMenuItem = item;
                    break;
                }
            }

            // find and remove profiles menu items.
            List<byte> indices = new List<byte>();
            foreach ( MenuItem item in profilesMenuItem.MenuItems ) {
                if ( item.RadioCheck )
                    indices.Add( (byte)item.Index );
            }
            for ( int i = indices.Count - 1; i > -1; i-- ) {
                profilesMenuItem.MenuItems.RemoveAt( indices[i] );
            }

            // adding profiles to the sub menu again.
            foreach ( var item in Profiles ) {
                var menuItem = new MenuItem {
                    Text = item.Name,
                    Name = item.Name + "MenuItem",
                    RadioCheck = true,
                    Checked = Net.Profile != null && Net.Profile.Name != null ?
                        Net.Profile.Name.Equals( item.Name ) : true
                };
                menuItem.Click += ProfileMenuItemClick;
                profilesMenuItem.MenuItems.Add( menuItem );
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
            ShowBallonMessage( message, title );
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

            notifyIcon.ShowBalloonTip( 1000 );
        }

        /// <summary>
        /// Adds the text (and time) to the resutls list. (doesn't save on hdd)
        /// </summary>
        /// <param name="str"></param>
        public void Log(string[] str)
        {
            ResultsLog.Add( DateTime.Now.ToString() );
            ResultsLog.AddRange( str );
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
            MyJson.WriteData( path, Program.operations.Profiles );
        }

        /// <summary>
        /// It will make a copy from the given profile.
        /// </summary>
        /// <param name="profileName"></param>
        public void Duplicate(string profileName)
        {
            var sourceProfile = Profiles.Find( p => p.Name.Equals( profileName ) );
            var newProfile = new Profile( sourceProfile );
            Profiles.Add( newProfile );
        }
        #endregion
    }
}
