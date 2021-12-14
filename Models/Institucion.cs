using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GETinTouch.Models
{
    public class Institucion
    {
        private int Id_institucion;
        private string Nombre_institucion;
        private string Email;
        private string Telefonol;
        private string Tipo;
        private string Foto;

        public int Id_institucion1 { get => Id_institucion; set => Id_institucion = value; }
        public string Nombre_institucion1 { get => Nombre_institucion; set => Nombre_institucion = value; }
        public string Email1 { get => Email; set => Email = value; }
        public string Telefonol1 { get => Telefonol; set => Telefonol = value; }
        public string Tipo1 { get => Tipo; set => Tipo = value; }
        public string Foto1 { get => Foto; set => Foto = value; }

        public string Insert_Institucion_BD()
            {
                ConexionconBD objeto_conexion = new ConexionconBD();
                try
                {
                    if (objeto_conexion.inicializaBD())
                    {
                        String query;
                        System.Data.OleDb.OleDbDataReader CONTENEDOR;

                        query = "EXEC I_INSTITUCION ?,?,?,?,?";
                        objeto_conexion.nueva_consulta(query);
                        objeto_conexion.nuevo_parametro(Id_institucion1, 1);
                        objeto_conexion.nuevo_parametro(Nombre_institucion1, 2);
                        objeto_conexion.nuevo_parametro(Email1, 2);
                        objeto_conexion.nuevo_parametro(Telefonol1, 2);
                        objeto_conexion.nuevo_parametro(Tipo1, 2);
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

            public string Delete_Institucion_BD()
            {
                ConexionconBD objeto_conexion = new ConexionconBD();
                try
                {
                    if (objeto_conexion.inicializaBD())
                    {
                        String query;
                        System.Data.OleDb.OleDbDataReader CONTENEDOR;

                        query = "EXEC D_INSTITUCION ?";
                        objeto_conexion.nueva_consulta(query);
                        objeto_conexion.nuevo_parametro(Id_institucion1, 1);

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

            public string Update_Institucion_BD()
            {
                ConexionconBD objeto_conexion = new ConexionconBD();
                try
                {
                    if (objeto_conexion.inicializaBD())
                    {
                        String query;
                        System.Data.OleDb.OleDbDataReader CONTENEDOR;

                        query = "EXEC U_INSTITUCION ?,?,?,?,?";
                        objeto_conexion.nueva_consulta(query);
                        objeto_conexion.nuevo_parametro(Id_institucion1, 1);
                        objeto_conexion.nuevo_parametro(Nombre_institucion1, 2);
                        objeto_conexion.nuevo_parametro(Email1, 2);
                        objeto_conexion.nuevo_parametro(Telefonol1, 2);
                        objeto_conexion.nuevo_parametro(Tipo1, 2);
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
            public Institucion Select_Institucion()
            {
                ConexionconBD objeto_conexion = new ConexionconBD();
                Institucion institucion = new Institucion();
                institucion.Nombre_institucion1 = "NO EXISTE";
                try
                {
                    if (objeto_conexion.inicializaBD())
                    {
                        string query;
                        System.Data.OleDb.OleDbDataReader CONTENEDOR;
                        query = "EXEC S_INSTITUCION ?";
                        objeto_conexion.nueva_consulta(query);
                        objeto_conexion.nuevo_parametro(Id_institucion1.ToString(), 2); ;
                        CONTENEDOR = objeto_conexion.busca();
                        while (CONTENEDOR.Read())
                        {

                        institucion.Id_institucion1 = Convert.ToInt16(CONTENEDOR["ID_INSTITUCION"].ToString());
                        institucion.Nombre_institucion1 = Convert.ToString(CONTENEDOR["NOMBRE_INSTITUCION"].ToString());
                        institucion.Email1 = Convert.ToString(CONTENEDOR["EMAIL"].ToString());
                        institucion.Telefonol1 = Convert.ToString(CONTENEDOR["TELEFONO"].ToString());
                        institucion.Tipo1 = Convert.ToString(CONTENEDOR["TIPO"].ToString());
                        institucion.Foto1 = Convert.ToString(CONTENEDOR["FOTO"].ToString());

                    }
                        objeto_conexion.conexion.Close();
                        objeto_conexion.conexion.Dispose();
                        CONTENEDOR.Close();
                        return institucion;
                    }
                    else
                    {


                        return institucion;
                    }
                }
                catch (Exception error)
                {
                institucion.Nombre_institucion1 = "Error";
                    return institucion;
                }
            }

            public List<Institucion> Select_All_Institucion_BD()
            {
                ConexionconBD objeto_conexion = new ConexionconBD();
                List<Institucion> lista_devolver = new List<Institucion>();
                try
                {
                    if (objeto_conexion.inicializaBD())
                    {
                        string query;
                        System.Data.OleDb.OleDbDataReader CONTENEDOR;

                        query = "EXEC ST_INSTITUCION";
                        objeto_conexion.nueva_consulta(query);
                        CONTENEDOR = objeto_conexion.busca();
                        while (CONTENEDOR.Read())
                        {
                            Institucion institucion = new Institucion();
                            institucion.Id_institucion1 = Convert.ToInt16(CONTENEDOR["ID_INSTITUCION"].ToString());
                            institucion.Nombre_institucion1 = Convert.ToString(CONTENEDOR["NOBRE_INSTITUCION"].ToString());
                            institucion.Email1 = Convert.ToString(CONTENEDOR["EMAIL"].ToString());
                            institucion.Telefonol1 = Convert.ToString(CONTENEDOR["TELEFONO"].ToString());
                            institucion.Tipo1 = Convert.ToString(CONTENEDOR["TIPO"].ToString());
                            institucion.Foto1 = Convert.ToString(CONTENEDOR["FOTO"].ToString());
                        lista_devolver.Add(institucion);

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