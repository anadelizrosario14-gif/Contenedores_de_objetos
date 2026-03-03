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
