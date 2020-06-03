using System;
using System.Collections.Generic;
using System.Text;
using ItlaMarket.MantenimientoDeClientes.Repositorio;
using ItlaMarket.CarritoVenta.Repositorio;

namespace ItlaMarket
{
    class VerFactura
    {
        RepositorioClientes repositorioClientes
        {
            get => RepositorioClientes.Instancia;
        }
        
        

        public void ImprimirMenu()
        {
            Console.WriteLine("Ingresa el nombre del cliente que desea ver la factura");
            var nombre =Console.ReadLine();
            Console.Clear();
            var cliente = BuscarClientePorNombre(nombre);
            for (int i = 0; i < cliente.Facturas.Count; i++)
            {
                Console.WriteLine($"{i + 1} {cliente.Facturas[i].FechaFactura}");

            }
            Console.WriteLine("Que factura desea que se muestre");
            var facturaid = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            var factura = cliente.Facturas[facturaid];
            Console.WriteLine($"detalle de la factura {factura.FechaFactura}");
            Console.WriteLine(factura);

        }

        private Cliente BuscarClientePorNombre(string nombre)
        {
            var clientes = repositorioClientes.ConseguirTodos();

            foreach (var cliente in clientes)
            {
                if (cliente.Nombre.ToLower() == nombre.ToLower())
                    return cliente;
            }

            return null;
        }
    }
}
