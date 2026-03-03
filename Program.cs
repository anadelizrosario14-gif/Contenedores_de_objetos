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

  // PROGRAMA PRINCIPAL
 class Program
 {
     static void Main(string[] args)
     {
         Almacen almacen = new Almacen();
         bool salir = false;

         while (!salir)
         {
             Console.WriteLine("\n=====================================");
             Console.WriteLine("   SISTEMA DE GESTIÓN DE PRODUCTOS");
             Console.WriteLine("=====================================");
             Console.WriteLine("1. Registrar producto");
             Console.WriteLine("2. Buscar producto");
             Console.WriteLine("3. Eliminar producto");
             Console.WriteLine("4. Listar productos");
             Console.WriteLine("5. Mostrar cantidad total");
             Console.WriteLine("6. Salir");
             Console.Write("Seleccione una opción: ");

             string opcion = Console.ReadLine();

             switch (opcion)
             {
                 case "1":
                     RegistrarProducto(almacen);
                     break;

                 case "2":
                     BuscarProducto(almacen);
                     break;

                 case "3":
                     EliminarProducto(almacen);
                     break;

                 case "4":
                     ListarProductos(almacen);
                     break;

                 case "5":
                     Console.WriteLine($"Cantidad total de productos: {almacen.CantidadTotal()}");
                     break;

                 case "6":
                     salir = true;
                     Console.WriteLine("Saliendo del sistema...");
                     break;

                 default:
                     Console.WriteLine("Opción inválida. Intente nuevamente.");
                     break;
             }
         }
     }
