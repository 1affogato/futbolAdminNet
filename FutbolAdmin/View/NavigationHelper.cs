using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FutbolAdmin.View
{
    internal class NavigationHelper
    {
        public static void ShowWindowAndHideParent(Window newWindow, Window parentWindow)
        {
            parentWindow.Hide();
            newWindow.Owner = parentWindow;
            newWindow.Closed += (s, args) => parentWindow.Show();
            newWindow.Show();
        }
        public static void ShowDialogWindow(Window newWindow, Window ownerWindow)
        {
            newWindow.Owner = ownerWindow;
            newWindow.ShowDialog();
        }

        public static void CloseWindow(Window window)
        {
            window.Close();
        }
    }
}
