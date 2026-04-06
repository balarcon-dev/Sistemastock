using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SistemaStock
{
    class StockManager
    {
        private List<Producto> productos = new List<Producto>();
        private readonly string archivo = "productos.json"; // archivo donde se guardan los productos

        public StockManager()
        {
            CargarProductos(); // al iniciar, cargamos los productos si existen
        }

        public void AgregarProducto(string nombre, int stock, decimal precio)
        {
            productos.Add(new Producto(nombre, stock, precio));
            Console.WriteLine("Producto agregado!");
            GuardarProductos(); // guardamos inmediatamente
        }

        public void MostrarProductos()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos.");
                return;
            }

            Console.WriteLine("\nLista de productos:");
            Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-10}", "N°", "Nombre", "Stock", "Precio");
            for (int i = 0; i < productos.Count; i++)
            {
                var p = productos[i];
                Console.WriteLine("{0,-5} {1,-20} {2,-10} ${3,-10}", i + 1, p.Nombre, p.Stock, p.Precio);
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
                GuardarProductos(); // guardamos después de la venta
            }
        }

        public int CantidadProductos() => productos.Count;
        public Producto GetProducto(int indice) => productos[indice];

        // Valor total del inventario
        public decimal ValorTotalInventario()
        {
            decimal total = 0;
            foreach (var p in productos)
                total += p.Precio * p.Stock;
            return total;
        }

        // ----------------------
        // PERSISTENCIA EN JSON
        private void GuardarProductos()
        {
            try
            {
                string json = JsonSerializer.Serialize(productos, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(archivo, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error guardando productos: " + ex.Message);
            }
        }

        private void CargarProductos()
        {
            try
            {
                if (!File.Exists(archivo)) return;

                string json = File.ReadAllText(archivo);
                productos = JsonSerializer.Deserialize<List<Producto>>(json) ?? new List<Producto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error cargando productos: " + ex.Message);
                productos = new List<Producto>();
            }
        }
    }
}