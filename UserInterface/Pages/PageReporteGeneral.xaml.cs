using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;
using System.Windows.Controls;

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.ComponentModel;
using System.Drawing;
using Syncfusion.Pdf.Grid;
using System.Data;
using Business.DTO;

namespace UserInterface.Pages
{
    public partial class PageReporteGeneral : Page
    {
        public Page _mainPage { get; set; }
        public MainWindow _mainWindow { get; set; }
        List<ReportClienteContratoModel>? dataClientes { get; set; }
        public ReportClienteContratoModel? selected { get; set; }

        public PageReporteGeneral(Page mainPage, MainWindow mainwindow)
        {
            InitializeComponent();
            _mainPage = mainPage;
            _mainWindow = mainwindow;
            SetupReporteGeneral();
            SetupReporteCliente();
        }

        public void SetupReporteGeneral()
        {
            try
            {
                // contratos
                List<Business.DTO.Contrato>? data = Business.DTO.Contrato.ReadAll();
                datagrid.Items.Refresh();

                int cantPorCaducar = 0;

                // estado de los contratos
                foreach (Business.DTO.Contrato contrato in data)
                {

                    double daysDiff = (contrato.Fechacontrato.AddMonths(1).AddDays(-10) - DateTime.Today).TotalDays;
                    if (daysDiff < 10 && daysDiff > 0) // temporada de aviso (10 días)
                    {
                        cantPorCaducar++;
                    }
                }

                lb_CountPorCaducar.Content = cantPorCaducar.ToString();

                lb_CountTotal.Content = data
                    .Where(x => 
                        x.Fechacontrato.Month == DateTime.Today.Month
                        && x.Fechacontrato.Year == DateTime.Today.Year
                    ).Count();

                lb_CountVigentes.Content = data
                    .Where(x => 
                    x.Vigente.Equals("1")
                        && x.Fechacontrato.Month == DateTime.Today.Month
                        && x.Fechacontrato.Year == DateTime.Today.Year
                    ).Count(); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void SetupReporteCliente()
        {
            try
            {
                using (Database.Models.ModelContext context = new Database.Models.ModelContext())
                {
                    
                    var contratos = context.Contrato
                        .Where(x => 
                            x.Fechacontrato.Month == DateTime.Today.Month
                            && x.Fechacontrato.Year == DateTime.Today.Year)
                        .ToList();

                    var clientes = context.Cliente
                        .Where( x =>
                            contratos.Select(c => c.Rutcliente)
                            .ToList().Contains(x.Rutcliente)
                        ).ToList();

                    var rubros = context.Rubro.ToList();

                    dataClientes = new List<ReportClienteContratoModel>();

                    contratos.ForEach(c =>
                    {
                        dataClientes.Add(new ReportClienteContratoModel()
                        {
                            Rutcliente = c.Rutcliente,
                            Razonsocial = clientes.Find(cl => cl.Rutcliente.Equals(c.Rutcliente))?.Razonsocial,
                            Rubro = rubros
                            .Find(r => 
                                r.Idrubro.Equals(   clientes.Find(cl => cl.Rutcliente.Equals(c.Rutcliente)  ).Idrubro
                                )
                            ).Descripcion,
                            Asesorias = c.Asesoria ?? 0,
                            AsesoriasDisponible = c.AsesoriaDisponible ?? 0,
                            AsesoriasExtra = c.AsesoriaExtra ?? 0,
                            Capacitaciones = c.Capacitacion ?? 0,
                            CapacitacionesDisponible = c.CapacitacionDisponible ?? 0,
                            CapacitacionesExtra = c.CapacitacionExtra ?? 0,
                            
                            
                        });
                    });


                    datagrid.DataContext = dataClientes;
                    datagrid.Items.Refresh();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        private void datagrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            selected = (ReportClienteContratoModel)datagrid.SelectedItem;
            btn_GenerarReporteClientePDF.IsEnabled = datagrid.SelectedItem != null ? true : false;
        }

        private async void btn_GenerarReporteGeneralPDF_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (PdfDocument document = new PdfDocument())
                {
                    //Set the standard font
                    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
                    //Add a page to the document
                    PdfPage page = document.Pages.Add();

                    //Create PDF graphics for a page
                    PdfGraphics graphics = page.Graphics;

                    PdfGrid grid = new PdfGrid();
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Métricas");
                    dataTable.Columns.Add("Valor");

                    dataTable.Rows.Add(new object[] { "Contratos totales", lb_CountTotal.Content });
                    dataTable.Rows.Add(new object[] { "Contratos por caducar", lb_CountPorCaducar.Content });
                    dataTable.Rows.Add(new object[] { "Contratos vigentes", lb_CountVigentes.Content });

                    grid.DataSource = dataTable;

                    graphics.DrawString("Reporte General", font, PdfBrushes.Black, new PointF(30, 0));

                    grid.Draw(page, new PointF(10, 50));

                    //Save the document
                    document.Save(string.Format("ReporteGeneral.pdf"));
                }
                await this._mainWindow.ShowMessageAsync("Reporte General", "PDF Generado.");
            }
            catch (Exception ex)
            {
                await this._mainWindow.ShowMessageAsync("Reporte General", "Error al generar PDF." + ex.Message);
            }
        }

        private async void btn_GenerarReporteClientePDF_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (PdfDocument document = new PdfDocument())
                {
                    //Set the standard font
                    PdfFont bigFont = new PdfStandardFont(PdfFontFamily.Helvetica, 15);
                    PdfFont smallFont = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
                    //Add a page to the document
                    PdfPage page = document.Pages.Add();

                    //Create PDF graphics for a page
                    PdfGraphics graphics = page.Graphics;

                    PdfGrid grid = new PdfGrid();
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Métricas");
                    dataTable.Columns.Add("Valor");

                    dataTable.Rows.Add(new object[] { "Asesorías",              selected?.Asesorias.ToString() ?? "0" });
                    dataTable.Rows.Add(new object[] { "Asesorías disponibles",  selected?.AsesoriasDisponible.ToString() ?? "0" });
                    dataTable.Rows.Add(new object[] { "Asesorías extra",        selected?.AsesoriasExtra.ToString() ?? "0" });
                    dataTable.Rows.Add(new object[] { "Capacitaciones",         selected?.Capacitaciones.ToString() ?? "0" });
                    dataTable.Rows.Add(new object[] { "Capacitaciones disponibles", selected?.CapacitacionesDisponible.ToString() ?? "0" });
                    dataTable.Rows.Add(new object[] { "Capacitaciones extra",       selected?.CapacitacionesExtra.ToString() ?? "0" });

                    grid.DataSource = dataTable;

                    graphics.DrawString("Reporte Cliente", bigFont, PdfBrushes.Black, new PointF(30, 0));

                    graphics.DrawString("Rut: " + selected?.Rutcliente, smallFont, PdfBrushes.Black, new PointF(10, 15));
                    graphics.DrawString("Razón social: " + selected?.Razonsocial, smallFont, PdfBrushes.Black, new PointF(10, 25));

                    grid.Draw(page, new PointF(10, 40));

                    //Save the document
                    document.Save(string.Format("ReporteCliente"+ selected?.Rutcliente +".pdf"));
                }
                await this._mainWindow.ShowMessageAsync("Reporte Cliente", "PDF Generado.");
            }
            catch (Exception)
            {
                await this._mainWindow.ShowMessageAsync("Reporte Cliente", "Error al generar PDF.");
            }
        }
    }

    public static class PDF
    {
        public static bool? CreatePDF()
        {
            try
            {
                using (PdfDocument document = new PdfDocument())
                {
                    //Add a page to the document
                    PdfPage page = document.Pages.Add();

                    //Create PDF graphics for a page
                    PdfGraphics graphics = page.Graphics;

                    //Set the standard font
                    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

                    //Draw the text
                    graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));

                    //Save the document
                    document.Save("Output.pdf");
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
