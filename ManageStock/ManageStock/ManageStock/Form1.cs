using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using ManageStock.Operations;
using ManageStock.Entity;
using System.Text.RegularExpressions;

namespace ManageStock
{
   

    public partial class Form1 : Form
    {
        private int MessageCounter = 1;
        List<string> Message = new List<string>();
        AddProduct AddProduct = new AddProduct();

        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stockDataSet1.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter1.Fill(this.stockDataSet1.Table);
            // TODO: This line of code loads data into the 'stockDataSet.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter.Fill(this.stockDataSet.Table);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            product Product = new product();

            Product.Name = "" + NameP.Text;
            Product.Amount = Convert.ToInt32(Amount.Value);
            Product.Price = float.Parse(Price.Text);


            Thread thread = new Thread(new ParameterizedThreadStart(AddProduct.AddProductToDataBase));
            thread.Start(Product);
            PutMessageInContainer();

            this.tableAdapterManager.UpdateAll(this.stockDataSet);
        }

        private void tableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.stockDataSet);
            this.tableTableAdapter.Fill(this.stockDataSet.Table);

        }

        private void tableDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tableTableAdapter1.Fill(this.stockDataSet1.Table);
            Edit.Visible = true;

            Add.Visible =true;
       
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add.Visible = true;
            Edit.Visible = false;
         
        }

        private void PutMessageInContainer() 
        {

            ListViewItem liv = new ListViewItem("" + MessageCounter++);
            liv.SubItems.Add("Done !!!");
            liv.SubItems.Add("sdkjhfkjsdhf");
            MessageContainer.Items.Add(liv);
        }

        private void tableDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        
    }
}
