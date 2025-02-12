using System.Collections.Generic;
using System.Windows;

namespace INNIM_1._2.AppData
{
    public static class WindowManager
    {
        private static List<Window> openWindows = new List<Window>();

        public static void RegisterWindow(Window window)
        {
            openWindows.Add(window);
        }

        public static void CloseAllWindows()
        {
            foreach (var window in openWindows)
            {
                window.Close();
            }
            openWindows.Clear();
        }
    }
}
