using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Proyecto_Final;


class Principal
{
    static public void Main(String[] args)
    {

        var listausuarios = new List<Usuario>();
        var listaproductos = new List<Producto>();
        var listaproductosvendidos = new List<string>();
        var listaproductosvendidos2 = new List<int>();
        var listaventas = new List<int>();

        var Ventas = new List<Venta>();

        SqlConnectionStringBuilder conecctionbuilder = new();
        conecctionbuilder.DataSource = "DESKTOP-KOQ4I96";
        conecctionbuilder.InitialCatalog = "SistemaGestion";
        conecctionbuilder.IntegratedSecurity = true;
        var CS = conecctionbuilder.ConnectionString;

        using (SqlConnection connection = new SqlConnection(CS))
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select * from usuario where NombreUsuario = 'eperez' ";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var usu = new Usuario();
                usu.id = Convert.ToInt32(reader.GetValue(0));
                usu.Nombre = reader.GetValue(1).ToString();
                usu.Apellido = reader.GetValue(2).ToString();
                usu.NombreUsuario = reader.GetValue(3).ToString();
                usu.Contraseña = reader.GetValue(4).ToString();
                usu.Mail = reader.GetValue(5).ToString();

                listausuarios.Add(usu);

                Console.WriteLine("Nombre: " + usu.Nombre);
                Console.WriteLine("Apellido: " + usu.Apellido);
                Console.WriteLine("Nombre de Usuario: " + usu.NombreUsuario);
                Console.WriteLine("Contraseña: " + usu.Contraseña);
                Console.WriteLine("Mail: " + usu.Mail);

            }
            reader.Close();

            Console.WriteLine("-----------------");
            Console.WriteLine("Ejercicio B");
            Console.WriteLine("-----------------");


            SqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "select * from Producto where IdUsuario = 1";
            var reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                var produc = new Producto();
                produc.id = Convert.ToInt32(reader2.GetValue(0));
                produc.Descripcion = reader2.GetValue(1).ToString();
                produc.Costo = Convert.ToDouble(reader2.GetValue(2));
                produc.PrecioVenta = Convert.ToDouble(reader2.GetValue(3));
                produc.Stock = Convert.ToInt32(reader2.GetValue(4));
                produc.IdUsuario = Convert.ToInt32(reader2.GetValue(5));

