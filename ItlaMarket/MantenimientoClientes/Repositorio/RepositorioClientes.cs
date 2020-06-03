using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaMarket.MantenimientoDeClientes.Repositorio
{
    class RepositorioClientes : IRepositorio<Cliente>
    {
        private List<Cliente> clientes;


        private static RepositorioClientes instancia;

        private RepositorioClientes()
        {
            instancia = this;
            clientes = new List<Cliente>();
        }

        public static RepositorioClientes Instancia
        {
            get
            {
                if (instancia == null) return new RepositorioClientes();

                return instancia;
            }
        }
        public void Anadir(Cliente cliente)
        {
            clientes.Add(cliente);
        }

        public Cliente[] ConseguirTodos()
        {
            return clientes.ToArray();
        }

        public void Editar(int id, Cliente cliente)
        {
            clientes[id] = cliente;
        }

        public void Eliminar(Cliente cliente)
        {
            clientes.Remove(cliente);
        }

        public void Eliminar(int id)
        {
            clientes.RemoveAt(id);
        }

        public Cliente GetProducto(int id)
        {
            return clientes[id];
        }
    }
}
