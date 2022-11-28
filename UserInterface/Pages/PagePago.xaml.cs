using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace UserInterface.Pages
{
    public partial class PagePago : Page
    {
        public MainWindow _mainWindow { get; set; }
        public List<Business.DTO.Pago>? data { get; set; }

        public PagePago(MainWindow mainWindow)
        {
            InitializeComponent();
            SetupDatagrid();
            _mainWindow = mainWindow;
        }

        public async void SetupDatagrid()
        {
            try
            {
                // contratos
                data = Business.DTO.Pago.ReadAll();
                datagrid.DataContext = data;
                datagrid.Items.Refresh();
            }
            catch (Exception e)
            {
                await _mainWindow.ShowMessageAsync("Error Interno", e.Message);
            }
        }



        private void Refresh(object sender, RoutedEventArgs e) => SetupDatagrid();

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
                datagrid.DataContext = data?.Where(d =>
                    d.Fecharegistro.ToString().Contains(tb.Text)
                    || d.Montopago.ToString().Contains(tb.Text)
                    || d.Idpago.ToString().Contains(tb.Text)
                    || d.Idcanalpago.ToString().Contains(tb.Text)
                    || d.Idcomprobante.ToString().Contains(tb.Text));
                datagrid.Items.Refresh();
            }
        }

    }
}
