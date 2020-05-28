using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Parcial_02
{
    public partial class Form2 : Form
    {
        private UserControl current = null;
        private AddOrder addOrder = new AddOrder();
        private DeleteOrder deleteOrder = new DeleteOrder();
        
        private AddAddress addAddress = new AddAddress();
        private ModifyAddress modifyAddress = new ModifyAddress();
        private DeleteAddress deleteAddress = new DeleteAddress();
        
        public Form2()
        {
            InitializeComponent();
            current = deleteOrder;
        }


        //Ver ordenes
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = ConnectionDB.ExecuteQuery($"SELECT usu.fullname, pro.name, busi.name " +
                                                     "FROM APPUSER usu, PRODUCT pro, BUSINESS busi, APPORDER ord, ADDRESS ad " +
                                                     $"WHERE ord.idAddress = ad.idAddress " +
                                                     $"AND pro.idProduct = ord.idProduct ");
                 
                    
                 
                

                dataGridView1.DataSource = dt;
                MessageBox.Show("Datos actualizados");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ha ocurrido un problema");
            }
        }

        //AddOrder
        private void button7_Click(object sender, EventArgs e)
        {
            tableLayoutPanel4.Controls.Remove(current);
            tableLayoutPanel4.Controls.Add(addOrder, 0, 1);
            current = addOrder;
            tableLayoutPanel4.SetColumnSpan(current, 4);
        }

        //Delete order
        private void button6_Click(object sender, EventArgs e)
        {
            tableLayoutPanel4.Controls.Remove(current);
            tableLayoutPanel4.Controls.Add(deleteOrder, 0, 1);
            current = deleteOrder;
            tableLayoutPanel4.SetColumnSpan(current, 4);
        }


        //AddAddress
        private void button5_Click(object sender, EventArgs e)
        {
            tableLayoutPanel2.Controls.Remove(current);
            tableLayoutPanel2.Controls.Add(addAddress, 0, 1);
            current = addAddress;
            tableLayoutPanel2.SetColumnSpan(current, 4);
        }
        
        //modifyAddress

        private void button2_Click(object sender, EventArgs e)
        {
            tableLayoutPanel2.Controls.Remove(current);
            tableLayoutPanel2.Controls.Add(modifyAddress, 0, 1);
            current = modifyAddress;
            tableLayoutPanel2.SetColumnSpan(current, 4);
        }
        
        //deleteAddress

        private void button3_Click(object sender, EventArgs e)
        {
            tableLayoutPanel2.Controls.Remove(current);
            tableLayoutPanel2.Controls.Add(deleteAddress, 0, 1);
            current = deleteAddress;
            tableLayoutPanel2.SetColumnSpan(current, 4);
        }
    }
}