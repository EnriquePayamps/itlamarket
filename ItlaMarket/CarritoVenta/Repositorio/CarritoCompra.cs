using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaMarket.CarritoVenta.Repositorio
{
    class CarritoCompra
    {
        private readonly DateTime fechaDeCreacion;
        List<CarritoItem> items;
        
        public float GranTotal
        {
            get
            {
                if(items.Count == 0) return 0f;

                var total = 0f;

                foreach(var item in items)
                {
                    total += item.Total;
                }

                return total;
            }
        }
        public string FechaFactura
        {
            get => fechaDeCreacion.ToString("yyyy/mm/dd h:m");
        }

        public CarritoCompra()
        {
            items = new List<CarritoItem>();
            fechaDeCreacion = DateTime.Now;
        }

        public void Anadir(CarritoItem newItem)
        {
            var item = BuscarCarritoItemByProductName(newItem.Producto.Nombre);
            
            if(item != null)
                item.Cantidad += newItem.Cantidad;
            else
                items.Add(newItem);
        }
        public void EliminarProducto(int itemid)
        {
            items.RemoveAt(itemid);
        }

        private CarritoItem BuscarCarritoItemByProductName(string productName)
        {
            foreach(var item in items)
            {
                if (item.Producto.Nombre.ToLower() == productName.ToLower()) 
                    return item;
            }

            return null;
        }

        public override string ToString()
        {
            string resultado = "";
            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                resultado += $"\n{i} - {item}";
            }

            return $"\nGran Total: { GranTotal }";
        }
    }
}
