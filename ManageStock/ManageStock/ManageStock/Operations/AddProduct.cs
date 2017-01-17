using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ManageStock.DataBase;
using ManageStock.Entity;

namespace ManageStock.Operations
{
    class AddProduct
    {
        private SqlConnection Connection = DataBaseConnection.getInstance().getConnect(); // create connection by singilton class
        private String InsertQuery = "INSERT INTO [Table](Name,Amount,Price,Date)VALUES(@Name,@Amount,@Price,@Date);";

        public void AddProductToDataBase(object Product) 
        {

            product pro = (product)Product;
            try
            {
                
                SqlCommand putValue = new SqlCommand(InsertQuery, Connection);
                putValue.Parameters.AddWithValue("@Name", pro.Name.ToString());
                putValue.Parameters.AddWithValue("@Amount", pro.Amount);
                putValue.Parameters.AddWithValue("@Price", pro.Price);
                putValue.Parameters.AddWithValue("@Date",DateTime.Now);
                Connection.Open();
                putValue.ExecuteNonQuery();
               
                MessageBox.Show("The product was saved !! " + pro.Name, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                
            }
            catch (Exception EX)
            {
               MessageBox.Show(EX.StackTrace.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
            finally 
            {
                
                    Connection.Close();
            }

           


        }

    }
}
