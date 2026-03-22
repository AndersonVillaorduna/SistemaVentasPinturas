using System;
using SistemaVentasPinturas.Services;

class Program
{
    static ProductoService productoService = new ProductoService();

    static void Main(string[] args)
    {
        int opcion;

        do
        {
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Mostrar productos");
            Console.WriteLine("3. Actualizar producto");
            Console.WriteLine("4. Eliminar producto");
            Console.WriteLine("5. Salir");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();

                    Console.Write("Precio: ");
                    double precio = double.Parse(Console.ReadLine());

                    productoService.AgregarProducto(nombre, precio);
                    Console.WriteLine("Producto guardado.");
                    break;

                case 2:
                    productoService.MostrarProductos();
                    break;

                case 3:
                    Console.Write("Nombre del producto: ");
                    string nombreAct = Console.ReadLine();

                    Console.Write("Nuevo precio: ");
                    double nuevoPrecio = double.Parse(Console.ReadLine());

                    productoService.ActualizarProducto(nombreAct, nuevoPrecio);
                    break;

                case 4:
                    Console.Write("Nombre del producto a eliminar: ");
                    string nombreDel = Console.ReadLine();

                    productoService.EliminarProducto(nombreDel);
                    break;
            }

        } while (opcion != 5);
    }
}