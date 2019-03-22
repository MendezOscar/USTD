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

namespace USTED
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        dba dba;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ActiveDirectoryUtility ADUtility = new ActiveDirectoryUtility();
            bool PermitirAcceso = ADUtility.AllowLogIn(txtUsuario.Text, txtContrasena.Password.ToString());
            if (PermitirAcceso)
            {
                dba = new dba();
                if (dba.Buscarusuario(txtUsuario.Text))
                {
                    this.Hide();
                    usd usd = new usd();
                    usd.Show();
                }
                else
                {
                    MessageBox.Show("Usuario no tiene permisos");
                }
                
            } else
            {
                MessageBox.Show("Usuario no existe");
            }
            
        }

        private void TxtContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ActiveDirectoryUtility ADUtility = new ActiveDirectoryUtility();
                bool PermitirAcceso = ADUtility.AllowLogIn(txtUsuario.Text, txtContrasena.Password.ToString());
                if (PermitirAcceso)
                {
                    dba = new dba();
                    if (dba.Buscarusuario(txtUsuario.Text))
                    {
                        this.Hide();
                        usd usd = new usd();
                        usd.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuario no tiene permisos");
                    }

                }
                else
                {
                    MessageBox.Show("Usuario no existe");
                }
            }
        }
    }
}
