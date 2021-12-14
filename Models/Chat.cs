using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GETinTouch.Models
{
    public class Chat
    {
        private int Id_chat;
        private Usuario Id_usuarioI;
        private Usuario Id_usuarioII;

        public int Id_chat1 { get => Id_chat; set => Id_chat = value; }
        public Usuario Id_usuarioI1 { get => Id_usuarioI; set => Id_usuarioI = value; }
        public Usuario Id_usuarioII1 { get => Id_usuarioII; set => Id_usuarioII = value; }

        public string Insert_Chat_BD()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    String query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    query = "EXEC I_CHAT ?,?,?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_chat1, 1);
                    objeto_conexion.nuevo_parametro(Id_usuarioI1.Id_usuario1, 1);
                    objeto_conexion.nuevo_parametro(Id_usuarioII1.Id_usuario1, 1);

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

        public string Delete_Chat_BD()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    String query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    query = "EXEC D_CHAT ?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_chat1, 1);

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

        public string Update_Chat_BD()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    String query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    query = "EXEC U_CHAT ?,?,?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_chat1, 1);
                    objeto_conexion.nuevo_parametro(Id_usuarioI1.Id_usuario1, 1);
                    objeto_conexion.nuevo_parametro(Id_usuarioII1.Id_usuario1, 1); ;

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
        public Chat Select_Chat()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            Chat chat = new Chat();
            chat.Id_chat1 = -1;
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    string query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;
                    query = "EXEC S_CHAT ?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_chat1.ToString(), 2); ;
                    CONTENEDOR = objeto_conexion.busca();
                    while (CONTENEDOR.Read())
                    {

                        chat.Id_chat1 = Convert.ToInt32(CONTENEDOR["ID_CHAT"].ToString());

                        Usuario usuario1 = new Usuario();
                        usuario1.Id_usuario1 = Convert.ToInt32(CONTENEDOR["ID_USUARIO1"].ToString());
                        chat.Id_usuarioI1 = usuario1;

                        Usuario usuario2 = new Usuario();
                        usuario2.Id_usuario1 = Convert.ToInt32(CONTENEDOR["ID_USUARIO1"].ToString());
                        chat.Id_usuarioII1 = usuario2;



                    }
                    objeto_conexion.conexion.Close();
                    objeto_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return chat;
                }
                else
                {


                    return chat;
                }
            }
            catch (Exception error)
            {
                chat.Id_chat1 = -2;
                return chat;
            }
        }

        public List<Chat> Select_ChatxUsuario()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            List<Chat> lista_devolver = new List<Chat>();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    string query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    query = "EXEC S_CHATxUSUARIO ?, ?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_usuarioI1.Id_usuario1.ToString(), 2);
                    objeto_conexion.nuevo_parametro(Id_usuarioII1.Id_usuario1.ToString(), 2);
                    CONTENEDOR = objeto_conexion.busca();
                    while (CONTENEDOR.Read())
                    {

                        Chat chat = new Chat();

                        chat.Id_chat1 = Convert.ToInt32(CONTENEDOR["ID_CHAT"].ToString());

                        Usuario usuario1 = new Usuario();
                        usuario1.Id_usuario1 = Convert.ToInt32(CONTENEDOR["ID_USUARIO1"].ToString());
                        chat.Id_usuarioI1 = usuario1;

                        Usuario usuario2 = new Usuario();
                        usuario2.Id_usuario1 = Convert.ToInt32(CONTENEDOR["ID_USUARIO2"].ToString());
                        chat.Id_usuarioII1 = usuario2;


                        lista_devolver.Add(chat);

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
    
        public List<Chat> Select_All_Chat_BD()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            List<Chat> lista_devolver = new List<Chat>();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    string query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    query = "EXEC ST_CHAT";
                    objeto_conexion.nueva_consulta(query);
                    CONTENEDOR = objeto_conexion.busca();
                    while (CONTENEDOR.Read())
                    {

                        Chat chat = new Chat();

                        chat.Id_chat1 = Convert.ToInt32(CONTENEDOR["ID_CHAT"].ToString());

                        Usuario usuario1 = new Usuario();
                        usuario1.Id_usuario1 = Convert.ToInt32(CONTENEDOR["ID_USUARIO1"].ToString());
                        chat.Id_usuarioI1 = usuario1;

                        Usuario usuario2 = new Usuario();
                        usuario2.Id_usuario1 = Convert.ToInt32(CONTENEDOR["ID_USUARIO2"].ToString());
                        chat.Id_usuarioII1 = usuario2;


                        lista_devolver.Add(chat);

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