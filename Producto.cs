namespace SistemaStock
{
    class Producto
    {
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }

        public Producto(string nombre, int stock, decimal precio)
        {
            Nombre = nombre;
            Stock = stock;
            Precio = precio;
        }
    }
}