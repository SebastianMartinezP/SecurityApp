﻿using System;
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
    /// Interaction logic for PageContrato.xaml
    /// </summary>
    public partial class PageContrato : Page
    {
        public MainWindow _mainWindow { get; set; }

        public List<Business.DTO.Contrato>? data { get; set; }
        public Business.DTO.Contrato? selected { get; set; }
        public string FlyoutMode = "";

        public PageContrato(MainWindow mainWindow)
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
                data = Business.DTO.Contrato.ReadAllContrato();
                datagrid.DataContext = data;
                datagrid.Items.Refresh();


                int cantCaducados = 0;
                int cantPorCaducar = 0;

                // estado de los contratos
                foreach (Business.DTO.Contrato contrato in data)
                {
                    
                    double daysDiff = (contrato.Fechacontrato.AddMonths(1).AddDays(-10)  - DateTime.Today).TotalDays;
                    if (daysDiff < 10 && daysDiff > 0) // temporada de aviso (10 días)
                    {
                        cantPorCaducar ++;
                    }
                    else if (daysDiff < 0)
                    {
                        cantCaducados ++;
                    }
                }

                lb_CountCaducados.Content = cantCaducados.ToString();
                lb_CountPorCaducar.Content = cantPorCaducar.ToString();
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

            tbx_Idcontrato.Text = "";
            tbx_Descripcion.Text = "";
            tbx_Valor.Text = "";
            tbx_Fechacontrato.Text = DateTime.Today.ToString("dd/MM/yyyy");

            tbx_Idpago.Text = "";
            tbx_Rutcliente.Text = "";
            tbx_Idactividad.Text = "";

            dtp_Vigente.IsChecked = false;

            // deshabilitamos campos clave
            tbx_Idcontrato.IsReadOnly = true;
            tbx_Idcontrato.IsEnabled = false;

            Flyout.IsOpen = true;
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            FlyoutMode = "Edit";

            // cargamos los campos en los TextBox

            if (selected != null)
            {
                tbx_Idcontrato.Text = selected.Idcontrato.ToString();
                tbx_Descripcion.Text = selected.Descripcion.ToString();
                tbx_Valor.Text = selected.Valor.ToString();
                tbx_Fechacontrato.Text = selected.Fechacontrato.ToString("dd-MM-yyyy");

                tbx_Idpago.Text = selected.Idpago.ToString();
                tbx_Rutcliente.Text = selected.Rutcliente.ToString();
                tbx_Idactividad.Text = selected.Idactividad.ToString();
                dtp_Vigente.IsChecked = (selected.Vigente ?? "0").Equals("1");
            }

            // deshabilitamos campos clave
            tbx_Idcontrato.IsReadOnly = true;
            tbx_Idcontrato.IsEnabled = false;

            Flyout.IsOpen = true;
        }


        private void datagrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            selected = (Business.DTO.Contrato)datagrid.SelectedItem;

            btn_edit.IsEnabled = datagrid.SelectedItem != null ? true : false;
        }



        #region Botones Aceptar / Cancelar

        private async void Save(object sender, RoutedEventArgs e)
        {

            Business.DTO.Contrato newData = new Business.DTO.Contrato()
            {
                Descripcion = tbx_Descripcion.Text,
                Valor = decimal.Parse(tbx_Valor.Text),
                Rutcliente = tbx_Rutcliente.Text,
                Idactividad = decimal.Parse(tbx_Idactividad.Text),
                Vigente = (dtp_Vigente.IsChecked ?? false) ? "1" : "0",
            };

            #region Guardar

            if (FlyoutMode.Equals("Add"))
            {
                bool? result = Business.DTO.Contrato.Create(newData);

                switch (result)
                {
                    case true:
                        await _mainWindow.ShowMessageAsync("Contrato Guardado", "");
                        break;

                    case false:
                        await _mainWindow.ShowMessageAsync("Contrato no guardado", 
                            "Este contrato ya existe en el sistema.");
                        break;

                    case null:
                        await _mainWindow.ShowMessageAsync("Error", 
                            "Parece que algo salió mal, reintente por favor.");
                        break;
                }
            }

            #endregion

            #region Editar

            else
            {
                newData.Idcontrato = decimal.Parse(tbx_Idcontrato.Text);

                bool? result = Business.DTO.Contrato.Update(newData);

                switch (result)
                {
                    case true:
                        await _mainWindow.ShowMessageAsync("Contrato Actualizado", "");
                        break;

                    case false:
                        await _mainWindow.ShowMessageAsync("Contrato no actualizado", 
                            "Este contrato no existe en el sistema.");
                        break;

                    case null:
                        await _mainWindow.ShowMessageAsync("Error",
                            "Parece que algo salió mal, reintente por favor.");
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