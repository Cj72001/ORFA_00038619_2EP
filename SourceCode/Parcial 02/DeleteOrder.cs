using System;
using System.Windows.Forms;

namespace Parcial_02
{
    public partial class DeleteOrder : UserControl
    {
        public DeleteOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                ConnectionDB.ExecuteNonQuery($"DELETE FROM order " +
                                               $"WHERE createdate = '{textBox1.Text}'"); 
            
                MessageBox.Show("Se ha eliminado la orden");
                
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }
    }
}