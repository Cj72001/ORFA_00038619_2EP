using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Parcial_02
{
    public class OrderNonQuery
    {
        public static List<Order> getLista()
        {
            string sql = "select * from apporder";

            DataTable dt = ConnectionDB.ExecuteQuery(sql);

            List<Order> lista = new List<Order>();

            foreach (DataRow fila in dt.Rows)
            {
                
                Order o = new Order();
                o.createDate = fila[1].ToString();

                lista.Add(o);
            }

            return lista;
            
            
        }
        
        //agregarOrder
        public static void AddOrder(string date, int idProduct, int idAddress)
                {
                    try
                    {
                       
                        ConnectionDB.ExecuteNonQuery($"INSERT INTO APPORDER(date, idProduct, idAddress) VALUES(" +
                                                     //createdate
                                                     $"'{date}'," +
                                                     
                                                     //idProduct
                                                     $"{idProduct}," +
        
                                                     //idAddress
                                                     $"'{idAddress}')");
        
                        MessageBox.Show("Se ha creado el negocio");
        
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Ha ocurrido un error");
                    }
        
                }
    }
}