using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Configuration;

namespace GETinTouch.Models
{
    public class ConexionconBD
    {

        public OleDbConnection conexion;
        public OleDbCommand comando;
        OleDbTransaction transaccion;

        public bool inicializaBD()
        {
            string connStr = ConfigurationManager.ConnectionStrings["conexiondeprueba"].ConnectionString;
            conexion = new OleDbConnection(connStr);
            try
            {
                conexion.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public OleDbDataReader busca()
        {
            OleDbDataReader busca_int;
            comando.Prepare();
            busca_int = comando.ExecuteReader();
            comando.CommandTimeout = 0;
            return busca_int;

        }
        public bool nueva_consulta(String _Consulta)
        {
            comando = new OleDbCommand(_Consulta, conexion);
            return false;
        }
        public bool nuevo_parametro(Object _PARAMETRO, Int16 _TIPO)
        {
            OleDbParameter Parametro;
            switch (_TIPO)
            {
                case 1:
                    Parametro = comando.Parameters.Add("@InputParm", OleDbType.BigInt);
                    Parametro.Value = _PARAMETRO;
                    break;
                case 2:

                    Parametro = comando.Parameters.Add("@InputParm", OleDbType.VarChar, 2500);
                    Parametro.Value = _PARAMETRO;
                    break;
                case 3:

                    Parametro = comando.Parameters.Add("@InputParm", OleDbType.Decimal, 10);
                    Parametro.Value = _PARAMETRO;
                    Parametro.Precision = 10;
                    Parametro.Scale = 2;
                    break;
                case 4:

                    Parametro = comando.Parameters.Add("@InputParm", OleDbType.Date);
                    Parametro.Value = _PARAMETRO;
                    break;

            }
            return false;
        }
        public bool ejecutasql(String sql) /*Transacciones*/
        {
            inicializaBD();
            transaccion = conexion.BeginTransaction();
            try
            {
                comando = new OleDbCommand(sql, conexion);
                comando.Transaction = transaccion;
                comando.ExecuteNonQuery();
                transaccion.Commit();
                return true;
            }
            catch (Exception)
            {
                transaccion.Rollback();
                return false;

            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
                /*cerrar la conexión base de datos para no sobrecargar*/
            }

        }
        public void cuadricula(string csql, System.Data.DataSet aux) /*No se usa mucho, pero devuelve el oldb.data con todas las filas de la consulta*/
        {
            inicializaBD();
            OleDbDataAdapter da = new OleDbDataAdapter(csql, conexion);
            da.Fill(aux);


        }
        public ConexionconBD()
        {

        }


    }
}