using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

using Wpf.Ui.Controls;
using Wpf.Ui.Extensions;

namespace UserInterface.Pages
{
    public partial class LoginWindow : Wpf.Ui.Controls.UiWindow
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

            this.RemoveTitlebar();
            this.ApplyBackdrop(Wpf.Ui.Appearance.BackgroundType.Mica);

            handleAlert(Visibility.Hidden, "Error");
        }

        
        private void Login(object sender, RoutedEventArgs e)
        {
            try
            {

                this.username = tbx_Username.Text;
                this.password = pwbx_Password.Text;

                Database.Models.Usuario? user = Business.Usuario.GetUsuario(this.username, this.password);


                //Wpf.Ui.Controls.MessageBox messageBox = new Wpf.Ui.Controls.MessageBox();

                if (user == null)
                {
                    //messageBox.Content = "Error con el usuario.";
                    handleAlert(Visibility.Visible, "Error con el usuario.");
                }
                else
                {
                    if (tbx_Username.Text.Length == 0 || pwbx_Password.Text.Length == 0)
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

                        MainWindow mainWindow = new MainWindow(this.username);
                        mainWindow.Show();
                        this.Close();

                    }
                }


                //messageBox.ShowDialog();
            }
            catch (Exception) { }
            


        }
    }
}
