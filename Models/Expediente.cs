using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GETinTouch.Models
{
    public class Expediente
    {
        private int Id_expediente;
        private Usuario Id_usuario;
        private DateTime Fecha_realizacion;

        public int Id_expediente1 { get => Id_expediente; set => Id_expediente = value; }
        public Usuario Id_usuario1 { get => Id_usuario; set => Id_usuario = value; }
        public DateTime Fecha_realizacion1 { get => Fecha_realizacion; set => Fecha_realizacion = value; }

        public string Insert_Expediente_BD()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    String query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    query = "EXEC I_EXPEDIENTE ?,?,?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_expediente1, 1);
                    objeto_conexion.nuevo_parametro(Id_usuario1.Id_usuario1, 1);
                    objeto_conexion.nuevo_parametro(Fecha_realizacion1, 4);

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

        public string Delete_Expediente_BD()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    String query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    query = "EXEC D_EXPEDIENTE ?";
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

        public string Update_Expediente_BD()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    String query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    query = "EXEC U_EXPEDIENTE ?,?,?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_expediente1, 1);
                    objeto_conexion.nuevo_parametro(Id_usuario1.Id_usuario1, 1);
                    objeto_conexion.nuevo_parametro(Fecha_realizacion1, 4);

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
        public Expediente Select_Expediente()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            Expediente expediente = new Expediente();
            expediente.Id_expediente1 = -1;
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    string query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;
                    query = "EXEC S_EXPEDIENTE ?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_expediente1.ToString(), 2); ;
                    CONTENEDOR = objeto_conexion.busca();
                    while (CONTENEDOR.Read())
                    {

                        expediente.Id_expediente1 = Convert.ToInt16(CONTENEDOR["ID_EXPEDIENTE"].ToString());

                        Usuario usuario = new Usuario();
                        usuario.Id_usuario1 = Convert.ToInt16(CONTENEDOR["ID_USUARIO"].ToString());
                        expediente.Id_usuario1 = usuario;

                        expediente.Fecha_realizacion1 = Convert.ToDateTime(CONTENEDOR["FECHA_REALIZACION"].ToString());

                    }
                    objeto_conexion.conexion.Close();
                    objeto_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return expediente;
                }
                else
                {


                    return expediente;
                }
            }
            catch (Exception error)
            {
                expediente.Id_expediente1 = -2;
                return expediente;
            }
        }

        public List<Expediente> Select_All_Expediente_BD()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            List<Expediente> lista_devolver = new List<Expediente>();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    string query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    query = "EXEC ST_EXPEDIENTE";
                    objeto_conexion.nueva_consulta(query);
                    CONTENEDOR = objeto_conexion.busca();
                    while (CONTENEDOR.Read())
                    {

                        Expediente expediente = new Expediente();

                        expediente.Id_expediente1 = Convert.ToInt16(CONTENEDOR["ID_EXPEDIENTE"].ToString());

                        Usuario usuario = new Usuario();
                        usuario.Id_usuario1 = Convert.ToInt16(CONTENEDOR["ID_USUARIO"].ToString());
                        expediente.Id_usuario1 = usuario;

                        expediente.Fecha_realizacion1 = Convert.ToDateTime(CONTENEDOR["FECHA_REALIZACION"].ToString());


                        lista_devolver.Add(expediente);

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
