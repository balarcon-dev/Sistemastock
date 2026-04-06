using System;
using SistemaStock; // IMPORTANTE: importar el namespace

class Program
{
    static StockManager stockManager = new StockManager();

    static void Main()
    {
        int opcion;

        do
        {
            Console.WriteLine("\n=== SISTEMA DE STOCK ===");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Ver productos");
            Console.WriteLine("3. Vender producto");
            Console.WriteLine("0. Salir");
            Console.Write("Elegí una opción: ");

            while (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.Write("Opción inválida. Elegí nuevamente: ");
            }

            switch (opcion)
            {
                case 1:
                    AgregarProductoMenu();
                    break;
                case 2:
                    stockManager.MostrarProductos();
                    break;
                case 3:
                    VenderProductoMenu();
                    break;
            }

        } while (opcion != 0);

        Console.WriteLine("¡Hasta luego!");
    }

    static void AgregarProductoMenu()
    {
        Console.Write("Nombre del producto: ");
        string nombre = Console.ReadLine()!;

        int stock;
        Console.Write("Stock: ");
        while (!int.TryParse(Console.ReadLine(), out stock) || stock < 0)
        {
            Console.Write("Stock inválido. Ingresá un número válido: ");
        }

        decimal precio;
        Console.Write("Precio: ");
        while (!decimal.TryParse(Console.ReadLine(), out precio) || precio < 0)
        {
            Console.Write("Precio inválido. Ingresá un número válido: ");
        }

        stockManager.AgregarProducto(nombre, stock, precio);
    }

    static void VenderProductoMenu()
    {
        if (stockManager.CantidadProductos() == 0)
        {
            Console.WriteLine("No hay productos para vender.");
            return;
        }

        stockManager.MostrarProductos();

        int indice;
        Console.Write("Seleccioná el producto a vender (número): ");
        while (!int.TryParse(Console.ReadLine(), out indice) || indice < 1 || indice > stockManager.CantidadProductos())
        {
            Console.Write("Número inválido. Ingresá nuevamente: ");
        }
        indice -= 1; // ajustar índice de la lista

        int cantidad;
        Console.Write("Cantidad a vender: ");
        while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad < 1)
        {
            Console.Write("Cantidad inválida. Ingresá nuevamente: ");
        }

        stockManager.VenderProducto(indice, cantidad);
    }
}