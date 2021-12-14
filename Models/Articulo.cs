using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GETinTouch.Models
{
    public class Articulo
    {
        private int Id_articulo;
        private Usuario Autor;
        private string Nombre_articulo;
        private DateTime Fecha_publicacion;
        private string Text;
        private string Foto;

        public int Id_articulo1 { get => Id_articulo; set => Id_articulo = value; }
        public Usuario Autor1 { get => Autor; set => Autor = value; }
        public string Nombre_articulo1 { get => Nombre_articulo; set => Nombre_articulo = value; }
        public DateTime Fecha_publicacion1 { get => Fecha_publicacion; set => Fecha_publicacion = value; }
        public string Text1 { get => Text; set => Text = value; }
        public string Foto1 { get => Foto; set => Foto = value; }

        public string Insert_Articulo_BD()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    String query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    query = "EXEC I_ARTICULO ?,?,?,?,?,?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_articulo1, 1);
                    objeto_conexion.nuevo_parametro(Autor1.Id_usuario1, 1);
                    objeto_conexion.nuevo_parametro(Nombre_articulo1, 2);
                    objeto_conexion.nuevo_parametro(Fecha_publicacion1, 4);
                    objeto_conexion.nuevo_parametro(Text1, 2);
                    objeto_conexion.nuevo_parametro(Foto1, 2);

                    CONTENEDOR = objeto_conexion.busca();

                    objeto_conexion.conexion.Close();
                    objeto_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return "Se insertó la información correctamente";
                }
                else return "Sin Conexión con la Base de Datos";
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }

        public string Delete_Articulo_BD()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    String query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    query = "EXEC D_ARTICULO ?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_articulo1, 1);

                    CONTENEDOR = objeto_conexion.busca();

                    objeto_conexion.conexion.Close();
                    objeto_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return "Se eliminó la información correctamente";
                }
                else return "Sin Conexión con la Base de Datos";
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }

        public string Update_Articulo_BD()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    String query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    query = "EXEC U_ARTICULO ?,?,?,?,?,?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_articulo1, 1);
                    objeto_conexion.nuevo_parametro(Autor1.Id_usuario1, 1);
                    objeto_conexion.nuevo_parametro(Nombre_articulo1, 2);
                    objeto_conexion.nuevo_parametro(Fecha_publicacion1, 4);
                    objeto_conexion.nuevo_parametro(Text1, 2);
                    objeto_conexion.nuevo_parametro(Foto1, 2);

                    CONTENEDOR = objeto_conexion.busca();

                    objeto_conexion.conexion.Close();
                    objeto_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return "Se actualizó la información correctamente";
                }
                else return "Sin Conexión con la Base de Datos";
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }
        public Articulo Select_Articulo()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            Articulo articulo = new Articulo();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    string query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;
                    query = "EXEC S_ARTICULO ?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_articulo1.ToString(), 2); ;
                    CONTENEDOR = objeto_conexion.busca();
                    while (CONTENEDOR.Read())
                    {

                        articulo.Id_articulo1 = Convert.ToInt32(CONTENEDOR["ID_ARTICULO"].ToString());

                        Usuario usuario = new Usuario();
                        usuario.Id_usuario1 = Convert.ToInt32(CONTENEDOR["AUTOR"].ToString());
                        articulo.Autor1 = usuario;

                        articulo.Nombre_articulo1 = Convert.ToString(CONTENEDOR["NOMBRE_ARTICULO"].ToString());
                        articulo.Fecha_publicacion1 = Convert.ToDateTime(CONTENEDOR["FECHA_PUBLICACION"].ToString());
                        articulo.Text1 = Convert.ToString(CONTENEDOR["TEXTO"].ToString());
                        articulo.Foto1 = Convert.ToString(CONTENEDOR["FOTO"].ToString());


                    }
                    objeto_conexion.conexion.Close();
                    objeto_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return articulo;
                }
                else
                {


                    return articulo;
                }
            }
            catch (Exception error)
            {
                articulo.Id_articulo1 = -2;
                return articulo;
            }
        }

        public Articulo Select_ArticuloxAutor()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            Articulo articulo = new Articulo();
            articulo.Id_articulo1 = -1;
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    string query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;
                    query = "EXEC S_ARTICULOxUSUARIO ?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Autor1.ToString(), 2); ;
                    CONTENEDOR = objeto_conexion.busca();
                    while (CONTENEDOR.Read())
                    {

                        articulo.Id_articulo1 = Convert.ToInt16(CONTENEDOR["ID_ARTICULO"].ToString());

                        Usuario usuario = new Usuario();
                        usuario.Id_usuario1 = Convert.ToInt16(CONTENEDOR["AUTOR"].ToString());
                        articulo.Autor1 = usuario;

                        articulo.Nombre_articulo1 = Convert.ToString(CONTENEDOR["NOMBRE_ARTICULO"].ToString());
                        articulo.Fecha_publicacion1 = Convert.ToDateTime(CONTENEDOR["FECHA_PUBLICACION"].ToString());
                        articulo.Text1 = Convert.ToString(CONTENEDOR["TEXTO"].ToString());
                        articulo.Foto1 = Convert.ToString(CONTENEDOR["FOTO"].ToString());


                    }
                    objeto_conexion.conexion.Close();
                    objeto_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return articulo;
                }
                else
                {


                    return articulo;
                }
            }
            catch (Exception error)
            {
                articulo.Id_articulo1 = -2;
                return articulo;
            }
        }

        public List<Articulo> Select_All_Articulo_BD()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            List<Articulo> lista_devolver = new List<Articulo>();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    string query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    query = "EXEC ST_ARTICULO";
                    objeto_conexion.nueva_consulta(query);
                    CONTENEDOR = objeto_conexion.busca();
                    while (CONTENEDOR.Read())
                    {

                        Articulo articulo = new Articulo();

                        articulo.Id_articulo1 = Convert.ToInt32(CONTENEDOR["ID_ARTICULO"].ToString());

                        Usuario usuario = new Usuario();
                        usuario.Id_usuario1 = Convert.ToInt32(CONTENEDOR["AUTOR"].ToString());
                        articulo.Autor1 = usuario;

                        articulo.Nombre_articulo1 = Convert.ToString(CONTENEDOR["NOMBRE_ARTICULO"].ToString());
                        articulo.Fecha_publicacion1 = Convert.ToDateTime(CONTENEDOR["FECHA_PUBLICACION"].ToString());
                        articulo.Text1 = Convert.ToString(CONTENEDOR["TEXTO"].ToString());
                        articulo.Foto1 = Convert.ToString(CONTENEDOR["FOTO"].ToString());


                        lista_devolver.Add(articulo);

                    }
                    objeto_conexion.conexion.Close();
                    objeto_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return lista_devolver;
                }
                else
                {


                    return lista_devolver;
                }
            }
            catch (Exception error)
            {
                return lista_devolver;
            }

        } 
    }
}