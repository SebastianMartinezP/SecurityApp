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
    /// Interaction logic for PageCheckList.xaml
    /// </summary>
    public partial class PageCheckList : Page
    {
        public MainWindow _mainWindow { get; set; }

        public List<Business.DTO.CheckList>? data { get; set; }
        public Business.DTO.CheckList? selected { get; set; }
        public string FlyoutMode = "";

        public PageCheckList(MainWindow mainWindow)
        {
            InitializeComponent();
            SetupDatagrid();
            _mainWindow = mainWindow;
        }

        public async void SetupDatagrid()
        {
            try
            {
                data = Business.DTO.CheckList.GetAllCheckList();
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

            tbx_Idcheck.Text = "";
            tbx_Descripcion.Text = "";

            tbx_FechaRegistro.Text = DateTime.Today.ToString("dd/MM/yyyy");

            dtp_Isseniales.IsChecked = false;
            dtp_Iselementoseguridad.IsChecked = false;
            dtp_Ismaterial.IsChecked = false;
            dtp_Isredagua.IsChecked = false;
            dtp_Isluminaria.IsChecked = false;
            dtp_Isseguro.IsChecked = false;
            dtp_Istrabajoseguro.IsChecked = false;

            // deshabilitamos campos clave
            tbx_Idcheck.IsReadOnly = true;
            tbx_Idcheck.IsEnabled = false;


            Flyout.IsOpen = true;
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            FlyoutMode = "Edit";

            // cargamos los campos en los TextBox

            if (selected != null)
            {
                tbx_Idcheck.Text = selected.Idcheck.ToString();
                tbx_Descripcion.Text = selected.Descripcion.ToString();

                tbx_FechaRegistro.Text = selected.Fecharegistro.ToString();

                dtp_Isseniales.IsChecked = (selected.Isseniales ?? "0").Equals("1");
                dtp_Iselementoseguridad.IsChecked = (selected.Iselementoseguridad ?? "0").Equals("1");
                dtp_Ismaterial.IsChecked = (selected.Ismaterial ?? "0").Equals("1");
                dtp_Isredagua.IsChecked = (selected.Isredagua ?? "0").Equals("1");
                dtp_Isluminaria.IsChecked = (selected.Isluminaria ?? "0").Equals("1");
                dtp_Isseguro.IsChecked = (selected.Isseguro ?? "0").Equals("1");
                dtp_Istrabajoseguro.IsChecked = (selected.Istrabajoseguro ?? "0").Equals("1");
            }

            // deshabilitamos campos clave
            tbx_Idcheck.IsReadOnly = true;
            tbx_Idcheck.IsEnabled = false;

            Flyout.IsOpen = true;
        }


        private void datagrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            selected = (Business.DTO.CheckList)datagrid.SelectedItem;

            btn_edit.IsEnabled = datagrid.SelectedItem != null ? true : false;
        }



        #region Botones Aceptar / Cancelar

        private async void Save(object sender, RoutedEventArgs e)
        {

            Business.DTO.CheckList newData = new Business.DTO.CheckList()
            {
                Isseniales = (dtp_Isseniales.IsChecked ?? false) ? "1" : "0",
                Iselementoseguridad = (dtp_Iselementoseguridad.IsChecked ?? false) ? "1" : "0",
                Ismaterial = (dtp_Ismaterial.IsChecked ?? false) ? "1" : "0",
                Isredagua = (dtp_Isredagua.IsChecked ?? false) ? "1" : "0",
                Isluminaria = (dtp_Isluminaria.IsChecked ?? false) ? "1" : "0",
                Isseguro = (dtp_Isseguro.IsChecked ?? false) ? "1" : "0",
                Istrabajoseguro =(dtp_Istrabajoseguro.IsChecked ?? false) ? "1" : "0",
                Descripcion = tbx_Descripcion.Text,
            };

            #region Guardar

            if (FlyoutMode.Equals("Add"))
            {
                bool? result = Business.DTO.CheckList.Create(newData);

                switch (result)
                {
                    case true:
                        await _mainWindow.ShowMessageAsync("Checklist Guardado", "");
                        break;

                    case false:
                        await _mainWindow.ShowMessageAsync("Checklist no guardado", "Este checklist ya existe en el sistema.");
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
                newData.Idcheck = decimal.Parse(tbx_Idcheck.Text);

                bool? result = Business.DTO.CheckList.Update(newData);

                switch (result)
                {
                    case true:
                        await _mainWindow.ShowMessageAsync("Checklist Actualizado", "");
                        break;

                    case false:
                        await _mainWindow.ShowMessageAsync("Checklist no actualizado", "Este checklist no existe en el sistema.");
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
