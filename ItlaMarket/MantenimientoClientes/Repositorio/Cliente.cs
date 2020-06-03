using System;
using System.Collections.Generic;
using System.Text;
using ItlaMarket.CarritoVenta.Repositorio;
namespace ItlaMarket.MantenimientoDeClientes.Repositorio
{
    class Cliente
    {
        public string Nombre { get; set; }
        public List<CarritoCompra> Facturas;

        public Cliente(string nombre)
        {
            this.Nombre = nombre;

            Facturas = new List<CarritoCompra>();
        }
    }
}
