using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Parcial_02
{
    public class AddressNonQuery
    {
        public static List<Address> getLista()
        {
            string sql = "select * from address";

            DataTable dt = ConnectionDB.ExecuteQuery(sql);

            List<Address> lista = new List<Address>();

            foreach (DataRow fila in dt.Rows)
            {
                Address a = new Address();
                a.address = fila[2].ToString();

                lista.Add(a);
            }

            return lista;
        }
        
        public static int AddressQueryId(int idUser)
        {
            
                string query = $"SELECT idAddress FROM address WHERE idUser = {idUser}";
                var dt = ConnectionDB.ExecuteQuery(query);
                var dr = dt.Rows[0];
                var idAddress = Convert.ToInt32(dr[0].ToString());
                return  idAddress;
                
        }
            
        
        
        
        //agregarAddress
        public static void AddAddress(string address, int idUser)
        {
            try
            {
               
                ConnectionDB.ExecuteNonQuery($"INSERT INTO ADDRESS(idUser, address) VALUES(" +
                                             //idUser
                                             $"{idUser}," +
                                             //address
                                             $"'{address}')");

                MessageBox.Show("Se ha agregado la direccion");

            }
            catch (Exception exception)
            {
                MessageBox.Show("Ha ocurrido un error");
            }

        }
        
        
        //EliminarAddress
        public static void DeleteAddress(int idUser, string address)
        {
            try
            {

                ConnectionDB.ExecuteNonQuery($"DELETE FROM address " +
                                             $"WHERE idUser = {idUser}");

                MessageBox.Show("Se ha eliminado la direccion");

            }
            catch (Exception exception)
            {
                MessageBox.Show("Ha ocurrido un error");
            }

            
        }
        
        //ModificarAddress
        public static void ModifyAddress(int idUser, string address)
        {
            try
            {
                
                ConnectionDB.ExecuteNonQuery($"UPDATE address " +
                                             $"SET address ='{address}'" +
                                             $"WHERE idUser = {idUser}");
            
                MessageBox.Show("Se ha modificado la direccion");
                
                    
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ha ocurrido un error");
                    
            }
        }
        
        
    }
}