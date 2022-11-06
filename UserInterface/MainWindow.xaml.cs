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
        public List<object> pages { get; set; }


        public MainWindow()
        {
            InitializeComponent();

            pages = new List<object>()
            {
                new PageHome(this),
                new PageError(this),
                new PageActividad(this),
                new PageCheckList(this),
                new PageCliente(this),
                new PageContrato(this),
                // new PagePago(this),
                new PagePerfilUsuario(this),
                new PageProfesional(this),
                new PageUsuario(this),
            };

            windowFrame.Content = GoTo<PageHome>();
        }

        public MainWindow(string username)
        {
            this.username = username;

            InitializeComponent();

            pages = new List<object>()
            {
                new PageHome(this),
                new PageError(this),
                // new PageActividad(this),
                new PageCheckList(this),
                new PageCliente(this),
                new PageContrato(this),
                // new PagePago(this),
                new PagePerfilUsuario(this),
                new PageProfesional(this),
                new PageUsuario(this),
            };

            windowFrame.Content = GoTo<PageHome>();
        }


        public object? GoTo<T>()
        {
            return 
                pages.Find(x => x.GetType() == typeof(T)) ??
                pages.Find(x => x.GetType() == typeof(PageError));
        }

        private void GoToProfesionales(object sender, RoutedEventArgs e) => windowFrame.Content = GoTo<PageProfesional>();
        private void GoToClientes(object sender, RoutedEventArgs e) => windowFrame.Content = GoTo<PageCliente>();
        private void GoToActividades(object sender, RoutedEventArgs e) => windowFrame.Content = GoTo<PageActividad>();
        private void GoToContratos(object sender, RoutedEventArgs e) => windowFrame.Content = GoTo<PageContrato>();
        private void GoToPagos(object sender, RoutedEventArgs e) => windowFrame.Content = GoTo<PagePago>();
        private void GoToAlertas(object sender, RoutedEventArgs e) => windowFrame.Content = GoTo<PageError>();
        private void GoToChecklists(object sender, RoutedEventArgs e) => windowFrame.Content = GoTo<PageCheckList>();
        private void GoToReportes(object sender, RoutedEventArgs e) => windowFrame.Content = GoTo<PageError>();
        private void GoToUsuarios(object sender, RoutedEventArgs e) => windowFrame.Content = GoTo<PageUsuario>();
        private void GoToPerfilesDeUsuario(object sender, RoutedEventArgs e) => windowFrame.Content = GoTo<PagePerfilUsuario>();

    }
}
