using System;
using System.Collections.Generic;
using System.Text;
using ItlaMarket.MantenimientoDeClientes.Repositorio;

namespace ItlaMarket.MantenimientoDeClientes
{
    class ClienteCRUD
    {
        RepositorioClientes repositorioClientes
        {
            get => RepositorioClientes.Instancia;
        }

        private MenuCliente menuMantenimiento;

        public ClienteCRUD(MenuCliente menuMantenimiento)
        {
            this.menuMantenimiento = menuMantenimiento;
        }

        public void Agregar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Agregue el nombre del Cliente");
                string nombre = Console.ReadLine();

                Cliente nuevoProducto = new Cliente(nombre);

                repositorioClientes.Anadir(nuevoProducto);
                Console.WriteLine("Cliente agregado con exito");
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

                Console.WriteLine("Selecione el cliente que desea editar");
                int idProducto = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ingrese el nombre del cliente");
                string nombre = Console.ReadLine();

                

                Cliente productoEditado = new Cliente(nombre);

                repositorioClientes.Editar(idProducto - 1, productoEditado);

                Console.WriteLine("Su cliente fue modificado");
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
                Console.WriteLine("Selecione el cliente que desea eliminar");

                int opciones = Convert.ToInt32(Console.ReadLine());

                repositorioClientes.Eliminar(opciones - 1);

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

        public void Listar(bool ismenu = false)
        {
            Console.Clear();
            var productos = repositorioClientes.ConseguirTodos();

            for (int i = 0; i < productos.Length; i++)
            {
                var producto = productos[i];
                Console.WriteLine($"{i + 1} -  {producto.Nombre} ");
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

