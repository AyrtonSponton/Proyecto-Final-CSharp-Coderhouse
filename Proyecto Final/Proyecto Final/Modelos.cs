using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    public class Usuario
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Mail { get; set; }


        public Usuario()
        {
            id = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
            NombreUsuario = string.Empty;
            Contraseña = string.Empty;
            Mail = string.Empty;
        }
    }
    

    public class Producto
    {
        public int id;
        public string Descripcion;
        public double Costo;
        public double PrecioVenta;
        public int Stock;
        public int IdUsuario;

        public Producto()
        {
            id = 0;
            Descripcion = String.Empty;
            Costo = 0;
            PrecioVenta = 0;
            Stock = 0;
            IdUsuario = 0;
        }
    }

    public class ProductoVendido
    {
        public int id;
        public int IdProducto;
        public int Stock;
        public int IdVenta;

        public ProductoVendido()
        {
            id = 0;
            IdProducto = 0;
            Stock = 0;
            IdVenta = 0;
        }   
    }

    public class Venta
    {
        public int id;
        public string Comentarios;
        public int IdUsuario;

        public Venta ()
        {
            id = 0;
            Comentarios = String.Empty;
            IdUsuario = 0;
        }
    }
}
