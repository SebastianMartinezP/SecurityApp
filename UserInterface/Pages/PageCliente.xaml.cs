using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Business.Util;
using MahApps.Metro.Controls.Dialogs;

namespace UserInterface.Pages
{
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
            SetupComboboxes();
            _mainWindow = mainWindow;
        }

        public async void SetupDatagrid()
        {
            try
            {
                data = Business.DTO.Cliente.ReadAll();
                datagrid.DataContext = data;
                datagrid.Items.Refresh();
            }
            catch (Exception e)
            {
                await _mainWindow.ShowMessageAsync("Error Interno", e.Message);
            }
        }

        public async void SetupComboboxes()
        {
            try
            {
                List<Business.DTO.Rubro>? rubroList = Business.DTO.Rubro.ReadAll();
                cb_Rubro.ItemsSource = rubroList?.Select(p => p.Descripcion);

            }
            catch (Exception e)
            {
                await _mainWindow.ShowMessageAsync("Error Interno", e.Message);
            }
        }

        private bool ValidateFields()
        {
            try
            {
                bool rutCliente = ValidationHandler.ValidateRut(tbx_Rutcliente.Text);
                bool razonSocial = ValidationHandler.ValidateString(tbx_Razonsocial.Text);

                return rutCliente && razonSocial;
            }
            catch (Exception)
            {
                return false;
            }
        }




        #region Events

        private void searchTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            // si no hay texto solo asignar la data
            if (tb.Text.Length == 0)
            {
                datagrid.DataContext = data;
                datagrid.Items.Refresh();
            }
            else
            {
                // si hay texto con numero que filtre todos los campos con numeros
                if (Regex.IsMatch(tb.Text, @"[\d]"))
                {
                    datagrid.DataContext = data?.Where(d =>
                        d.Rutcliente.Contains(tb.Text)
                        || d.Razonsocial.Contains(tb.Text)
                        || (d.Numerocontacto?? "").Contains(tb.Text)
                    );
                }
                // si no hay numeros solo filtra campos de texto
                else
                {
                    datagrid.DataContext = data?.Where(d =>
                        d.Rutcliente.Contains(tb.Text)
                        || d.Razonsocial.Contains(tb.Text)
                    );
                }
                datagrid.Items.Refresh();
            }
        }

        private void numericTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, @"[^\d]", "");
        }

        private void Refresh(object sender, RoutedEventArgs e) => SetupDatagrid();

        private void Add(object sender, RoutedEventArgs e)
        {
            FlyoutMode = "Add";

            tbx_Rutcliente.Text = "";
            tbx_Razonsocial.Text = "";
            tbx_Numerocontacto.Text = "";
            cb_Rubro.SelectedItem = cb_Rubro.Items[0];
            dtp_Ismoroso.IsChecked = false;

            // habilitamos campos clave

            tbx_Rutcliente.IsReadOnly = false;
            tbx_Rutcliente.IsEnabled = true;

            // disponibilizar los campos

            tbx_Razonsocial.IsReadOnly = false;
            tbx_Numerocontacto.IsReadOnly = false;
            cb_Rubro.IsReadOnly = false;

            tbx_Razonsocial.IsEnabled = true;
            tbx_Numerocontacto.IsEnabled = true;
            cb_Rubro.IsEnabled = true;
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
                cb_Rubro.SelectedItem = Business.DTO.Rubro.Read((int)selected.Idrubro).Descripcion;
                dtp_Ismoroso.IsChecked = (selected.Ismoroso ?? "0").Equals("1");
            }

            // deshabilitamos campos clave

            tbx_Rutcliente.IsReadOnly = true;
            tbx_Rutcliente.IsEnabled = false;

            // disponibilizar los campos

            tbx_Razonsocial.IsReadOnly = true;
            tbx_Numerocontacto.IsReadOnly = false;
            cb_Rubro.IsReadOnly = false;

            tbx_Razonsocial.IsEnabled = false;
            tbx_Numerocontacto.IsEnabled = true;
            cb_Rubro.IsEnabled = true;
            dtp_Ismoroso.IsEnabled = true;


            Flyout.IsOpen = true;
        }

        private void datagrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            selected = (Business.DTO.Cliente)datagrid.SelectedItem;

            btn_edit.IsEnabled = datagrid.SelectedItem != null ? true : false;
        }

        private async void Save(object sender, RoutedEventArgs e)
        {
            Business.DTO.Cliente newData = new Business.DTO.Cliente()
            {
                Ismoroso = (dtp_Ismoroso.IsChecked ?? false) ? "1" : "0",
                Numerocontacto = tbx_Numerocontacto.Text,
                Razonsocial = tbx_Razonsocial.Text,
                Idrubro = Business.DTO.Rubro.Read(cb_Rubro.SelectedItem.ToString()).Idrubro,
                Rutcliente = tbx_Rutcliente.Text,
            };

            #region Guardar

            if (FlyoutMode.Equals("Add"))
            {
                if (!ValidateFields())
                {
                    await _mainWindow.ShowMessageAsync("Alerta", "Hay datos faltantes, por favor ingrese nuevamente.");
                }
                else
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
                    Flyout.IsOpen = false;
                }
            }

            #endregion

            #region Editar

            else
            {
                if (!ValidateFields())
                {
                    await _mainWindow.ShowMessageAsync("Alerta", "Hay datos faltantes, por favor ingrese nuevamente.");
                }
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
                    Flyout.IsOpen = false;
                }
            }
            #endregion

            SetupDatagrid();
        }

        private void Cancel(object sender, RoutedEventArgs e) => Flyout.IsOpen = false;

        #endregion  


    }
}
