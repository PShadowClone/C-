using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ManageStock.DataBase
{
    public class DataBaseConnection
    {

        private static DataBaseConnection connection = null;
        private static SqlConnection connect = null;
        private static string ConnectionLinke = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=""C:\Users\P.Amr Saidam\documents\visual studio 2012\Projects\ManageStock\ManageStock\DataBase\Stock.mdf"";Integrated Security=True";


        private DataBaseConnection() { connect = new SqlConnection(ConnectionLinke); }

        public static DataBaseConnection getInstance() 
        {
            if (connection == null)
                connection = new DataBaseConnection();
            return connection;
        }

        public SqlConnection getConnect() 
        {
            if (connect == null)
                connect = new SqlConnection(ConnectionLinke);
            return connect;
                
            
            
        }
    }
}
