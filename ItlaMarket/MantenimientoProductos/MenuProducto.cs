using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaMarket.MantenimientoProductos
{
    class MenuProducto: IMenu
    {
		private ProductoCRUD agregarProducto;
		private IMenu menuAnterior;
		public MenuProducto(IMenu menuAnterior)
		{
			agregarProducto = new ProductoCRUD(menuMantenimiento: this);

			this.menuAnterior = menuAnterior;
		}
		enum OpcionesMenuProducto
		{
			AGREGAR = 1,
			EDITAR,
			ELIMINAR,
			LISTAR,
			VOLVER_ATRAS
		}

		public void ImprimirMenu()
        {
			try
			{
				Console.Clear();
				Console.WriteLine("Introducta una de las opciones siguientes \n1-Agregar \n2-Editar \n3-Eliminar \n4-Listar \n5-Volver atras");
				int opcion = Convert.ToInt32(Console.ReadLine());
				switch (opcion)
				{
					case (int)OpcionesMenuProducto.AGREGAR:
						agregarProducto.Agregar();
						break;
					case (int)OpcionesMenuProducto.EDITAR:
						agregarProducto.Editar();
						break;
					case (int)OpcionesMenuProducto.ELIMINAR:
						agregarProducto.Eliminar();
						break;
					case (int)OpcionesMenuProducto.LISTAR:
						agregarProducto.Listar(true);
						break;
					case (int)OpcionesMenuProducto.VOLVER_ATRAS:
						menuAnterior.ImprimirMenu();
						break;

					default:
						Console.WriteLine("Ingrese una opcion valida");
						Console.ReadKey();
						ImprimirMenu();
						break;
				}
			}
			catch (Exception)
			{
				Console.WriteLine("Ingrese una opcion valida");
				Console.ReadKey();
				ImprimirMenu();
				throw;
			}
		}
    }
}
