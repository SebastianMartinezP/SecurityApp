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
        }

        public MainWindow(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private void tileProfesionales_Click(object sender, RoutedEventArgs e)
        {
        }

        private void tileUsuarios_Click(object sender, RoutedEventArgs e)
        {
            Flyout.Content = new Frame()
            {
                Width = 1000,
                Height = 1000,
                Content = new PageUsuario(),
            };
            

            Flyout.IsOpen = true;

            
        }
    }
}
