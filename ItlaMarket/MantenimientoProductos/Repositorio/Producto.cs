using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaMarket.MantenimientoProductos.Repositorio
{
    public class Producto
    {
        public  string Nombre { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }

        public Producto (string nombre, int precio , int cantidad)
        {
            this.Nombre = nombre;
            this.Precio = precio;
            this.Cantidad = cantidad;
        }

        public override string ToString()
        {
            return $"{Nombre} | ${Precio} | {Cantidad}";
        }

    }
}
