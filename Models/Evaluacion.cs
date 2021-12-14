using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GETinTouch.Models
{
    public class Evaluacion
    {
        private int Id_evaluacion;
        private Expediente Id_expediente;
        private string Resultado;

        public int Id_evaluacion1 { get => Id_evaluacion; set => Id_evaluacion = value; }
        public Expediente Id_expediente1 { get => Id_expediente; set => Id_expediente = value; }
        public string Resultado1 { get => Resultado; set => Resultado = value; }

        public string Insert_Evaluacion_BD()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    String query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                        query = "EXEC I_EVALUACION ?,?,?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_evaluacion1, 1);
                    objeto_conexion.nuevo_parametro(Id_expediente1.Id_expediente1, 1);
                    objeto_conexion.nuevo_parametro(Resultado1, 2);

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
                return "Usted ya ha realizado esta evaluacion por favor solicita otra a su profesor";
            }
        }

        public string Delete_Evaluacion_BD()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    String query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    query = "EXEC D_EVALUACION ?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_evaluacion1, 1);

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

        public string Update_Evaluacion_BD()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    String query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    query = "EXEC U_EVALUACION ?,?,?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_evaluacion1, 1);
                    objeto_conexion.nuevo_parametro(Id_expediente1.Id_expediente1, 1);
                    objeto_conexion.nuevo_parametro(Resultado1, 2);

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
        public Evaluacion Select_Evaluacion()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            Evaluacion evaluacion = new Evaluacion();
            evaluacion.Id_evaluacion1 = -1;
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    string query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;
                    query = "EXEC S_EVALUACION ?";
                    objeto_conexion.nueva_consulta(query);
                    objeto_conexion.nuevo_parametro(Id_evaluacion1.ToString(), 2); ;
                    CONTENEDOR = objeto_conexion.busca();
                    while (CONTENEDOR.Read())
                    {

                        evaluacion.Id_evaluacion1 = Convert.ToInt32(CONTENEDOR["ID_EVALUACION"].ToString());

                        Expediente expediente = new Expediente();
                        expediente.Id_expediente1 = Convert.ToInt32(CONTENEDOR["ID_EXPEDIENTE"].ToString());
                        evaluacion.Id_expediente1 = expediente;

                        evaluacion.Resultado1 = Convert.ToString(CONTENEDOR["RESULTADO"].ToString());

                    }
                    objeto_conexion.conexion.Close();
                    objeto_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return evaluacion;
                }
                else
                {


                    return evaluacion;
                }
            }
            catch (Exception error)
            {
                evaluacion.Id_evaluacion1 = -2;
                return evaluacion;
            }
        }

        public List<Evaluacion> Select_All_Evaluacion_BD()
        {
            ConexionconBD objeto_conexion = new ConexionconBD();
            List<Evaluacion> lista_devolver = new List<Evaluacion>();
            try
            {
                if (objeto_conexion.inicializaBD())
                {
                    string query;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    query = "EXEC ST_EVALUACION";
                    objeto_conexion.nueva_consulta(query);
                    CONTENEDOR = objeto_conexion.busca();
                    while (CONTENEDOR.Read())
                    {

                        Evaluacion evaluacion = new Evaluacion();

                        evaluacion.Id_evaluacion1 = Convert.ToInt16(CONTENEDOR["ID_EVALUACION"].ToString());

                        Expediente expediente = new Expediente();
                        expediente.Id_expediente1 = Convert.ToInt16(CONTENEDOR["ID_EXPEDIENTE"].ToString());
                        evaluacion.Id_expediente1 = expediente;

                        evaluacion.Resultado1 = Convert.ToString(CONTENEDOR["RESULTADO"].ToString());


                        lista_devolver.Add(evaluacion);

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