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
namespace UserInterface.Pages
{
    /// <summary>
    /// Interaction logic for PageUsuario.xaml
    /// </summary>
    public partial class PageUsuario : Page
    {
        public List<Business.DTO.Usuario>? usuarios { get; set; }


        public PageUsuario()
        {
            InitializeComponent();
            listUsuarios();
        }



        public void listUsuarios()
        {
            usuarios = Business.DTO.Usuario.GetAllUsuario();
            DataGridUsuarios.DataContext = usuarios;
            DataGridUsuarios.Items.Refresh();
        }
    }
}
