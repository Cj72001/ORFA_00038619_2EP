using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Parcial_02
{
    public class BusinessNonQuery
    {
        public static List<BUSINESS> getLista()
        {
            string sql = "select * from business";

            DataTable dt = ConnectionDB.ExecuteQuery(sql);

            List<BUSINESS> lista = new List<BUSINESS>();
            
            foreach (DataRow fila in dt.Rows)
            {
                BUSINESS b = new BUSINESS();
                b.name = fila[1].ToString();
                b.description = fila[2].ToString();
               
                lista.Add(b);
            }
            return lista;
        }

        public static int BusinessQuery(string name)
        {
            var idBusiness = 0;
            try
            {
                string query = $"SELECT idBusiness FROM business WHERE name = '{name}'";
                var dt = ConnectionDB.ExecuteQuery(query);
                var dr = dt.Rows[0];
                idBusiness = Convert.ToInt32(dr[0].ToString());
            }
                        
            catch (Exception exception)
            {
                MessageBox.Show("Ha ocurrido un problema");
            }
            return idBusiness;
        }
        

        public static void AddBusiness(string name, string description)
        {
            try
            {
                ConnectionDB.ExecuteNonQuery($"INSERT INTO BUSINESS (name, description) VALUES("  +
                                             //name
                                             $"'{name}'," + 
                                                     
                                             //description
                                             $"'{description}')");
            
                MessageBox.Show("Se ha creado el negocio");
                
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
            
        }

        public static void DeleteBusiness(string name)
        {
            try
            {
                
                ConnectionDB.ExecuteNonQuery($"DELETE FROM business " +
                                               $"WHERE name = '{name}'"); 
            
                MessageBox.Show("Se ha eliminado el negocio");
                
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }
    }
}