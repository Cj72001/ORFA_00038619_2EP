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

                var Product = comboBox2.SelectedItem.ToString();
                int idProduct = ProductNonQuery.ProductQueryid(Product);
                int idUser = UserNonQuery.UserQueryId(textBox2.Text); 
                int idAddress = AddressNonQuery.AddressQueryId(idUser);

                OrderNonQuery.AddOrder(createdate, idProduct, idAddress);
            }
        }
    }
}