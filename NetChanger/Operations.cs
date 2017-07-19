using System;
using System.Configuration;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace NetChanger
{
    class Operations
    {
        #region Fields
        NotifyIcon notifyIcon;
        Icon normalIcon;
        #endregion

        #region Public Fields
        public NetProperties Net;
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
        /// Changes IP settings to DHCP
        /// </summary>
        void DhcpMenuItemClick(object sender, EventArgs e)
        {
            UpdateRadioMenu( (MenuItem)sender );
            Net.Static = false;
            Cmd.Execute( Net.Do );
        }

        /// <summary>
        /// Changes IP settings to static mode
        /// </summary>
        void StaticIpMenuItemClick(object sender, EventArgs e)
        {
            UpdateRadioMenu( (MenuItem)sender );
            Net.Static = true;
            Cmd.Execute( Net.Do );
        }

        /// <summary>
        /// Puts the app in startup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void StartupMenuItemClick(object sender, EventArgs e)
        {
            // TODO: move this to the settings
            MenuItem m = (MenuItem)sender;
            m.Checked = !m.Checked;
            bool set = m.Checked;

            // If menu checked puts the shortcut of app to startup folder,
            // else deletes the shortcut
            if ( set ) {
                Rahmanism.ir.Common.PutInStartupFolder();
            }
            else {
                try {
                    System.IO.File.Delete(
                        Environment.GetFolderPath( Environment.SpecialFolder.Startup ) + "\\Jarvis.lnk" );
                }
                catch { }
            }
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
                Text = "Easily change your IP settings!",
                Visible = true
            };
        }

        /// <summary>
        /// Create a context menu and assingn it to notfication tray icon
        /// </summary>
        private void CreateContextMenu()
        {
            // Create context menu and assign it to notification icon
            var progNameMenuItem = new MenuItem( String.Format( "NetChanger, Change your net easily - v{0}",
                Assembly.GetExecutingAssembly().GetName().Version.ToString() ) );
            var settingsMenuItem = new MenuItem {
                Text = "Settings",
                Name = "settingsMenuItem"
            };
            var dhcpMenuItem = new MenuItem {
                Text = "DHCP",
                Name = "dhcpMenuItem",
                RadioCheck = true,
                Checked = true
            };
            var staticIpMenuItem = new MenuItem {
                Text = "Static IP",
                Name = "staticIpMenuItem",
                RadioCheck = true
            };
            var aboutMenuItem = new MenuItem {
                Text = "About",
                Name = "aboutMenuItem"
            };
            var quitMenuItem = new MenuItem( "Quit" );
            var contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add( progNameMenuItem );
            contextMenu.MenuItems.Add( "-" );
            contextMenu.MenuItems.Add( settingsMenuItem );
            contextMenu.MenuItems.Add( "-" );
            contextMenu.MenuItems.Add( dhcpMenuItem );
            contextMenu.MenuItems.Add( staticIpMenuItem );
            contextMenu.MenuItems.Add( "-" );
            contextMenu.MenuItems.Add( aboutMenuItem );
            contextMenu.MenuItems.Add( "-" );
            contextMenu.MenuItems.Add( quitMenuItem );
            notifyIcon.ContextMenu = contextMenu;

            // If there is a shortcut of app in startup folder put check mark for the menu item
            // TODO: checked status for to menu items (dhcp and static) should be set in intialization
            //startupMenuItem.Checked =
            //    System.IO.File.Exists(
            //        Environment.GetFolderPath( Environment.SpecialFolder.Startup ) + "\\Jarvis.lnk" );

            #region Context Menu Events Wire Up
            // Wire up menu items event handlers
            quitMenuItem.Click += QuitMenuItemClick;
            // TODO: set dhcp & static ip menu items event handler in main Program
            dhcpMenuItem.Click += DhcpMenuItemClick;
            staticIpMenuItem.Click += StaticIpMenuItemClick;

            // Wire up settings menu item to show the settigns form (Main form of app!)
            settingsMenuItem.Click += (s, e) => {
                var main = new SettingsForm();
                main.Show();
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
            // Loading net properties from app settings.
            Net.Address = Properties.Settings.Default.Address;
            Net.NetMask = Properties.Settings.Default.Netmask;
            Net.Gateway = Properties.Settings.Default.Gateway;
            Net.DnsOne = Properties.Settings.Default.DnsOne;
            Net.DnsTwo = Properties.Settings.Default.DnsTwo;
            Net.Static = Properties.Settings.Default.Static;
            Net.InterfaceName = Properties.Settings.Default.InterfaceName;
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
        /// Updates the configuration items at runtime
        /// </summary>
        private void UpdateConfig()
        {
            // TODO: should update the settings
            //config.MuteMemAlert = MemAlert;
            //config.MuteCpuAlert = CpuAlert;
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
                "Jarvis System Performance Monitor" : title;

            notifyIcon.ShowBalloonTip( 1000 );
        }
        #endregion
    }
}
