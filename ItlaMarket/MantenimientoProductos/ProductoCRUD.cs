using ItlaMarket.MantenimientoProductos.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaMarket.MantenimientoProductos
{
    class ProductoCRUD
    {
        RepositorioProducto repositorioProducto
        {
            get => RepositorioProducto.Instancia;
        }

        private MenuProducto menuMantenimiento;

        public ProductoCRUD(MenuProducto menuMantenimiento)
        {
            this.menuMantenimiento = menuMantenimiento;
        }

        public void Agregar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Agregue el nombre del producto");
                string nombre = Console.ReadLine();

                Console.WriteLine("Agregue el precio del producto");
                int precio = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Agregue la cantidad del producto");
                int cantidad = Convert.ToInt32(Console.ReadLine());

                Producto nuevoProducto = new Producto(nombre, precio, cantidad);

                repositorioProducto.Anadir(nuevoProducto);
                Console.WriteLine("Producto agregado con exito");
                menuMantenimiento.ImprimirMenu();

            }
            catch (Exception)
            {
                Console.WriteLine("introdusca una opcion valida");
                Console.ReadKey();
                Agregar();
                throw;
            }
        }

        public void Editar()
        {
            try
            {
                Console.Clear();
                Listar();

                Console.WriteLine("Selecione el producto que desea editar");
                int idProducto = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ingrese el nombre del producto");
                string nombre = Console.ReadLine();

                Console.WriteLine("Agregue el nombre del producto");
                int precio = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Agregue el nombre del producto");
                int cantidad = Convert.ToInt32(Console.ReadLine());

                Producto productoEditado = new Producto(nombre, precio, cantidad);

                repositorioProducto.Editar(idProducto-1, productoEditado);

                Console.WriteLine("Su producto fue modificado");
                Console.ReadKey();
                menuMantenimiento.ImprimirMenu();
            }
            catch (Exception)
            {

                Console.WriteLine("introdusca una opcion valida");
                Console.ReadKey();
                Editar();
                throw;
            }
        }

        public void Eliminar()
        {
            Console.Clear();
            Listar();

            try
            {
                Console.WriteLine("Selecione el producto que desea editar");

                int opciones = Convert.ToInt32(Console.ReadLine());

                repositorioProducto.Eliminar(opciones - 1);

                menuMantenimiento.ImprimirMenu();
            }
            catch (Exception)
            {

                Console.WriteLine("introdusca una opcion valida");
                Console.ReadKey();
                Eliminar();

                throw;
            }
        }

        public void Listar(bool ismenu=false)
        {
            Console.Clear();
            var productos = repositorioProducto.ConseguirTodos();

            for (int i = 0; i < productos.Length; i++)
            {
                var producto = productos[i];
                Console.WriteLine($"{i+1} - {producto}");
                Console.ReadKey();
            }
          
            if (ismenu)
            {
                Console.ReadKey();
                menuMantenimiento.ImprimirMenu();
            }
        }
    }
}
