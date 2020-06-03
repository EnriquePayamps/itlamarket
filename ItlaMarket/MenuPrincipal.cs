using ItlaMarket.MantenimientoProductos;
using System;
using System.Collections.Generic;
using System.Text;
using ItlaMarket.MantenimientoDeClientes;

namespace ItlaMarket
{
    class MenuPrincipal: IMenu
    {
		private IMenu manteniminetoDeProducto;
		private IMenu mantenimientoDeClientes;
		private IMenu realizarVenta;
		VerFactura menuVerFactura = new VerFactura();

		public MenuPrincipal()
		{
			manteniminetoDeProducto = new MenuProducto(menuAnterior: this);
			mantenimientoDeClientes = new MenuCliente(menuAnterior: this);
			this.realizarVenta = new RealizarVenta();
			
		}
		enum opciones
		{ 
			MENTENIMIENTO_PRODUCTO=1,
			MENTENIMIENTO_CLIENTE,
			REALIZAR_VENTA,
			VER_FACTURA,
			SALIR
		}

        public void ImprimirMenu()
        {
			try
			{
				Console.Clear();
				Console.WriteLine("Introducta una de las opciones siguientes \n1-Mantenimiento de Producto \n2-Mentenimiento de cliente \n3-Realizar venta \n4-Ver Factura \n5-Salir ");
				int opcion = Convert.ToInt32(Console.ReadLine());
				switch (opcion)
				{
					case (int)opciones.MENTENIMIENTO_PRODUCTO:
						manteniminetoDeProducto.ImprimirMenu();
						break;
					case (int)opciones.MENTENIMIENTO_CLIENTE:
						mantenimientoDeClientes.ImprimirMenu();
						break;
					case (int)opciones.REALIZAR_VENTA:
						realizarVenta.ImprimirMenu();
						break;
					case (int)opciones.VER_FACTURA:
						menuVerFactura.ImprimirMenu();
						break;
					case (int)opciones.SALIR:
						
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
