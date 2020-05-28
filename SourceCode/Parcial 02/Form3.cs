using System;
using System.Windows.Forms;

namespace Parcial_02
{
    public partial class Form3 : Form
    {
        private UserControl current = null;
        private AddUser addUser = new AddUser();
        private DeleteUser deleteUser = new DeleteUser();
        
        private AddBusiness addBusiness = new AddBusiness();
        private DeleteBusiness deleteBusiness = new DeleteBusiness();
        
        private AddProduct addProduct = new AddProduct();
        private DeleteProduct deleteProduct = new DeleteProduct();
        
        
        
        public Form3()
        {
            InitializeComponent();
            current = addUser;
        }



        //AddUser
        private void button5_Click(object sender, EventArgs e)
        {
            tableLayoutPanel2.Controls.Remove(current);
            tableLayoutPanel2.Controls.Add(addUser, 0, 1);
            current = addUser;
            tableLayoutPanel2.SetColumnSpan(current, 4);
        }

        //DeleteUser
        private void button3_Click(object sender, EventArgs e)
        {
            tableLayoutPanel2.Controls.Remove(current);
            tableLayoutPanel2.Controls.Add(deleteUser, 0, 1);
            current = deleteUser;
            tableLayoutPanel2.SetColumnSpan(current, 4);
        }
        
        
        //AddProduct

        private void button6_Click(object sender, EventArgs e)
        {
            tableLayoutPanel5.Controls.Remove(current);
            tableLayoutPanel5.Controls.Add(addProduct, 0, 1);
            current = addProduct;
            tableLayoutPanel5.SetColumnSpan(current, 4);
        }
        
        //DeleteProduct

        private void button7_Click(object sender, EventArgs e)
        {
            tableLayoutPanel5.Controls.Remove(current);
            tableLayoutPanel5.Controls.Add(deleteProduct, 0, 1);
            current = deleteProduct;
            tableLayoutPanel5.SetColumnSpan(current, 4);
        }

        
        //Orders
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = ConnectionDB.ExecuteQuery($"SELECT usu.fullname, pro.name, busi.name " +
                                                     "FROM APPUSER usu, PRODUCT pro, BUSINESS busi, APPORDER ord, ADDRESS ad " +
                                                     $"WHERE ord.idAddress = ad.idAddress " +
                                                     $"AND pro.idProduct = ord.idProduct ");

                dataGridView2.DataSource = dt;
                MessageBox.Show("Datos actualizados");
            }
                        
            catch (Exception exception)
            {
                MessageBox.Show("Ha ocurrido un problema");
            }
        }


        //DeleteBusiness
        private void button2_Click_1(object sender, EventArgs e)
        {
            tableLayoutPanel4.Controls.Remove(current);
            tableLayoutPanel4.Controls.Add(deleteBusiness, 0, 1);
            current = deleteBusiness;
            tableLayoutPanel4.SetColumnSpan(current, 4);
        }
        
        //AddBusiness
        
                private void button1_Click(object sender, EventArgs e)
                {
                    tableLayoutPanel4.Controls.Remove(current);
                    tableLayoutPanel4.Controls.Add(addBusiness, 0, 1);
                    current = addBusiness;
                    tableLayoutPanel4.SetColumnSpan(current, 4);
                }
        
        
    }

}