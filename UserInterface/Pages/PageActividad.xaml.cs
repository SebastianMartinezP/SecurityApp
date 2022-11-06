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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace UserInterface.Pages
{
    /// <summary>
    /// Interaction logic for PageActividad.xaml
    /// </summary>
    public partial class PageActividad : Page
    {
        public MainWindow _mainWindow { get; set; }

        public List<Business.DTO.Actividad>? data { get; set; }
        public Business.DTO.Actividad? selected { get; set; }
        public string FlyoutMode = "";

        public PageActividad(MainWindow mainWindow)
        {
            InitializeComponent();
            SetupDatagrid();
            _mainWindow = mainWindow;
        }

        public async void SetupDatagrid()
        {
            try
            {
                data = Business.DTO.Actividad.ReadAllActividad();
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

            tbx_Idactividad.Text = "";
            tbx_Descripcion.Text = "";
            tbx_Direccion.Text = "";

            dtp_Fechainicio.SelectedDate = DateTime.Today;
            dtp_Fechatermino.SelectedDate = DateTime.Today.AddMonths(1); // contrato por defecto dura 1 mes
            tp_Horainicio.SelectedDateTime = DateTime.Now;
            tp_Horatermino.SelectedDateTime = DateTime.Now;

            tbx_Cantidadasistente.Text = "";
            tbx_Fecharegistro.Text = DateTime.Today.ToString();

            tbx_Idtipoactividad.Text = "";
            tbx_Rutcliente.Text = "";
            tbx_Rutprofesional.Text = "";
            tbx_Idcheck.Text = "";

            // deshabilitamos campos clave
            tbx_Idactividad.IsReadOnly = true;
            tbx_Idactividad.IsEnabled = false;
            tbx_Fecharegistro.IsReadOnly = true;
            tbx_Fecharegistro.IsEnabled = false;

            Flyout.IsOpen = true;
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            FlyoutMode = "Edit";

            // cargamos los campos en los TextBox

            if (selected != null)
            {
                tbx_Idactividad.Text = selected.Idactividad.ToString();
                tbx_Descripcion.Text = selected.Descripcion;
                tbx_Direccion.Text = selected.Direccion;

                dtp_Fechainicio.SelectedDate = selected.Fechainicio;
                dtp_Fechatermino.SelectedDate = selected.Fechatermino;
                tp_Horainicio.SelectedDateTime = selected.Horainicio;
                tp_Horatermino.SelectedDateTime = selected.Horatermino;

                tbx_Cantidadasistente.Text = selected.Cantidadasistente.ToString();
                tbx_Fecharegistro.Text = selected.Fecharegistro?.ToString("dd-MM-yyyy");

                tbx_Idtipoactividad.Text = selected.Idtipoactividad.ToString();
                tbx_Rutcliente.Text = selected.Rutcliente.ToString();
                tbx_Rutprofesional.Text = selected.Rutprofesional.ToString();
                tbx_Idcheck.Text = selected.Idcheck.ToString();

            }

            // deshabilitamos campos clave
            tbx_Idactividad.IsReadOnly = true;
            tbx_Idactividad.IsEnabled = false;
            tbx_Fecharegistro.IsReadOnly = true;
            tbx_Fecharegistro.IsEnabled = false;
            tbx_Rutcliente.IsReadOnly = true;
            tbx_Rutcliente.IsEnabled = false;
            tbx_Idcheck.IsReadOnly = true;
            tbx_Idcheck.IsEnabled = false;



            Flyout.IsOpen = true;
        }


        private void datagrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            selected = (Business.DTO.Actividad)datagrid.SelectedItem;

            btn_edit.IsEnabled = datagrid.SelectedItem != null ? true : false;
        }



        #region Botones Aceptar / Cancelar

        private async void Save(object sender, RoutedEventArgs e)
        {

            Business.DTO.Actividad newData = new Business.DTO.Actividad()
            {
                Cantidadasistente = decimal.Parse(tbx_Cantidadasistente.Text),
                Fecharegistro = DateTime.Today,
                Direccion = tbx_Direccion.Text,
                Descripcion = tbx_Descripcion.Text,
                Fechainicio = (dtp_Fechainicio.SelectedDate ?? new DateTime(1999,01,01)),
                Fechatermino = (dtp_Fechatermino.SelectedDate ?? new DateTime(1999,01,01)),
                Horainicio = (tp_Horainicio.SelectedDateTime ?? new DateTime(1999,01,01)),
                Horatermino = (tp_Horatermino.SelectedDateTime ?? new DateTime(1999,01,01)),
                Idtipoactividad = decimal.Parse(tbx_Idtipoactividad.Text),
                Idcheck = decimal.Parse(tbx_Idcheck.Text),
                Rutprofesional = tbx_Rutprofesional.Text,
            };

            #region Guardar

            if (FlyoutMode.Equals("Add"))
            {
                newData.Rutcliente = tbx_Rutcliente.Text;

                bool? result = Business.DTO.Actividad.Create(newData);

                switch (result)
                {
                    case true:
                        await _mainWindow.ShowMessageAsync("Actividad Guardada", "");
                        break;

                    case false:
                        await _mainWindow.ShowMessageAsync("Actividad no guardada",
                            "Esta actividad ya existe en el sistema.");
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
                newData.Idactividad = decimal.Parse(tbx_Idactividad.Text);

                bool? result = Business.DTO.Actividad.Update(newData);

                switch (result)
                {
                    case true:
                        await _mainWindow.ShowMessageAsync("Actividad Actualizada", "");
                        break;

                    case false:
                        await _mainWindow.ShowMessageAsync("Actividad no actualizada",
                            "Esta actividad no existe en el sistema.");
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
