using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaMarket
{
    interface IRepositorio<Modelo>
    {
        public void Anadir(Modelo modelo);

        public Modelo GetProducto(int id);

        public Modelo[] ConseguirTodos();

        public void Eliminar(Modelo modelo);

        public void Eliminar(int id);

        public void Editar(int id, Modelo modelo);
    }
}
