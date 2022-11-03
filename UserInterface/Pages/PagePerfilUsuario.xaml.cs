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


using Business;
using MahApps.Metro.Controls.Dialogs;

namespace UserInterface.Pages
{
    /// <summary>
    /// Interaction logic for PagePerfilUsuario.xaml
    /// </summary>
    public partial class PagePerfilUsuario : Page
    {
        public MainWindow _mainWindow { get; set; }

        public List<Business.DTO.PerfilUsuario>? data { get; set; }
        public Business.DTO.PerfilUsuario? selected { get; set; }
        public string FlyoutMode = "";


        public PagePerfilUsuario(MainWindow mainWindow)
        {
            InitializeComponent();
            SetupDatagrid();
            _mainWindow = mainWindow;
        }


        public async void SetupDatagrid()
        {
            try
            {
                data = Business.DTO.PerfilUsuario.GetAllPerfilUsuario();
                datagrid.DataContext = data;
                datagrid.Items.Refresh();
            }
            catch (Exception e)
            {
                await _mainWindow.ShowMessageAsync("Error Interno", e.Message);
            }
        }

        private void Refresh(object sender, RoutedEventArgs e)  => SetupDatagrid();

        private void Add(object sender, RoutedEventArgs e)
        {
            FlyoutMode = "Add";

            tbx_Idperfil.Text = "";
            tbx_Descripcion.Text = "";

            // habilitamos campos clave

            tbx_Idperfil.IsReadOnly = true;
            tbx_Idperfil.IsEnabled = false;

            // disponibilizar los campos

            tbx_Descripcion.IsReadOnly = false;
            tbx_Descripcion.IsEnabled = true;

            Flyout.IsOpen = true;
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            FlyoutMode = "Edit";

            // cargamos los campos en los TextBox

            if (selected != null)
            {
                tbx_Idperfil.Text = selected.Idperfil.ToString();
                tbx_Descripcion.Text = selected.Descripcion.ToString();
            }

            // deshabilitamos campos clave

            tbx_Idperfil.IsReadOnly = true;
            tbx_Idperfil.IsEnabled = false;

            // disponibilizar los campos

            tbx_Descripcion.IsReadOnly = false;
            tbx_Descripcion.IsEnabled = true;

            Flyout.IsOpen = true;
        }


        private void datagrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            selected = (Business.DTO.PerfilUsuario)datagrid.SelectedItem;

            btn_edit.IsEnabled = datagrid.SelectedItem != null ? true : false;
        }



        #region Botones Aceptar / Cancelar

        private async void Save(object sender, RoutedEventArgs e)
        {

            Business.DTO.PerfilUsuario newData = new Business.DTO.PerfilUsuario()
            {
                Descripcion = tbx_Descripcion.Text,
            };

            #region Guardar

            if (FlyoutMode.Equals("Add"))
            {
                bool? result = Business.DTO.PerfilUsuario.Create(newData);

                switch (result)
                {
                    case true:
                        await _mainWindow.ShowMessageAsync("Perfil de usuario Guardado", "");
                        break;

                    case false:
                        await _mainWindow.ShowMessageAsync("Perfil de usuario no guardado", "Este perfil de usuario ya existe en el sistema.");
                        break;

                    case null:
                        await _mainWindow.ShowMessageAsync("Error", "Parece que algo salió mal, reintente por favor.");
                        break;
                }
            }

            #endregion

            #region Editar

            else
            {
                newData.Idperfil = decimal.Parse(tbx_Idperfil.Text);

                bool? result = Business.DTO.PerfilUsuario.Update(newData);

                switch (result)
                {
                    case true:
                        await _mainWindow.ShowMessageAsync("Perfil de usuario Actualizado", "");
                        break;

                    case false:
                        await _mainWindow.ShowMessageAsync("Perfil de usuario no actualizado", "Este perfil de usuario no existe en el sistema.");
                        break;

                    case null:
                        await _mainWindow.ShowMessageAsync("Error", "Parece que algo salió mal, reintente por favor.");
                        break;
                }
            }

            #endregion


            SetupDatagrid();
            Flyout.IsOpen = false;

        }


        private void Cancel(object sender, RoutedEventArgs e) => Flyout.IsOpen = false;

        #endregion  


    }
}
