using System;
using System.Collections.Generic;
using System.Text;


namespace ItlaMarket.MantenimientoDeClientes
{
	
	class MenuCliente: IMenu
	{
		private ClienteCRUD agregarCliente;
		
		private IMenu menuAnterior;
		public MenuCliente (IMenu menuAnterior)
		{
			agregarCliente = new ClienteCRUD(menuMantenimiento: this);

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
						agregarCliente.Agregar();
						break;
					case (int)OpcionesMenuProducto.EDITAR:
						agregarCliente.Editar();
						break;
					case (int)OpcionesMenuProducto.ELIMINAR:
						agregarCliente.Eliminar();
						break;
					case (int)OpcionesMenuProducto.LISTAR:
						agregarCliente.Listar(true);
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
