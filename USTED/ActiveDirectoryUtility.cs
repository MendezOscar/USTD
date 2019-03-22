using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace USTED
{
    class ActiveDirectoryUtility
    {
        private string domainAD = "", adminAD = "", passAD = "";
        private string scopeOU = "DC=uprivada,DC=edu";

        public string DomainAd
        {
            get { return domainAD; }
            set { domainAD = value; }
        }

        public string AdminAd
        {
            get { return adminAD; }
            set { adminAD = value; }
        }

        public string PassAd
        {
            get { return passAD; }
            set { passAD = value; }
        }

        public ActiveDirectoryUtility()
        {
            try
            {
                string conexion = "Data Source=172.21.10.230;Initial Catalog=NNEC;Persist Security Info=True;User ID=DBMANAGER;Password=Db@ITUSAP";
                SqlConnection conn = new SqlConnection(conexion);
                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable SQLDataTable = new DataTable();

                SqlCommand comandoSQL = new SqlCommand();
                comandoSQL.CommandText = "select * from TABLA_ADMON_AD";
                comandoSQL.CommandType = CommandType.Text;
                comandoSQL.Connection = conn;

                adapter.SelectCommand = comandoSQL;
                adapter.Fill(SQLDataTable);



                DataRow row = SQLDataTable.Rows[0];

                conn.Close();
                domainAD = row["ADPATH"].ToString();
                adminAD = row["ADAdmin"].ToString();
                passAD = row["ADPass"].ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

       public PrincipalContext GetPrincipalContext()
        {

            PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Domain, domainAD, scopeOU, adminAD, passAD);
            return oPrincipalContext;
        }

        public bool AllowLogIn(string user, string password)
        {
            try
            {
                PrincipalContext admin = GetPrincipalContext();

                bool allowed = admin.ValidateCredentials(user, password);
                admin.Dispose();
                return allowed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;
        }
    }
}

