using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Parcial_02
{
    public class ProductNonQuery
    {
        public static List<Product> getLista()
        {
            string sql = "select * from product";

            DataTable dt = ConnectionDB.ExecuteQuery(sql);

            List<Product> lista = new List<Product>();

            foreach (DataRow fila in dt.Rows)
            {
                Product p = new Product();
                p.name = fila[1].ToString();

                lista.Add(p);
            }

            return lista;
        }

        public static int ProductQueryid(string name)
        {
            
                string query = $"SELECT idProduct FROM product WHERE name = '{name}'";
                var dt = ConnectionDB.ExecuteQuery(query);
                var dr = dt.Rows[0];
                var idProduct = Convert.ToInt32(dr[0]);
                return idProduct;
        }

       
        public static void AddProduct(int idBusiness, string name)
        {
            try
            {
               
                ConnectionDB.ExecuteNonQuery($"INSERT INTO PRODUCT(idBusiness, name) VALUES(" +
                                             //createdate
                                             $"{idBusiness}," +
                                             
                                             //name
                                             $"'{name}')");

                MessageBox.Show("Se ha anadido el producto");

            }
            catch (Exception exception)
            {
                MessageBox.Show("Ha ocurrido un error");
            }

        }
        

        public static void DeleteProduct(string name)
        {
            try
            {

                ConnectionDB.ExecuteNonQuery($"DELETE FROM product " +
                                             $"WHERE name = '{name}'");

                MessageBox.Show("Se ha eliminado el producto");

            }
            catch (Exception exception)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }
    }
}
