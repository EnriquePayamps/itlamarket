using ItlaMarket.MantenimientoProductos.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaMarket.CarritoVenta.Repositorio
{
    class CarritoItem
    {
        public int Cantidad;
        public Producto Producto;

        public CarritoItem(int cantidad, Producto producto)
        {
            this.Cantidad = cantidad;
            this.Producto = producto;
        }

        public float Total
        {
            get => Producto.Precio * Cantidad;
        }

        public override string ToString()
        {
            return $"{Producto.Nombre} | ${Producto.Precio} | {Cantidad} | ${Total}"; 
        }
    }
}
