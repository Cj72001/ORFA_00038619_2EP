using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparcial.Modelo
{
    public class Inventario
    {
        //Correcion: Declarar publico atributo idArticulo 
        public string idArticulo { get; }
        
        //Correcion: Declarar publico atributo producto
        public string producto { get; set; }
         string descripcion { get; }
         string precio { get; }
         string stock { get; }

        public Inventario(string idArticulo, string producto, string descripcion, string precio, string stock)
        {
            this.idArticulo = idArticulo;
            this.producto = producto;
            this.descripcion = descripcion;
            this.precio = precio;
            this.stock = stock;
        }
    }
}
