using ItlaMarket.CarritoVenta.Repositorio;
using ItlaMarket.MantenimientoDeClientes.Repositorio;
using ItlaMarket.MantenimientoProductos.Repositorio;
using System;

namespace ItlaMarket
{
    class RealizarVenta : IMenu
    {

        RepositorioClientes repositorioClientes
        {
            get => RepositorioClientes.Instancia;
        }

        IMenu menuAnterior;
        public void Ventas(IMenu menuAnterior)
        {
            this.menuAnterior = menuAnterior;
        }

        public void ImprimirMenu()
        {
            Console.WriteLine("Introdusca el nombre del cliente");
            var nombre = Console.ReadLine();
            Console.Clear();
            var cliente = BuscarClientePorNombre(nombre);

            if (cliente == null)
            {
                Console.WriteLine("Cliente no encontrado por favor intente de nuevo...");
                Console.ReadKey();
                ImprimirMenu();
            }

            var factura = new CarritoCompra();
            cliente.Facturas.Add(factura);

            AnadirProductoCompra(factura);

            Console.WriteLine("Factura generada!");
            Console.WriteLine(cliente.Facturas[cliente.Facturas.Count - 1]);
            Console.ReadKey();
            menuAnterior.ImprimirMenu();
        }

        private void AnadirProductoCompra(CarritoCompra newCompra)
        {
            var repoProducto = RepositorioProducto.Instancia;

            Console.WriteLine(repoProducto);

            Console.WriteLine("Introduce el nombre del producto");
            
            var nombreProducto = Console.ReadLine();

            var producto = BuscarProductoPorNombre(nombreProducto);

            if(producto == null)
            {
                Console.WriteLine("Producto no encontrado intente nuevamente...");
                Console.ReadKey();

                AnadirProductoCompra(newCompra);
            }
            else
            {

                int cantidadProducto = 0;
                while(cantidadProducto <= 0)
                {
                    Console.WriteLine($"Tenemos {producto.Cantidad} {producto.Nombre}, cuantos deseas:");
                    if(int.TryParse(Console.ReadLine(), out cantidadProducto))
                    {
                        if(cantidadProducto <= producto.Cantidad)
                        {
                            newCompra.Anadir(new CarritoItem(cantidadProducto, producto));
                            producto.Cantidad -= cantidadProducto;

                            Console.WriteLine("Producto agregado a factura, desea algo mas? [S/N]");
                            var key = Console.ReadKey();
                            if (key.Key == ConsoleKey.S) AnadirProductoCompra(newCompra);
                            return;
                        }
                    }

                    Console.WriteLine("Cantitad de productos invalidos, por favor intente de nuevo.");
                    Console.WriteLine(producto);
                    Console.ReadKey();
                }
            }
        }

        private Producto BuscarProductoPorNombre(string nombreProducto)
        {
            var repoProducto = RepositorioProducto.Instancia;

            var productos = repoProducto.ConseguirTodos();
            foreach(var producto in productos)
            {
                if (producto.Nombre.ToLower() == producto.Nombre.ToLower())
                    return producto;
            }

            return null;
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