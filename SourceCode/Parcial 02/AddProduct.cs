using System;
using System.Windows.Forms;

namespace Parcial_02
{
    public partial class AddProduct : UserControl
    {
        public AddProduct()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Equals("") ||
                textBox2.Text.Equals(""))

            {
                MessageBox.Show("No se pueden dejar campos vacios");
            }

            else
            {
                
                int idBusiness = BusinessNonQuery.BusinessQuery(textBox2.Text);
               
                ProductNonQuery.AddProduct(idBusiness, textBox1.Text);
                
            }
        }
    }
}