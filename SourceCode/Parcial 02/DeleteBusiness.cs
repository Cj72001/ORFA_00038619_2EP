using System;
using System.Windows.Forms;

namespace Parcial_02
{
    public partial class DeleteBusiness : UserControl
    {
        public DeleteBusiness()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(textBox1.Text.Equals(""))
                MessageBox.Show("No se pueden dejar campos vacios");
            
            else
                BusinessNonQuery.DeleteBusiness(textBox1.Text);
        }
    }
}