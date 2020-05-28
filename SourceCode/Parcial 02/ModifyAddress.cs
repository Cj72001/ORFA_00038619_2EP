using System;
using System.Windows.Forms;

namespace Parcial_02
{
    public partial class ModifyAddress : UserControl
    {
        public ModifyAddress()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Equals("") || textBox2.Text.Equals(""))
                MessageBox.Show("No se pueden dejar campos vacios");

            else
            {
                int idUser = UserNonQuery.UserQueryId(textBox2.Text);
                AddressNonQuery.ModifyAddress(idUser, textBox1.Text);
                
            }
        }
    }
}