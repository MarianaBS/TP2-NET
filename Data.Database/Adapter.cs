using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;




namespace Data.Database
{
    public class Adapter
    {
        
        const string consKeyDefaultCnnString = "ConnStringLocal";
       
       
        private SqlConnection _sqlConn;

        public SqlConnection sqlConn 
        {
            get {return _sqlConn; }
            set {_sqlConn = value ;}
        }
        protected void OpenConnection()
        {
                
                string conn = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
                sqlConn = new SqlConnection(conn);
                sqlConn.Open();
        }
        protected void CloseConnection()
        {
            sqlConn.Close();
            sqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
