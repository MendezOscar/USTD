using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace USTED
{
    class dba
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        DateTime Hoy = DateTime.Today;

        public dba()
        {
            try
            {
                connection = new SqlConnection("Data Source=172.21.10.230;Initial Catalog=NNEC;Persist Security Info=True;User ID=DBMANAGER;Password=Db@ITUSAP");
                connection.Open();
            }
            catch (Exception)
            {
            }
        }

        public void Llenarpaises(ComboBox comboBox)
        {
            string consulta = "SELECT NOMBRE_PAIS FROM PAISES";
            try
            {
                command = new SqlCommand(consulta, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox.Items.Add(reader["NOMBRE_PAIS"].ToString());
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo llenar el combobox" + e.ToString());
            }
        }

        public void Llenarmunicipios(ComboBox comboBox, string departamento)
        {
            string consulta = "SELECT T1.NOMBRE_MUNICIPIO FROM MUNICIPIOS T1 "
                              + " INNER JOIN DEPARTAMENTO T2 ON T2.ID_DEPARTAMENTO = T1.ID_DEPARTAMENTO "
                              + " WHERE T2.NOMBRE_DEPARTAMENTO = @IDDEPTO";
            try
            {
                command = new SqlCommand(consulta, connection);
                command.Parameters.AddWithValue("@IDDEPTO", departamento);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox.Items.Add(reader["NOMBRE_MUNICIPIO"].ToString());
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo llenar el combobox" + e.ToString());
            }
        }

        public void Llenardepartamento(ComboBox comboBox, string pais)
        {

            string consulta = "SELECT NOMBRE_DEPARTAMENTO FROM DEPARTAMENTO T0 "
                               + " INNER JOIN PAISES T1 ON T1.ID_PAIS = T0.ID_PAIS "
                               + " WHERE T1.NOMBRE_PAIS = @IDPAIS";
            try
            {
                command = new SqlCommand(consulta, connection);
                command.Parameters.AddWithValue("@IDPAIS", pais);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox.Items.Add(reader["NOMBRE_DEPARTAMENTO"].ToString());
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo llenar el combobox" + e.ToString());
            }
        }

        public void Llenarcolonia(ComboBox comboBox, string municipio, string departamento)
        {
            int idmunicipio = Buscaridmunicipio(municipio, departamento);
            string consulta = " SELECT T0.DESCRIPCION_COLONIA FROM COLONIA T0 "
                                + " INNER JOIN MUNICIPIOS T1 ON T1.ID_MUNICIPIO = T0.ID_COLONIA "
                                + " WHERE T0.ID_MUNICIPIO = @IDMUNICIPIO";
            try
            {
                command = new SqlCommand(consulta, connection);
                command.Parameters.AddWithValue("@IDMUNICIPIO", idmunicipio);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox.Items.Add(reader["DESCRIPCION_COLONIA"].ToString());
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo llenar el combobox" + e.ToString());
            }
        }

        public Cliente Llenaralumno(string cuentaalumno)
        {
            Cliente clientes = null;
            string consulta = "SELECT T0.DIRECCION, T0.TELEFONO1, T0.TELEFONO2, T0.FAX, T0.EMAIL1, T0.EMAIL2, T0.COMPANIA "
                                + ",T0.DIRECCION_COMPANIA, T0.TELEFONO_COMPANIA, T0.EMAIL_COMPANIA, T0.INGRESO_COMPANIA, " 
                                + " T0.NIVEL_ACADEMICO, T0.COMENTARIOS, T0.PUESTO, T0.DEPARTAMENTO, "
                                + " (SELECT T1.NOMBRE_MUNICIPIO FROM MUNICIPIOS T1 WHERE T0.ID_MUNICIPIO = T1.ID_MUNICIPIO) NOMBRE_MUNICIPIO, "
                                + " (SELECT T2.NOMBRE_DEPARTAMENTO "
                                + " FROM MUNICIPIOS T1 "
                                + " INNER JOIN DEPARTAMENTO T2 ON T2.ID_DEPARTAMENTO = T1.ID_DEPARTAMENTO "
                                + " WHERE T0.ID_MUNICIPIO = T1.ID_MUNICIPIO) NOMBRE_DEPARTAMENTO, "
                                + " (SELECT T3.NOMBRE_PAIS " 
                                + " FROM MUNICIPIOS T1 "
                                + " INNER JOIN DEPARTAMENTO T2 ON T2.ID_DEPARTAMENTO = T1.ID_DEPARTAMENTO "
                                + " INNER JOIN PAISES T3 ON T3.ID_PAIS = T2.ID_PAIS "
                                + " WHERE T0.ID_MUNICIPIO = T1.ID_MUNICIPIO) NOMBRE_PAIS, "
                                + " (SELECT TOP 1 T1.DESCRIPCION_COLONIA FROM COLONIA T1 WHERE "
                                + " T0.ID_COLONIA = T1.ID_COLONIA) DESCRIPCION_COLONIA "
                                + " FROM CLIENTE T0 "
                                + " WHERE CUENTA_ALUMNO = @ID";
            try
            {
                command = new SqlCommand(consulta, connection);
                command.Parameters.AddWithValue("@ID", cuentaalumno);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    clientes = (new Cliente(reader["DIRECCION"].ToString(),
                                                reader["NOMBRE_PAIS"].ToString(),
                                                reader["NOMBRE_DEPARTAMENTO"].ToString(),
                                                reader["NOMBRE_MUNICIPIO"].ToString(),
                                                reader["TELEFONO1"].ToString(),
                                                reader["TELEFONO2"].ToString(),
                                                reader["FAX"].ToString(),
                                                reader["EMAIL1"].ToString(),
                                                reader["EMAIL2"].ToString(),
                                                reader["COMPANIA"].ToString(),
                                                reader["DIRECCION_COMPANIA"].ToString(),
                                                reader["TELEFONO_COMPANIA"].ToString(),
                                                reader["EMAIL_COMPANIA"].ToString(),
                                                reader["PUESTO"].ToString(),
                                                reader["DEPARTAMENTO"].ToString(),
                                                reader["NIVEL_ACADEMICO"].ToString(),
                                                reader["INGRESO_COMPANIA"].ToString(),
                                                reader["COMENTARIOS"].ToString(),
                                                reader["DESCRIPCION_COLONIA"].ToString()));
                }
                reader.Close();
                return clientes;

            }
            catch (Exception e)
            {
                MessageBox.Show("Error \n" + e.ToString());
                Console.WriteLine(e.ToString());
            }
            return null;
        }

        public void ActualizarDatos(Cliente cliente, string cuentaalumno)
        {
            string consulta = "EXEC SP_USTD @CUENTA, @DIRECCION, @DEPARTAMENTO, @MUNICIPIO, @COLONIA, @TEL1, @TEL2, @FAX, @EMAIL1, " +
                "@EMAIL2, @COMPAÑIA, @DIRECCIONC, @TELC, @EMAILC, @PUESTO, @DEPC, @NIVELAC, @INGRESOC, @COMENTARIOS ";
            try
            {
                command = new SqlCommand(consulta, connection);
                command.Parameters.AddWithValue("@CUENTA", cuentaalumno);
                command.Parameters.AddWithValue("@DIRECCION", cliente.Direccion);
                command.Parameters.AddWithValue("@DEPARTAMENTO", cliente.Departamento);
                command.Parameters.AddWithValue("@MUNICIPIO", cliente.Municipio);
                command.Parameters.AddWithValue("@TEL1", cliente.Telefono1);
                command.Parameters.AddWithValue("@TEL2", cliente.Telefono2);
                command.Parameters.AddWithValue("@FAX", cliente.Fax);
                command.Parameters.AddWithValue("@EMAIL1", cliente.Email1);
                command.Parameters.AddWithValue("@EMAIL2", cliente.Email2);
                command.Parameters.AddWithValue("@COMPAÑIA", cliente.Compañia);
                command.Parameters.AddWithValue("@DIRECCIONC", cliente.Direccioncompañia);
                command.Parameters.AddWithValue("@TELC", cliente.Telefonocompañia);
                command.Parameters.AddWithValue("@EMAILC", cliente.Emailcompañia);
                command.Parameters.AddWithValue("@PUESTO", cliente.Puesto);
                command.Parameters.AddWithValue("@DEPC", cliente.Departamentocompañia);
                command.Parameters.AddWithValue("@NIVELAC", cliente.Nivelacademico);
                command.Parameters.AddWithValue("@INGRESOC", cliente.Fechaingreso);
                command.Parameters.AddWithValue("@COMENTARIOS", cliente.Comentarios);
                command.Parameters.AddWithValue("@COLONIA", cliente.Colonia);
                reader = command.ExecuteReader();
                reader.Close();
                MessageBox.Show("Actualizado exitosamente");
            }
            catch(Exception e)
            {
                MessageBox.Show("Error \n" + e.ToString());
                Console.WriteLine(e.ToString());
            }

        }

        public int Buscaridmunicipio(string municipio, string departamento)
        {
            int idmunicipio = 0;
            string consulta = "SELECT T0.ID_MUNICIPIO FROM MUNICIPIOS T0 "
                                + " INNER JOIN DEPARTAMENTO T1 ON T1.ID_DEPARTAMENTO = T0.ID_DEPARTAMENTO "
                                + " WHERE T0.NOMBRE_MUNICIPIO = @MUNICIPIO AND T1.NOMBRE_DEPARTAMENTO = @DEPTOP";
            try
            {
                command = new SqlCommand(consulta, connection);
                command.Parameters.AddWithValue("@MUNICIPIO", municipio);
                command.Parameters.AddWithValue("@DEPTOP", departamento);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    idmunicipio = int.Parse(reader["ID_MUNICIPIO"].ToString());
                }
                reader.Close();
                return idmunicipio;
            }
            catch (Exception e)
            {
                MessageBox.Show("No se encontro el municipio " + e.ToString());
            }
            return idmunicipio;
        }

        public bool Buscarusuario(string usuario)
        {
            string consulta = "SELECT * FROM USTD_ACCESS WHERE USUARIO = @USUARIO";
            try
            {
                command = new SqlCommand(consulta, connection);
                command.Parameters.AddWithValue("@USUARIO", usuario);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    return false;
                }  
                
            }
            catch (Exception e)
            {
                MessageBox.Show("No se encontro el usuario " + e.ToString());
            }
            return false;
        }
    }
}
