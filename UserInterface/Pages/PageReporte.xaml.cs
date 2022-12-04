using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Business.Util;
using MahApps.Metro.Controls.Dialogs;
namespace UserInterface.Pages
{
    public partial class PageReporte : Page
    {
        public MainWindow _mainWindow { get; set; }
        public List<object> pages { get; set; }

        public PageReporte(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;


            pages = new List<object>()
            {
                new PageReporteGeneral(this, _mainWindow),
            };
            windowFrame.Content = GoTo<PageReporteGeneral>();
        }


        public object? GoTo<T>()
        {
            return
                pages.Find(x => x.GetType() == typeof(T)) ??
                pages.Find(x => x.GetType() == typeof(PageError));
        }




    }
}
