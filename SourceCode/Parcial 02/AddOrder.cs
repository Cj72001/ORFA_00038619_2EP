using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Parcial_02
{
    public partial class AddOrder : UserControl
    {
        public AddOrder()
        {
            InitializeComponent();
        }

        private void AddOrder_Load(object sender, EventArgs e)
        {
            //product
            var products = ConnectionDB.ExecuteQuery("SELECT name FROM product");
            var productsCombo = new List<string>();
            foreach (DataRow dr in products.Rows)
            {
                productsCombo.Add(dr[0].ToString());
            }
            comboBox2.DataSource = productsCombo;
            
            //restaurant
            var Business = ConnectionDB.ExecuteQuery("SELECT name FROM business");
            var businessCombo = new List<string>();
            foreach (DataRow dr in Business.Rows)
            {
                businessCombo.Add(dr[0].ToString());
            }
            comboBox1.DataSource = businessCombo;

        }

        //Pedir
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("")||textBox2.Text.Equals(""))
              
                MessageBox.Show("No se pueden dejar campos vacios");
            

            else
            {
                
                string createdate = textBox1.Text;
                
                //var Product = comboBox2.SelectedItem.ToString();
                string query = $"SELECT idProduct FROM product WHERE name = '{comboBox2.SelectedItem}'";
                var dt = ConnectionDB.ExecuteQuery(query);
                var dr = dt.Rows[0];
                var idProduct = Convert.ToInt32(dr[0]);
                
                //int idUser = UserNonQuery.UserQueryId(textBox2.Text);
                 query = $"SELECT idUser FROM appuser WHERE password = '{textBox2.Text}'";
                 dt = ConnectionDB.ExecuteQuery(query);
                 dr = dt.Rows[0];
                var idUser = Convert.ToInt32(dr[0].ToString());

                //int idAddress = AddressNonQuery.AddressQueryId(idUser);
                 query = $"SELECT idAddress FROM address WHERE idUser = {idUser}";
                 dt = ConnectionDB.ExecuteQuery(query);
                 dr = dt.Rows[0];
                var idAddress = Convert.ToInt32(dr[0].ToString());
                
                
                OrderNonQuery.AddOrder(createdate, idProduct, idAddress);
            }
        }
    }
}