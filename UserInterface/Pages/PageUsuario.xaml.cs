using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace UserInterface.Pages
{
    /// <summary>
    /// Interaction logic for PageUsuario.xaml
    /// </summary>
    public partial class PageUsuario : Page
    {
        public MainWindow _mainWindow { get; set; }

        public List<Business.DTO.Usuario>? data { get; set; }
        public Business.DTO.Usuario? selected { get; set; }
        public string FlyoutMode = "";


        public PageUsuario(MainWindow mainWindow)
        {
            InitializeComponent();
            SetupDatagrid();
            SetupComboboxes();
            _mainWindow = mainWindow;
        }

        public async void SetupComboboxes()
        {
            try
            {
                cb_Perfil.ItemsSource = Business.DTO.PerfilUsuario.ReadAll().Select(p => p.Descripcion);
            }
            catch (Exception e)
            {
                await _mainWindow.ShowMessageAsync("Error Interno", e.Message);
            }
        }

        public async void SetupDatagrid()
        {
            try
            {
                data = Business.DTO.Usuario.GetAllUsuario();
                datagrid.DataContext = data;
                datagrid.Items.Refresh();
            }
            catch (Exception e)
            {
                await _mainWindow.ShowMessageAsync("Error Interno", e.Message);
            }
        }

        private void Refresh(object sender, RoutedEventArgs e) => SetupDatagrid();

        private void Add(object sender, RoutedEventArgs e)
        {
            FlyoutMode = "Add";

            tbx_IdUsuario.Text = "";
            tbx_Correo.Text = "";
            tbx_ContrasenaHashed.Text = "";
            dtp_IsHabilitado.IsChecked = true;
            tbx_RutCliente.Text = "";
            tbx_RutProfesional.Text = "";
            cb_Perfil.SelectedItem = cb_Perfil.Items[0];

            // habilitamos campos clave

            tbx_IdUsuario.IsReadOnly = true;
            tbx_RutCliente.IsReadOnly = false;
            tbx_RutProfesional.IsReadOnly = false;

            tbx_IdUsuario.IsEnabled = false;
            tbx_RutCliente.IsEnabled = true;
            tbx_RutProfesional.IsEnabled = true;

            // disponibilizar los campos

            tbx_Correo.IsReadOnly = false;
            tbx_ContrasenaHashed.IsReadOnly = false;

            tbx_Correo.IsEnabled = true;
            tbx_ContrasenaHashed.IsEnabled = true;
            dtp_IsHabilitado.IsEnabled = true;

            Flyout.IsOpen = true;
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            FlyoutMode = "Edit";

            // cargamos los campos en los TextBox

            if (selected != null)
            {
                tbx_IdUsuario.Text = selected.Idusuario.ToString();
                tbx_Correo.Text = selected.Correo.ToString();
                tbx_ContrasenaHashed.Text = selected.Contrasenahashed.ToString();
                dtp_IsHabilitado.IsChecked = (selected.Ishabilitado ?? "0").Equals("1");
                tbx_RutCliente.Text = selected.Rutcliente?.ToString();
                tbx_RutProfesional.Text = selected.Rutprofesional?.ToString();
                cb_Perfil.SelectedItem = Business.DTO.PerfilUsuario.Read((int)selected.Idperfil);
            }

            // deshabilitamos campos clave

            tbx_IdUsuario.IsReadOnly = true;
            tbx_RutCliente.IsReadOnly = true;
            tbx_RutProfesional.IsReadOnly = true;

            tbx_IdUsuario.IsEnabled = false;
            tbx_RutCliente.IsEnabled = false;
            tbx_RutProfesional.IsEnabled = false;

            // disponibilizar los campos

            tbx_Correo.IsReadOnly = false;
            tbx_ContrasenaHashed.IsReadOnly = false;

            tbx_Correo.IsEnabled = true;
            tbx_ContrasenaHashed.IsEnabled = true;
            dtp_IsHabilitado.IsEnabled = true;


            Flyout.IsOpen = true;
        }


        private void datagrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            selected = (Business.DTO.Usuario)datagrid.SelectedItem;
            btn_edit.IsEnabled = datagrid.SelectedItem != null ? true : false;
        }



        #region Botones Aceptar / Cancelar

        private async void Save(object sender, RoutedEventArgs e)
        {
            Business.DTO.Usuario newData = new Business.DTO.Usuario()
            {
                Correo = tbx_Correo.Text,
                Contrasenahashed = tbx_ContrasenaHashed.Text,
                Rutcliente = tbx_RutCliente.Text.Equals("") ? null : tbx_RutCliente.Text,
                Rutprofesional = tbx_RutProfesional.Text.Equals("") ? null : tbx_RutProfesional.Text,
                Ishabilitado = (dtp_IsHabilitado.IsChecked ?? false) ? "1" : "0",
                Idperfil = Business.DTO.PerfilUsuario.Read(cb_Perfil.SelectedItem.ToString()).Idperfil
            };
            
            #region Guardar

            if (FlyoutMode.Equals("Add"))
            {
                bool? result = Business.DTO.Usuario.Create(newData);

                switch (result)
                {
                    case true:
                        await _mainWindow.ShowMessageAsync("Usuario Guardado", "");
                        break;

                    case false:
                        await _mainWindow.ShowMessageAsync("Usuario no guardado", "Este usuario ya existe en el sistema.");
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
                newData.Idusuario = decimal.Parse(tbx_IdUsuario.Text);

                bool? result = Business.DTO.Usuario.Update(newData);

                switch (result)
                {
                    case true:
                        await _mainWindow.ShowMessageAsync("Usuario Actualizado", "");
                        break;

                    case false:
                        await _mainWindow.ShowMessageAsync("Usuario no actualizado", "Este usuario no existe en el sistema.");
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
