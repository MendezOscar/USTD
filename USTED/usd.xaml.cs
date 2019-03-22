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
using System.Windows.Shapes;

namespace USTED
{
    /// <summary>
    /// Lógica de interacción para usd.xaml
    /// </summary>
    public partial class usd : Window
    {
        dba dba = new dba();
        DateTime hoy = DateTime.Today;
        public usd()
        {
            InitializeComponent();
            txtFax.Text = "0";
            txtTelefono.Text = "0";
            txtTelefonoC.Text = "0";
            txtFax.Text = "0";
            txtCelular.Text = "0";
            dba.Llenarpaises(txtPais);
            txtfechaIngreso.Text = hoy.ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Cliente cliente = EnviarDatos();
            string cuenta = txtCuenta.Text;
            if (cuenta != " ")
            {
                dba.ActualizarDatos(cliente, cuenta);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Inserte numero de cuenta");
            }
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) => Limpiar();

        
        private void TxtCuenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string cuentaalumno = txtCuenta.Text;
                Cliente clientes = dba.Llenaralumno(cuentaalumno);
                if (clientes != null)
                {
                    SetearDatos(clientes);
                    string pais = txtPais.Text;
                    dba.Llenardepartamento(txtDepartamento, pais);

                    string departamento = txtDepartamento.Text;
                    dba.Llenarmunicipios(txtMunicipio, departamento);

                    string depto = txtDepartamento.Text;
                    string municipio = txtMunicipio.Text;
                    dba.Llenarcolonia(txtColonia, municipio, depto);
                }
                else
                {
                    MessageBox.Show("Cliente no existe...");
                }
                
            }
        }

        private void Limpiar()
        {
            txtUbicacion.Text = String.Empty;
            txtTelefono.Text = "0";
            txtCelular.Text = "0";
            txtFax.Text = "0";
            txtEmail1.Text = String.Empty;
            txtEmail2.Text = String.Empty;
            txtCompañia.Text = String.Empty;
            txtDireccion.Text = String.Empty;
            txtTelefonoC.Text = "0";
            txtEmail.Text = String.Empty;
            txtPuesto.Text = String.Empty;
            txtDepto.Text = String.Empty;
            txtNivelacademico.Text = String.Empty;
            txtComentarios.Text = String.Empty;
            txtDepartamento.Items.Clear();
            txtMunicipio.Items.Clear();
            txtColonia.Items.Clear();
        }

        public void SetearDatos(Cliente cliente)
        {
            txtUbicacion.Text = cliente.Direccion;
            if(cliente.Telefono1 == "")
            {
                txtTelefono.Text = "0";
            }
            else
            {
                txtTelefono.Text = cliente.Telefono1.ToString();
            }
            if (cliente.Telefono2 == "")
            {
                txtCelular.Text = "0";
            }
            else
            {
                txtCelular.Text = cliente.Telefono2.ToString();
            }

            if (cliente.Fax == "")
            {
                txtFax.Text = "0";
            }
            else
            {
                txtFax.Text = cliente.Fax.ToString();
            }
            
            txtEmail1.Text = cliente.Email1;
            txtEmail2.Text = cliente.Email2;
            txtCompañia.Text = cliente.Compañia;
            txtDireccion.Text = cliente.Direccioncompañia;
            if (cliente.Telefonocompañia == "")
            {
                txtTelefonoC.Text = "0";
            }
            else
            {
                txtTelefonoC.Text = cliente.Telefonocompañia.ToString();
            }
            
            txtEmail.Text = cliente.Emailcompañia;
            txtPuesto.Text = cliente.Puesto;
            txtDepto.Text = cliente.Departamentocompañia;
            txtNivelacademico.Text = cliente.Nivelacademico;
            txtComentarios.Text = cliente.Comentarios;
            txtDepartamento.SelectedItem = cliente.Departamento;
            txtMunicipio.SelectedItem = cliente.Municipio;
            txtPais.SelectedItem = cliente.Pais;
            txtfechaIngreso.Text = cliente.Fechaingreso;
            txtColonia.SelectedItem = cliente.Colonia;
        }

        public Cliente EnviarDatos()
        {
            Cliente cliente = null;
            string telefono1;
            string telefono2;
            string telefonoc;
            string nuevaFecha = " ";
            string Colonia = " ";
            string fax;
            string ubicacion = txtUbicacion.Text;

            if(txtTelefono.Text != " ")
            {
                 telefono1 = txtTelefono.Text;
            }else
            {
                 telefono1 = "0";
            }
            if (txtCelular.Text != null)
            {
                telefono2 = txtCelular.Text;
            }
            else
            {
                telefono2 = "0";
            }
            if (txtFax.Text != null)
            {
                fax = txtFax.Text;
            }
            else
            {
                fax = "0";
            }
            string email1 = txtEmail1.Text;
            string email2 = txtEmail2.Text;
            string compañia = txtCompañia.Text;
            string dircompañia = txtDireccion.Text;
            if (txtTelefonoC.Text != " ")
            {
                telefonoc = txtTelefonoC.Text;
            }
            else
            {
                telefonoc = "0";
            }
            string emailc = txtEmail.Text;
            string puesto = txtPuesto.Text;
            string depto = txtDepto.Text;
            string nivelacademico = txtNivelacademico.Text;
            string comentarios = txtComentarios.Text;
            string departamento = txtDepartamento.SelectedItem.ToString();
            string municipio = txtMunicipio.SelectedItem.ToString();
            string pais = txtPais.SelectedItem.ToString();
            string fechaingreso = txtfechaIngreso.Text;
            if (fechaingreso == "")
            {
                string fecha2 = hoy.ToString("d");
                var fecha2part = fecha2.Split('/');
                nuevaFecha = fecha2part[2] + '-' + fecha2part[1] + '-' + fecha2part[0];
            }
            else
            {
                var dateParts = fechaingreso.Split('/');
                nuevaFecha = dateParts[2] + '-' + dateParts[1] + '-' + dateParts[0];
            }
            if (txtColonia.SelectedItem == null)
            {
                Colonia = " ";
            }
            else
            {
                Colonia = txtColonia.SelectedItem.ToString();
            }
            cliente = new Cliente(ubicacion, pais, departamento, municipio, telefono1, telefono2, fax, email1, email2,
                compañia, dircompañia, telefonoc, emailc, puesto, depto,nivelacademico, nuevaFecha, comentarios, Colonia);
            return cliente;
        }

        private void TxtColonia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TxtDepartamento_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string pais = txtPais.Text;
            dba.Llenardepartamento(txtDepartamento, pais);
        }

        private void TxtMunicipio_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string departamento = txtDepartamento.Text;
            dba.Llenarmunicipios(txtMunicipio, departamento);
        }

        private void TxtColonia_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string depto = txtDepartamento.Text;
            string municipio = txtMunicipio.Text;
            dba.Llenarcolonia(txtColonia, municipio, depto);
        }
    }
 }

