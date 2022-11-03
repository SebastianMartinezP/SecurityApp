using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using UserInterface.Pages;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public string? username { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            windowFrame.Content = new Frame()
            {
                //Content = new PageUsuario(this)
                Content = new PagePerfilUsuario(this)
            };
        }

        public MainWindow(string username)
        {
            this.username = username;
            InitializeComponent();
            windowFrame.Content = new Frame()
            {
                //Content = new PageUsuario(this)
                Content = new PagePerfilUsuario(this)
            };
        }
    }
}