                listaproductos.Add(produc);
            }


            Console.WriteLine("Productos Cargados por Usuario");
            Console.WriteLine("    ");
            foreach (var produc in listaproductos)
            {
                Console.WriteLine("Usuario: " + produc.IdUsuario + " " + "ID: " + produc.id + " " + "Descripcion: " + produc.Descripcion + "\n" +
                    "Costo: " + produc.Costo + " " + "Precio de Venta: " + produc.PrecioVenta + " " + "Stock: " + produc.Stock);
                Console.WriteLine();

                reader2.Close();
            }



            connection.Close();
        }

        using (SqlConnection conn = new SqlConnection(CS))
        {
            Console.WriteLine("-----------------");
            Console.WriteLine("Ejercicio C");
            Console.WriteLine("-----------------");

            ;

            conn.Open();


            string query = "SELECT  Usuario.NombreUsuario, Producto.Descripciones, Producto.Id, ProductoVendido.IdProducto, ProductoVendido.IdVenta, Producto.IdUsuario, ProductoVendido.Stock" +
                            " FROM Usuario" +
                            " INNER join Producto" +
                            " ON Usuario.id = Producto.IdUsuario" +
                            " INNER join ProductoVendido" +
                            " ON Producto.Id = ProductoVendido.IdProducto";


            SqlCommand comm = new SqlCommand(query, conn);
            SqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                var usuario = new Usuario();
                usuario.NombreUsuario = reader.GetValue(1).ToString();

                var producto = new Producto();
                //producto.id = Convert.ToInt32(reader.GetValue(0));
                producto.Descripcion = reader.GetValue(1).ToString();
                producto.IdUsuario = Convert.ToInt32(reader.GetValue(5));

                var vendido = new ProductoVendido();
                //vendido.IdProducto = Convert.ToInt32(reader.GetValue(1));
                vendido.Stock = Convert.ToInt32(reader.GetValue(2));
                vendido.IdVenta = Convert.ToInt32(reader.GetValue(3));

                listaproductosvendidos.Add(producto.Descripcion);
                listaproductosvendidos.Add(usuario.NombreUsuario);
                listaproductosvendidos2.Add(producto.id);
                listaproductosvendidos2.Add(producto.IdUsuario);
                listaproductosvendidos2.Add(vendido.IdProducto);
                listaproductosvendidos2.Add(vendido.Stock);
                listaproductosvendidos2.Add(vendido.IdVenta);

                ArrayList Milista = new ArrayList();
                Milista.Add(listaproductosvendidos);
                Milista.Add(listaproductosvendidos2);


                foreach (var item in Milista)
                {
                    Console.WriteLine("Usuario: " + usuario.NombreUsuario + " " + "Producto ID: " + producto.id + " " + "Descripcion: " + producto.Descripcion + "\n" +
                        "Venta: " + vendido.IdVenta + " " + "Stock: " + vendido.Stock);
                }

            }



            conn.Close();





        }


        using (SqlConnection conn = new SqlConnection(CS))
        {
            Console.WriteLine("-----------------");
            Console.WriteLine("Ejercicio D");
            Console.WriteLine("-----------------");

            ;

            conn.Open();
            string query = "select Usuario.NombreUsuario, Usuario.Id,Venta.Id\r\n" +
                            "from Usuario\r\n" +
                            "inner join Venta\r\n" +
                            "On Usuario.NombreUsuario = 'eperez' and Usuario.Id = Venta.Id";

            SqlCommand comm = new SqlCommand(query, conn);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                var usuario = new Usuario();
                //usuario.id = Convert.ToInt32(reader.GetValue(0));
                usuario.NombreUsuario = reader.GetValue(1).ToString();

                var ventas = new Venta();
                //ventas.id = Convert.ToInt16(reader.GetValue(0));

                listausuarios.Add(usuario);
                listaventas.Add(ventas.id);


                ArrayList Mylist = new ArrayList();
                Mylist.Add(listausuarios);
                Mylist.Add(listaventas);

                foreach (var item in Mylist)
                {
                    Console.WriteLine("Nombre de Usuario: " + usuario.NombreUsuario + " " + "Ventas: " + ventas.id);
                }

            }
            conn.Close();
        }
       
        
        using (SqlConnection conn = new SqlConnection(CS))
        {
            Console.WriteLine("-----------------");
            Console.WriteLine("Ejercicio E");
            Console.WriteLine("-----------------");

            var query = "select * from usuario where NombreUsuario = @eperez and Contraseña = @SoyErnestoPerez";
            string valorusuario = "eperez";
            string valorcontraseña = "SoyErnestoPerez";
            var parametro = new SqlParameter();
            parametro.ParameterName = "eperez";
            parametro.SqlDbType = SqlDbType.Char;
            parametro.Value = valorusuario;

            var parametro2 = new SqlParameter();
            parametro2.ParameterName = "SoyErnestoPerez";
            parametro2.SqlDbType = SqlDbType.Char;
            parametro2.Value = valorcontraseña;


            conn.Open();
            
            using (SqlCommand InicioSesion = new SqlCommand(query, conn))
            {
                InicioSesion.Parameters.Add(parametro);
                InicioSesion.Parameters.Add(parametro2);
                InicioSesion.ExecuteNonQuery();

                Console.WriteLine("-------INICIO DE SESION------");
                Console.WriteLine("Usuario: " + parametro);
                Console.WriteLine("Contraseña: " + parametro2);


            }

        }
    }
}