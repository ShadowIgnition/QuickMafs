namespace QuickMafs
{
    public static class Utils
    {
        /// <summary>
        /// Gets the primary screen or the first screen if primary is null.
        /// </summary>
        public static Screen GetScreen()
        {
            return Screen.PrimaryScreen ?? Screen.AllScreens[0];
        }

        /// <summary>
        /// Sets the form's position near the system tray.
        /// </summary>
        public static void SetFormPositionNearTray(Form form, Screen screen)
        {
            Rectangle workingArea = screen.WorkingArea;

            // Calculate the position based on taskbar location
            int x = workingArea.Right - form.Size.Width;
            int y = workingArea.Bottom - form.Size.Height;

            form.Location = new Point(x, y);
        }
    }
}