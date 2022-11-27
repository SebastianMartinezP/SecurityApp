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
    /// Interaction logic for PageProfesional.xaml
    /// </summary>
    public partial class PageProfesional : Page
    {
        public MainWindow _mainWindow { get; set; }

        public List<Business.DTO.Profesional>? data { get; set; }
        public Business.DTO.Profesional? selected { get; set; }
        public string FlyoutMode = "";


        public PageProfesional(MainWindow mainWindow)
        {
            InitializeComponent();
            SetupDatagrid();
            _mainWindow = mainWindow;
        }


        public async void SetupDatagrid()
        {
            try
            {
                data = Business.DTO.Profesional.ReadAll();
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

            tbx_Rutprofesional.Text = "";
            tbx_Primernombre.Text = "";
            tbx_Segundonombre.Text = "";
            tbx_Primerapellido.Text = "";
            tbx_Segundoapellido.Text = "";
            tbx_Numerocontacto.Text = "";
            dtp_Isvigente.IsChecked = true;

            // habilitamos campos clave

            tbx_Rutprofesional.IsReadOnly = false;
            tbx_Rutprofesional.IsEnabled = true;

            // disponibilizar los campos

            tbx_Primernombre.IsReadOnly = false;
            tbx_Segundonombre.IsReadOnly = false;
            tbx_Primerapellido.IsReadOnly = false;
            tbx_Segundoapellido.IsReadOnly = false;
            tbx_Numerocontacto.IsReadOnly = false;

            tbx_Primernombre.IsEnabled = true;
            tbx_Segundonombre.IsEnabled = true;
            tbx_Primerapellido.IsEnabled = true;
            tbx_Segundoapellido.IsEnabled = true;
            tbx_Numerocontacto.IsEnabled = true;
            dtp_Isvigente.IsEnabled = true;

            Flyout.IsOpen = true;
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            FlyoutMode = "Edit";

            // cargamos los campos en los TextBox

            if (selected != null)
            {
                tbx_Rutprofesional.Text = selected.Rutprofesional.ToString();
                tbx_Primernombre.Text = selected.Primerapellido.ToString();
                tbx_Segundonombre.Text = selected.Segundonombre?.ToString();
                tbx_Primerapellido.Text = selected.Primerapellido.ToString();
                tbx_Segundoapellido.Text = selected.Segundoapellido.ToString();
                tbx_Numerocontacto.Text = selected.Numerocontacto.ToString();
                dtp_Isvigente.IsChecked = (selected.Isvigente ?? "0").Equals("1");
            }

            // deshabilitamos campos clave

            tbx_Rutprofesional.IsReadOnly = true;
            tbx_Rutprofesional.IsEnabled = false;

            // disponibilizar los campos

            tbx_Primernombre.IsReadOnly = false;
            tbx_Segundonombre.IsReadOnly = false;
            tbx_Primerapellido.IsReadOnly = false;
            tbx_Segundoapellido.IsReadOnly = false;
            tbx_Numerocontacto.IsReadOnly = false;

            tbx_Primernombre.IsEnabled = true;
            tbx_Segundonombre.IsEnabled = true;
            tbx_Primerapellido.IsEnabled = true;
            tbx_Segundoapellido.IsEnabled = true;
            tbx_Numerocontacto.IsEnabled = true;
            dtp_Isvigente.IsEnabled = true;


            Flyout.IsOpen = true;
        }


        private void datagrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            selected = (Business.DTO.Profesional)datagrid.SelectedItem;

            btn_edit.IsEnabled = datagrid.SelectedItem != null ? true : false;
        }



        #region Botones Aceptar / Cancelar

        private async void Save(object sender, RoutedEventArgs e)
        {

            Business.DTO.Profesional newData = new Business.DTO.Profesional()
            {
                Rutprofesional = tbx_Rutprofesional.Text,
                Primernombre = tbx_Primernombre.Text,
                Segundonombre = tbx_Segundonombre.Text,
                Primerapellido = tbx_Primerapellido.Text,
                Segundoapellido = tbx_Segundoapellido.Text,
                Numerocontacto = tbx_Numerocontacto.Text,

                Isvigente = (dtp_Isvigente.IsChecked ?? false) ? "1" : "0",
            };

            #region Guardar

            if (FlyoutMode.Equals("Add"))
            {
                bool? result = Business.DTO.Profesional.Create(newData);

                switch (result)
                {
                    case true:
                        await _mainWindow.ShowMessageAsync("Profesional Guardado", "");
                        break;

                    case false:
                        await _mainWindow.ShowMessageAsync("Profesional no guardado", "Este profesional ya existe en el sistema.");
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
                bool? result = Business.DTO.Profesional.Update(newData);

                switch (result)
                {
                    case true:
                        await _mainWindow.ShowMessageAsync("Profesional Actualizado", "");
                        break;

                    case false:
                        await _mainWindow.ShowMessageAsync("Profesional no actualizado", "Este profesional no existe en el sistema.");
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
