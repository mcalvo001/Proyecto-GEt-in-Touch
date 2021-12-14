using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GETinTouch.Models
{
    public class Mensaje
    {
        private int Id_mensaje;
        private Usuario Id_usuario;
        private Chat Id_chat;
        private string Texto;
        private DateTime Fecha_hora; 

        public int Id_mensaje1 { get => Id_mensaje; set => Id_mensaje = value; }
        public Usuario Id_usuario1 { get => Id_usuario; set => Id_usuario = value; }
        public Chat Id_chat1 { get => Id_chat; set => Id_chat = value; }
        public string Texto1 { get => Texto; set => Texto = value; }
        public DateTime Fecha_hora1 { get => Fecha_hora; set => Fecha_hora = value; }

        public string Insert_Mensaje_BD()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    String query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    query = "EXEC I_MENSAJE ?,?,?,?,?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_mensaje1, 1);
                    objeto_conexion.nuevo_parametro(Id_usuario1.Id_usuario1, 1);
                    objeto_conexion.nuevo_parametro(Id_chat1.Id_chat1, 2);
                    objeto_conexion.nuevo_parametro(Texto1, 2);
                    objeto_conexion.nuevo_parametro(Fecha_hora1, 4);


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

        public string Delete_Mensaje_BD()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    String query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    query = "EXEC D_MENSAJE_CHAT ?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_chat1.Id_chat1, 1);

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

        public string Update_Mensaje_BD()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    String query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    query = "EXEC U_MENSAJE ?,?,?,?,?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_mensaje1, 1);
                    objeto_conexion.nuevo_parametro(Id_usuario1.Id_usuario1, 1);
                    objeto_conexion.nuevo_parametro(Id_chat1.Id_chat1, 2);
                    objeto_conexion.nuevo_parametro(Texto1, 2);
                    objeto_conexion.nuevo_parametro(Fecha_hora1, 4);

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
        public Mensaje Select_Mensaje()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            Mensaje mensaje = new Mensaje();
            mensaje.Texto1 = "NO EXISTE";
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    string query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;
                    query = "EXEC S_MENSAJE ?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_mensaje1.ToString(), 2); ;
                    CONTENEDOR = objeto_conexion.busca();
                    while (CONTENEDOR.Read())
                    {

                        mensaje.Id_mensaje1 = Convert.ToInt16(CONTENEDOR["ID_MENSAJE"].ToString());

                        Usuario usuario = new Usuario();
                        usuario.Id_usuario1 = Convert.ToInt16(CONTENEDOR["ID_USUARIO"].ToString());
                        mensaje.Id_usuario1 = usuario;

                        Chat chat = new Chat();
                        chat.Id_chat1 = Convert.ToInt16(CONTENEDOR["ID_CHAT"].ToString());
                        mensaje.Id_chat1 = chat;

                        mensaje.Texto1 = Convert.ToString(CONTENEDOR["TEXTO"].ToString());
                        mensaje.Fecha_hora1 = Convert.ToDateTime(CONTENEDOR["FECHA_HORA"].ToString());


                    }
                    objeto_conexion.conexion.Close();
                    objeto_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return mensaje;
                }
                else
                {


                    return mensaje;
                }
            }
            catch (Exception error)
            {
                mensaje.Texto1 = "Error";
                return mensaje;
            }
        }

        public List<Mensaje> Select_MensajexChat()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            List<Mensaje> lista_devolver = new List<Mensaje>();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    string query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    query = "EXEC S_MENSAJExCHAT ?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_chat1.Id_chat1.ToString(), 2);

                    CONTENEDOR = objeto_conexion.busca();
                    while (CONTENEDOR.Read())
                    {

                        Mensaje mensaje = new Mensaje();

                        mensaje.Id_mensaje1 = Convert.ToInt32(CONTENEDOR["ID_MENSAJE"].ToString());

                        Usuario usuario = new Usuario();
                        usuario.Id_usuario1 = Convert.ToInt32(CONTENEDOR["ID_USUARIO"].ToString());
                        mensaje.Id_usuario1 = usuario;

                        Chat chat = new Chat();
                        chat.Id_chat1 = Convert.ToInt32(CONTENEDOR["ID_CHAT"].ToString());
                        mensaje.Id_chat1 = chat;

                        mensaje.Texto1 = Convert.ToString(CONTENEDOR["TEXTO"].ToString());
                        mensaje.Fecha_hora1 = Convert.ToDateTime(CONTENEDOR["FECHA_HORA"].ToString());
                        lista_devolver.Add(mensaje);

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
        public List<Mensaje> Select_All_Mensaje_BD()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            List<Mensaje> lista_devolver = new List<Mensaje>();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    string query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    query = "EXEC ST_MENSAJE";
                    objeto_conexion.nueva_consulta(query);
                    CONTENEDOR = objeto_conexion.busca();
                    while (CONTENEDOR.Read())
                    {
                        Mensaje mensaje = new Mensaje();

                        mensaje.Id_mensaje1 = Convert.ToInt16(CONTENEDOR["ID_MENSAJE"].ToString());

                        Usuario usuario = new Usuario();
                        usuario.Id_usuario1 = Convert.ToInt16(CONTENEDOR["ID_USUARIO"].ToString());
                        mensaje.Id_usuario1 = usuario;

                        Chat chat = new Chat();
                        chat.Id_chat1 = Convert.ToInt16(CONTENEDOR["ID_CHAT"].ToString());
                        mensaje.Id_chat1 = chat;

                        mensaje.Texto1 = Convert.ToString(CONTENEDOR["TEXTO"].ToString());
                        mensaje.Fecha_hora1 = Convert.ToDateTime(CONTENEDOR["FECHA_HORA"].ToString());
                        lista_devolver.Add(mensaje);

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