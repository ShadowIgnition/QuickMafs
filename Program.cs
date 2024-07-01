using Microsoft.Win32;

namespace QuickMafs
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            InitializeTrayIcon();
            m_Form = new MathField();
            m_Form.Visible = false;
            m_Form.VisibleChanged += ToggleHideMenuItem;

            Application.Run();
            SetStartup();
        }

        static void SetStartup()
        {
            //Set the application to run at startup
            RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupKey, true);
            key.SetValue(StartupValue, Application.ExecutablePath.ToString());
        }

        static void InitializeTrayIcon()
        {
            // Create a context menu for the tray icon
            m_TrayMenu = new ContextMenuStrip();
            m_TrayMenu.Items.Add("Exit", null, (x, y) => Application.Exit());
            m_HideButton = new ToolStripButton("Hide", null, (x, y) => m_Form?.Hide());

            // Create the NotifyIcon
            m_TrayIcon = new NotifyIcon
            {
                Text = "QuickMafs",
                Icon = MathField.GetIcon(),
                ContextMenuStrip = m_TrayMenu,
                Visible = true
            };

            // Handle the click event
            m_TrayIcon.MouseClick += TrayIcon_MouseClick;
        }

        static void ToggleHideMenuItem(object? sender, EventArgs e)
        {
            if (m_Form == null || m_HideButton == null)
            {
                return;
            }

            if (m_Form.Visible)
            {
                m_TrayMenu?.Items.Add(m_HideButton);
            }
            else
            {
                m_TrayMenu?.Items.Remove(m_HideButton);
            }
        }

        static void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (m_Form == null)
                {
                    return;
                }

                m_Form.Show();
            }
        }

        static ToolStripButton? m_HideButton;
        static NotifyIcon? m_TrayIcon;
        static ContextMenuStrip? m_TrayMenu;
        static Form? m_Form;

        // Startup registry key and value
        static readonly string StartupKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        static readonly string StartupValue = "QuickMafs";
    }
}