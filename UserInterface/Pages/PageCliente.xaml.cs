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
    /// Interaction logic for PageCliente.xaml
    /// </summary>
    public partial class PageCliente : Page
    {
        public MainWindow _mainWindow { get; set; }

        public List<Business.DTO.Cliente>? data { get; set; }
        public Business.DTO.Cliente? selected { get; set; }
        public string FlyoutMode = "";


        public PageCliente(MainWindow mainWindow)
        {
            InitializeComponent();
            SetupDatagrid();
            _mainWindow = mainWindow;
        }


        public async void SetupDatagrid()
        {
            try
            {
                data = Business.DTO.Cliente.ReadAllCliente();
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

            tbx_Rutcliente.Text = "";
            tbx_Razonsocial.Text = "";
            tbx_Numerocontacto.Text = "";
            tbx_Idrubro.Text = "";
            dtp_Ismoroso.IsChecked = false;

            // habilitamos campos clave

            tbx_Rutcliente.IsReadOnly = false;
            tbx_Rutcliente.IsEnabled = true;

            // disponibilizar los campos

            tbx_Razonsocial.IsReadOnly = false;
            tbx_Numerocontacto.IsReadOnly = false;
            tbx_Idrubro.IsReadOnly = false;

            tbx_Razonsocial.IsEnabled = true;
            tbx_Numerocontacto.IsEnabled = true;
            tbx_Idrubro.IsEnabled = true;
            dtp_Ismoroso.IsEnabled = true;

            Flyout.IsOpen = true;
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            FlyoutMode = "Edit";

            // cargamos los campos en los TextBox

            if (selected != null)
            {
                tbx_Rutcliente.Text = selected.Rutcliente.ToString();
                tbx_Razonsocial.Text = selected.Razonsocial.ToString();
                tbx_Numerocontacto.Text = selected.Numerocontacto?.ToString();
                tbx_Idrubro.Text = selected.Idrubro.ToString();
                dtp_Ismoroso.IsChecked = (selected.Ismoroso ?? "0").Equals("1");
            }

            // deshabilitamos campos clave

            tbx_Rutcliente.IsReadOnly = true;
            tbx_Rutcliente.IsEnabled = false;

            // disponibilizar los campos

            tbx_Razonsocial.IsReadOnly = true;
            tbx_Numerocontacto.IsReadOnly = false;
            tbx_Idrubro.IsReadOnly = false;

            tbx_Razonsocial.IsEnabled = false;
            tbx_Numerocontacto.IsEnabled = true;
            tbx_Idrubro.IsEnabled = true;
            dtp_Ismoroso.IsEnabled = true;


            Flyout.IsOpen = true;
        }


        private void datagrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            selected = (Business.DTO.Cliente)datagrid.SelectedItem;

            btn_edit.IsEnabled = datagrid.SelectedItem != null ? true : false;
        }



        #region Botones Aceptar / Cancelar

        private async void Save(object sender, RoutedEventArgs e)
        {
            Business.DTO.Cliente newData = new Business.DTO.Cliente()
            {
                Ismoroso = (dtp_Ismoroso.IsChecked ?? false) ? "1" : "0",
                Numerocontacto = tbx_Numerocontacto.Text,
                Razonsocial = tbx_Razonsocial.Text,
                Idrubro = decimal.Parse(tbx_Idrubro.Text),
                Rutcliente = tbx_Rutcliente.Text,
            };

            #region Guardar

            if (FlyoutMode.Equals("Add"))
            {
                bool? result = Business.DTO.Cliente.Create(newData);

                switch (result)
                {
                    case true:
                        await _mainWindow.ShowMessageAsync("Cliente Guardado", "");
                        break;

                    case false:
                        await _mainWindow.ShowMessageAsync("Cliente no guardado", "Este cliente ya existe en el sistema.");
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
                newData.Rutcliente = tbx_Rutcliente.Text;

                bool? result = Business.DTO.Cliente.Update(newData);

                switch (result)
                {
                    case true:
                        await _mainWindow.ShowMessageAsync("Cliente Actualizado", "");
                        break;

                    case false:
                        await _mainWindow.ShowMessageAsync("Cliente no actualizado", "Este cliente no existe en el sistema.");
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
