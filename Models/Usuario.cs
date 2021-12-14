using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GETinTouch.Models
{
    public class Usuario
    {
        private int Id_usuario;
        private Institucion Id_institucion;
        private string Correo;
        private string Nombre_usuario;
        private string Constraseña;
        private string Foto;
        private string Rol;

        public int Id_usuario1 { get => Id_usuario; set => Id_usuario = value; }
        public Institucion Id_institucion1 { get => Id_institucion; set => Id_institucion = value; }
        public string Correo1 { get => Correo; set => Correo = value; }
        public string Nombre_usuario1 { get => Nombre_usuario; set => Nombre_usuario = value; }
        public string Constraseña1 { get => Constraseña; set => Constraseña = value; }
        public string Foto1 { get => Foto; set => Foto = value; }
        public string Rol1 { get => Rol; set => Rol = value; }

        public string Insert_Usuario_BD()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    String query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    query = "EXEC I_USUARIO ?,?,?,?,?,?,?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_usuario1, 1);
                    objeto_conexion.nuevo_parametro(Id_institucion1.Id_institucion1, 1);
                    objeto_conexion.nuevo_parametro(Correo1, 2);
                    objeto_conexion.nuevo_parametro(Nombre_usuario1, 2);
                    objeto_conexion.nuevo_parametro(Constraseña1, 2);
                    objeto_conexion.nuevo_parametro(Foto1, 2);
                    objeto_conexion.nuevo_parametro(Rol1, 2);

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

        public string Delete_Usuario_BD()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    String query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    query = "EXEC D_USUARIO ?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_usuario1, 1);

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

        public string Update_Usuario_BD()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    String query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    query = "EXEC U_USUARIO ?,?,?,?,?,?,?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_usuario1, 1);
                    objeto_conexion.nuevo_parametro(Id_institucion1.Id_institucion1, 1);
                    objeto_conexion.nuevo_parametro(Correo1, 2);
                    objeto_conexion.nuevo_parametro(Nombre_usuario1, 2);
                    objeto_conexion.nuevo_parametro(Constraseña1, 2);
                    objeto_conexion.nuevo_parametro(Foto1, 2);
                    objeto_conexion.nuevo_parametro(Rol1, 2);

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
        public Usuario Select_Usuario()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            Usuario usuario = new Usuario();
            usuario.Nombre_usuario1 = "NO EXISTE";
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    string query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;
                    query = "EXEC S_USUARIO ?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_usuario1.ToString(), 2); ;
                    CONTENEDOR = objeto_conexion.busca();
                    while (CONTENEDOR.Read())
                    {

                        usuario.Id_usuario1 = Convert.ToInt32(CONTENEDOR["ID_USUARIO"].ToString());

                        Institucion institucion = new Institucion();
                        institucion.Id_institucion1 = Convert.ToInt16(CONTENEDOR["ID_INSTITUCION"].ToString());
                        usuario.Id_institucion1 = institucion;

                        usuario.Correo1 = Convert.ToString(CONTENEDOR["CORREO"].ToString());
                        usuario.Nombre_usuario1 = Convert.ToString(CONTENEDOR["NOMBRE_USUARIO"].ToString());
                        usuario.Constraseña1 = Convert.ToString(CONTENEDOR["CONTRASENA"].ToString());
                        usuario.Foto1 = Convert.ToString(CONTENEDOR["FOTO_USUARIO"].ToString());
                        usuario.Rol1 = Convert.ToString(CONTENEDOR["ROL"].ToString());

                    }
                    objeto_conexion.conexion.Close();
                    objeto_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return usuario;
                }
                else
                {


                    return usuario;
                }
            }
            catch (Exception error)
            {
                usuario.Nombre_usuario1 = "Error";
                return usuario;
            }
        }

        public List<Usuario> Select_UsuarioxInstitucion()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            List<Usuario> lista_devolver = new List<Usuario>();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    string query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    query = "EXEC S_USUARIOxINSTITUCION ?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_institucion1.Id_institucion1.ToString(), 2); ;
                    

                    CONTENEDOR = objeto_conexion.busca();
                    while (CONTENEDOR.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.Id_usuario1 = Convert.ToInt32(CONTENEDOR["ID_USUARIO"].ToString());

                        Institucion institucion = new Institucion();
                        institucion.Id_institucion1 = Convert.ToInt16(CONTENEDOR["ID_INSTITUCION"].ToString());
                        usuario.Id_institucion1 = institucion;

                        usuario.Correo1 = Convert.ToString(CONTENEDOR["CORREO"].ToString());
                        usuario.Nombre_usuario1 = Convert.ToString(CONTENEDOR["NOMBRE_USUARIO"].ToString());
                        usuario.Constraseña1 = Convert.ToString(CONTENEDOR["CONTRASENA"].ToString());
                        usuario.Foto1 = Convert.ToString(CONTENEDOR["FOTO_USUARIO"].ToString());
                        usuario.Rol1 = Convert.ToString(CONTENEDOR["ROL"].ToString());

                        lista_devolver.Add(usuario);

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
        public List<Usuario> Select_All_Usuario_BD()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            List<Usuario> lista_devolver = new List<Usuario>();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    string query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    query = "EXEC ST_USUARIO";
                    objeto_conexion.nueva_consulta(query);
                    CONTENEDOR = objeto_conexion.busca();
                    while (CONTENEDOR.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.Id_usuario1 = Convert.ToInt16(CONTENEDOR["ID_USUARIO"].ToString());

                        Institucion institucion = new Institucion();
                        institucion.Id_institucion1 = Convert.ToInt16(CONTENEDOR["ID_INSTITUCION"].ToString());
                        usuario.Id_institucion1 = institucion;

                        usuario.Correo1 = Convert.ToString(CONTENEDOR["CORREO"].ToString());
                        usuario.Nombre_usuario1 = Convert.ToString(CONTENEDOR["NOMBRE_USUARIO"].ToString());
                        usuario.Constraseña1 = Convert.ToString(CONTENEDOR["CONTRASENA"].ToString());
                        usuario.Foto1 = Convert.ToString(CONTENEDOR["FOTO_USUARIO"].ToString());
                        usuario.Rol1 = Convert.ToString(CONTENEDOR["ROL"].ToString());

                        lista_devolver.Add(usuario);

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