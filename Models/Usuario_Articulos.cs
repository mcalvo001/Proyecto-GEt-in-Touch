using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GETinTouch.Models
{
    public class Usuario_Articulos
    {
        private Usuario Id_usuario;
        private Articulo Id_articulo;

        public Usuario Id_usuario1 { get => Id_usuario; set => Id_usuario = value; }
        public Articulo Id_articulo1 { get => Id_articulo; set => Id_articulo = value; }

        public string Insert_Usuario_Articulos_BD()
        {
            String respuesta = "0";
            ConexionconBD conx_detalles = new ConexionconBD();

            try
            {
                if (conx_detalles.inicializaBD())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;
                    CONSULTA = "EXEC I_USUARIO_ARTICULO ?,?";

                    conx_detalles.nueva_consulta(CONSULTA);
                    conx_detalles.nuevo_parametro(Id_usuario1.Id_usuario1, 1);
                    conx_detalles.nuevo_parametro(Id_articulo1.Id_articulo1, 1);

                    CONTENEDOR = conx_detalles.busca();
                    conx_detalles.conexion.Close();
                    conx_detalles.conexion.Dispose();
                    CONTENEDOR.Close();
                    return "Se ha insertado el articulo: "+ Id_articulo1.Id_articulo1 + " en Articulos Favoritos del usuario:" + Id_usuario1.Id_usuario1.ToString() + " de forma correcta";
                }
                else
                {
                    return "No hay conexión con la base de datos";
                }
            }
            catch (Exception error)
            {
                return "Este articulo ya es tu favorito";
            }
        }

        public string Delete_Usuario_Articulos_BD()
        {
            String respuesta = "0";
            ConexionconBD conx_detalles = new ConexionconBD();

            try
            {
                if (conx_detalles.inicializaBD())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;
                    CONSULTA = "EXEC D_USUARIO_ARTICULO ?,?";

                    conx_detalles.nueva_consulta(CONSULTA);
                    conx_detalles.nuevo_parametro(Id_usuario1.Id_usuario1, 1);
                    conx_detalles.nuevo_parametro(Id_articulo1.Id_articulo1, 1);

                    CONTENEDOR = conx_detalles.busca();
                    conx_detalles.conexion.Close();
                    conx_detalles.conexion.Dispose();
                    CONTENEDOR.Close();
                    return "Se ha eliminado el articulo: " + Id_articulo1.Id_articulo1 + " de Articulos Favoritos del usuario:" + Id_usuario1.Id_usuario1.ToString() + " de forma correcta";
                }
                else
                {
                    return "No hay conexión con la base de datos";
                }
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public List<Usuario_Articulos> Select_Articulos_x_Usuarios()
        {
            List<Usuario_Articulos> Usuario_Articulos = new List<Usuario_Articulos>();
            ConexionconBD objeto_conexion = new ConexionconBD();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    string query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;
                    query = "EXEC S_ARTICULOSxUSUARIOS ?";

                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_usuario1.Id_usuario1, 1);
                    CONTENEDOR = objeto_conexion.busca();

                    while (CONTENEDOR.Read())
                    {
                        Usuario_Articulos usuario_articulos = new Usuario_Articulos();

                        Usuario usuario = new Usuario();
                        usuario.Id_usuario1 = Convert.ToInt32(CONTENEDOR["ID_USUARIO"].ToString());
                        usuario_articulos.Id_usuario1 = usuario;

                        Articulo articulo = new Articulo();
                        articulo.Id_articulo1 = Convert.ToInt32(CONTENEDOR["ID_ARTICULO"].ToString());
                        usuario_articulos.Id_articulo1 = articulo;

                        Usuario_Articulos.Add(usuario_articulos);
                    }
                    objeto_conexion.conexion.Close();
                    objeto_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return Usuario_Articulos;
                }
                else
                {


                    return Usuario_Articulos;
                }
            }
            catch (Exception error)
            {
                return Usuario_Articulos;
            }


        }
    }
}