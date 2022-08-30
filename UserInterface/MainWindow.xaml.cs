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

using Wpf.Ui.Controls;
using Wpf.Ui.Extensions;


namespace UserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Wpf.Ui.Controls.UiWindow
    {
        public string? username { get; set; }

        public MainWindow() => InitializeComponent();

        public MainWindow(string username)
        {
            this.username = username;
            InitializeComponent();
            this.RemoveTitlebar();
            this.ApplyBackdrop(Wpf.Ui.Appearance.BackgroundType.Mica);

        }
    }
}
