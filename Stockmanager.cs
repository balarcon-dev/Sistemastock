using System;
using System.Collections.Generic;

namespace SistemaStock
{
    class StockManager
    {
        private List<Producto> productos = new List<Producto>();

        public void AgregarProducto(string nombre, int stock, decimal precio)
        {
            productos.Add(new Producto(nombre, stock, precio));
            Console.WriteLine("Producto agregado!");
        }

        public void MostrarProductos()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos.");
                return;
            }

            Console.WriteLine("\nLista de productos:");
            for (int i = 0; i < productos.Count; i++)
            {
                var p = productos[i];
                Console.WriteLine($"{i + 1}. {p.Nombre} | Stock: {p.Stock} | Precio: ${p.Precio}");
            }
        }

        public void VenderProducto(int indice, int cantidad)
        {
            Producto p = productos[indice];

            if (cantidad > p.Stock)
            {
                Console.WriteLine("No hay suficiente stock.");
            }
            else
            {
                p.Stock -= cantidad;
                Console.WriteLine($"Venta realizada. Stock restante: {p.Stock}");
            }
        }

        public int CantidadProductos() => productos.Count;
        public Producto GetProducto(int indice) => productos[indice];
    }
}