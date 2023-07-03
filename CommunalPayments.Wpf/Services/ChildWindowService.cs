using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CommunalPayments.Wpf.Services
{
    internal static class ChildWindowService
    {
        public static ObservableCollection<Window> ChildWindows { get; } = new ObservableCollection<Window>();

        public static void Add(Window window)
        {
            if (!ChildWindows.Contains(window))
            {
                ChildWindows.Add(window);
            }
        }

        public static void Remove(Window window)
        {
            if (ChildWindows.Contains(window))
            {
                ChildWindows.Remove(window);
            }
        }

        public static void CloseAll()
        {
            foreach (var window in ChildWindows)
            {
                window.Close();
            }
        }
    }
}
