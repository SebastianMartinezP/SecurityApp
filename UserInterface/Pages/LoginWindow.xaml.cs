using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

using MahApps.Metro.Controls;
using ControlzEx.Theming;

using Business;

namespace UserInterface.Pages
{
    public partial class LoginWindow : MetroWindow
    {
        private string? username { get; set; }
        private string? password { get; set; }


        #region handleAlert

        public void handleAlert(Visibility visibility, string? content)
        {
            stk_Alert.Visibility = visibility;
            lb_Alert.Content = content;
        }

        #endregion

        public LoginWindow()
        {
            InitializeComponent();
            handleAlert(Visibility.Hidden, "Error");
            ThemeManager.Current.ChangeTheme(this, "Dark.Blue");
        }

        
        private void Login(object sender, RoutedEventArgs e)
        {
            try
            {

                this.username = tbx_Username.Text;
                this.password = pwbx_Password.Password;

                Business.DTO.Usuario? user = Business.DTO.Usuario.GetUsuario(this.username, this.password);

                if (user == null || user.Idperfil != 1) // solo admins
                {
                    handleAlert(Visibility.Visible, "Error con el usuario.");
                }
                else
                {
                    if (tbx_Username.Text.Length == 0 || pwbx_Password.Password.Length == 0)
                    {
                        handleAlert(Visibility.Visible, "Datos faltantes.");
                    }
                    else if (user.Correo == null || user.Contrasenahashed == null)
                    {
                        handleAlert(Visibility.Visible, "Usuario no existe.");
                    }
                    else
                    {
                        handleAlert(Visibility.Visible, "Login exitoso");

                        MainWindow mainWindow = new MainWindow(user);
                        mainWindow.Show();
                        this.Close();

                    }
                }
            }
            catch (Exception) { }
            


        }
    }
}
