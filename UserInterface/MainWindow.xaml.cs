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

using Business.DTO;
using Database.Models;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public Business.DTO.Usuario? user { get; set; }
        public List<object> pages { get; set; }

        // constructor bypass del login
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
                new PagePago(this),
                new PagePerfilUsuario(this),
                new PageProfesional(this),
                new PageUsuario(this),
                new PageReporte(this),
            };
            windowFrame.Content = GoTo<PageHome>();

            lb_username.Content = "Usuario";
            lb_name.Content = "Nombre";
        }

        public MainWindow(Business.DTO.Usuario _user)
        {
            InitializeComponent();
            // setup paginas
            pages = new List<object>()
            {
                new PageHome(this),
                new PageError(this),
                new PageActividad(this),
                new PageCheckList(this),
                new PageCliente(this),
                new PageContrato(this),
                new PagePago(this),
                new PagePerfilUsuario(this),
                new PageProfesional(this),
                new PageUsuario(this),
                new PageReporte(this),
            };
            windowFrame.Content = GoTo<PageHome>();

            // setup usuario
            this.user = _user;
            Business.DTO.Profesional? profesional = Business.DTO.Profesional.Read(user.Rutprofesional ?? "");

            lb_name.Content = user.Correo.Length > 0 ? user.Correo.Split('@')[0] : "Usuario";
            lb_username.Content = profesional?.Primernombre.Length > 0 ? profesional.Primernombre : "Nombre";
        }


        public object? GoTo<T>()
        {
            return 
                pages.Find(x => x.GetType() == typeof(T)) ??
                pages.Find(x => x.GetType() == typeof(PageError));
        }
        private void GoToInicio(object sender, RoutedEventArgs e) => windowFrame.Content = GoTo<PageHome>();
        private void GoToProfesionales(object sender, RoutedEventArgs e) => windowFrame.Content = GoTo<PageProfesional>();
        private void GoToClientes(object sender, RoutedEventArgs e) => windowFrame.Content = GoTo<PageCliente>();
        private void GoToActividades(object sender, RoutedEventArgs e) => windowFrame.Content = GoTo<PageActividad>();
        private void GoToContratos(object sender, RoutedEventArgs e) => windowFrame.Content = GoTo<PageContrato>();
        private void GoToPagos(object sender, RoutedEventArgs e) => windowFrame.Content = GoTo<PagePago>();
        private void GoToAlertas(object sender, RoutedEventArgs e) => windowFrame.Content = GoTo<PageError>();
        private void GoToChecklists(object sender, RoutedEventArgs e) => windowFrame.Content = GoTo<PageCheckList>();
        private void GoToReportes(object sender, RoutedEventArgs e) => windowFrame.Content = GoTo<PageReporte>();
        private void GoToUsuarios(object sender, RoutedEventArgs e) => windowFrame.Content = GoTo<PageUsuario>();
        private void GoToPerfilesDeUsuario(object sender, RoutedEventArgs e) => windowFrame.Content = GoTo<PagePerfilUsuario>();

    }
}
