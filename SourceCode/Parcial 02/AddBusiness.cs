using System;
using System.Windows.Forms;

namespace Parcial_02
{
    public partial class AddBusiness : UserControl
    {
        public AddBusiness()
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
                BusinessNonQuery.AddBusiness(textBox1.Text, textBox2.Text);
        }
    }
}