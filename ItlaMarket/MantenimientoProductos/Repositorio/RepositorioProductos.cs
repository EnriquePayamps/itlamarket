using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaMarket.MantenimientoProductos.Repositorio

{
    class RepositorioProducto: IRepositorio<Producto>
    {

        private List<Producto> productos;

        private static RepositorioProducto instancia;

        private RepositorioProducto()
        {
            instancia = this;
            productos = new List<Producto>();
        }

        public static RepositorioProducto Instancia
        {
            get
            {
                if (instancia == null) return new RepositorioProducto();

                return instancia;
            }
        }

        public void Anadir(Producto producto)
        {
            productos.Add(producto);
        }

        public Producto GetProducto(int id)
        {
            return productos[id];
        }

        public Producto[] ConseguirTodos()
        {
            return productos.ToArray();
        }

        public void Eliminar(Producto producto)
        {
            productos.Remove(producto);
        }

        public void Eliminar(int id)
        {
            productos.RemoveAt(id);
        }

        public void Editar(int id, Producto producto)
        {
            productos[id] = producto;
        }

        public override string ToString()
        {
            string resultado = "";
            for (int i = 0; i < productos.Count; i++)
            {
                var producto = productos[i];
                resultado += $"\n{i} - {producto}";
            }

            return resultado;
        }
    }
}
