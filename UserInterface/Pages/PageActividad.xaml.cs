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
using Business.Util;
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
            SetupComboboxes();
            _mainWindow = mainWindow;
        }

        public async void SetupDatagrid()
        {
            try
            {
                data = Business.DTO.Actividad.ReadAll();
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
                List<Business.DTO.TipoActividad>? tipoActividadList = 
                    Business.DTO.TipoActividad.ReadAll();
                cb_Tipoactividad.ItemsSource = tipoActividadList?.Select(p => p.Descripcion);

            }
            catch (Exception e)
            {
                await _mainWindow.ShowMessageAsync("Error Interno", e.Message);
            }
        }


        private void numericTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, @"[^\d]", "");
        }

        private void Refresh(object sender, RoutedEventArgs e) => SetupDatagrid();


        private bool ValidateFields()
        {
            try
            {
                bool descripcion = ValidationHandler.ValidateString(tbx_Descripcion.Text);
                bool asistentes = ValidationHandler.ValidateString(tbx_Cantidadasistente.Text);
                bool rutProfesional = ValidationHandler.ValidateRut(tbx_Rutprofesional.Text);
                bool rutCliente = ValidationHandler.ValidateRut(tbx_Rutcliente.Text);
                bool direccion = ValidationHandler.ValidateString(tbx_Direccion.Text);
                bool checklist = ValidationHandler.ValidateString(tbx_Checklist.Text);
                
                return 
                    descripcion 
                    && asistentes 
                    && rutProfesional 
                    && rutCliente 
                    && direccion 
                    && checklist;
            }
            catch (Exception)
            {
                return false;
            }
        }

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

            cb_Tipoactividad.SelectedItem = cb_Tipoactividad.Items[0];
            tbx_Rutcliente.Text = "";
            tbx_Rutprofesional.Text = "";
            tbx_Checklist.Text = "";

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

                cb_Tipoactividad.SelectedItem = 
                    Business.DTO.TipoActividad.Read((int)selected.Idtipoactividad).Descripcion;
                tbx_Rutcliente.Text = selected.Rutcliente.ToString();
                tbx_Rutprofesional.Text = selected.Rutprofesional.ToString();
                if (selected.Idcheck != null)
                {
                    tbx_Checklist.Text = 
                        Business.DTO.CheckList.Read((int)selected.Idcheck).Descripcion;
                }
                

            }

            // deshabilitamos campos clave
            tbx_Idactividad.IsReadOnly = true;
            tbx_Idactividad.IsEnabled = false;
            tbx_Fecharegistro.IsReadOnly = true;
            tbx_Fecharegistro.IsEnabled = false;
            tbx_Rutcliente.IsReadOnly = true;
            tbx_Rutcliente.IsEnabled = false;
            tbx_Checklist.IsReadOnly = true;
            tbx_Checklist.IsEnabled = false;



            Flyout.IsOpen = true;
        }


        private void datagrid_SelectedCellsChanged(object sender, 
            SelectedCellsChangedEventArgs e)
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
                Idtipoactividad = 
                Business.DTO.TipoActividad
                .Read(cb_Tipoactividad.SelectedItem.ToString()).Idtipoactividad,
                Rutprofesional = tbx_Rutprofesional.Text,
            };

            newData.Idcheck = 
                tbx_Checklist.Text != null ? 
                Business.DTO.CheckList.Read(tbx_Checklist.Text).Idcheck : null;

            #region Guardar

            if (FlyoutMode.Equals("Add"))
            {
                if (!ValidateFields())
                {
                    await _mainWindow.ShowMessageAsync("Alerta", 
                        "Hay datos faltantes, por favor ingrese nuevamente.");
                }
                else
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
                    Flyout.IsOpen = false;
                }
            }

            #endregion

            #region Editar

            else
            {
                if (!ValidateFields())
                {
                    await _mainWindow.ShowMessageAsync("Alerta", 
                        "Hay datos faltantes, por favor ingrese nuevamente.");
                }
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
