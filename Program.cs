using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestionProductos
{
    // CLASE PRODUCTO
public class Producto

{
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public double Precio { get; set; }

    public Producto(string codigo, string nombre, double precio)
    {
        Codigo = codigo;
        Nombre = nombre;
        Precio = precio;
    }

    public override string ToString()
    {
        return $"Código: {Codigo} | Nombre: {Nombre} | Precio: RD$ {Precio:F2}";
    }
}
// CLASE ALMACEN
public class Almacen

{
    private List<Producto> productos;

    public Almacen()
    {
        productos = new List<Producto>();
    }

    public bool AgregarProducto(Producto producto)
    {
        if (productos.Any(p => p.Codigo.Equals(producto.Codigo, StringComparison.OrdinalIgnoreCase)))
        {
            return false; // Código duplicado
        }

        productos.Add(producto);
        return true;
    }

    public Producto BuscarPorCodigo(string codigo)
    {
        return productos.FirstOrDefault(p =>
            p.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
    }

    public bool EliminarProducto(string codigo)
    {
        Producto producto = BuscarPorCodigo(codigo);

        if (producto == null)
            return false;

        productos.Remove(producto);
        return true;
    }

    public List<Producto> ObtenerProductos()
    {
        return productos;
    }

    public int CantidadTotal()
    {
        return productos.Count;
    }
}
