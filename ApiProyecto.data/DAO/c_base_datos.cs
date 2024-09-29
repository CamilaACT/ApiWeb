using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProyecto.data.DAO
{
    public class c_base_datos
    {

        public int valo_erro { get; set; }
        public string valo_resp { get; set; }
        string mensaje { get; set; }
        public string sp;

        public DataTable consultar(string[] vector, int nume_elem, string cnxstr)
        {
            // ejecuta un sp en la base de datos 
            // parametros: vector que contiene los parámetros del sp (nombre,tipo de dato,valor)
            // cnxstr cadena de conexion a la base de datos

            SqlConnection cn = new SqlConnection();
            SqlCommand cm;
            SqlParameter para;
            SqlParameter para_erro;
            int a;
            SqlDataAdapter da;
            DataTable dt;
            string[] tempo;
            string cadena;
            dt = new DataTable();

            try
            {
                valo_resp = "0";
                valo_erro = 0;
                mensaje = "0";
                if (cnxstr == null)
                {
                    mensaje = "1";
                    return dt;
                }

                cn = new SqlConnection(cnxstr);
                cn.Open();

                cm = new SqlCommand();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = sp;


                if (vector.Length > 0)
                {
                    foreach (string item in vector)
                    {

                        tempo = item.Split(',');
                        para = new SqlParameter();
                        para.ParameterName = tempo[0];
                        switch (tempo[1])
                        {
                            case "i":
                            case "m":
                            case "d":
                                {
                                    para.DbType = DbType.Decimal;
                                    break;
                                }

                            case "v":
                            case "c":
                                {
                                    para.DbType = DbType.String;
                                    break;
                                }

                            case "f":
                                {
                                    para.DbType = DbType.Date;
                                    break;
                                }
                        }
                        para.Direction = ParameterDirection.Input;
                        para.Value = tempo[2];
                        cm.Parameters.Add(para);

                    }
                }


                para = new SqlParameter();
                para.ParameterName = "@codigo";
                para.DbType = DbType.String;
                para.Size = 5000;
                para.Direction = ParameterDirection.Output;
                cm.Parameters.Add(para);

                para_erro = new SqlParameter();
                para_erro.ParameterName = "@error";
                para_erro.DbType = DbType.Int16;
                para_erro.Direction = ParameterDirection.Output;
                cm.Parameters.Add(para_erro);

                da = new SqlDataAdapter(cm);

                da.Fill(dt);
                da.Dispose();
                cn.Close();

                if (para.Value == null)
                    valo_resp = "-100";
                else
                    valo_resp = para.Value.ToString();

                if (para_erro.Value == null)
                    valo_erro = -100;
                else
                    valo_erro = int.Parse(para_erro.Value.ToString());


                para = null/* TODO Change to default(_) if this is not a reference type */;
                cm = null/* TODO Change to default(_) if this is not a reference type */;
                cn.Close();

            }
            catch (Exception ex)
            {
                mensaje = "ERROR: No se pudo generar el reporte" + ex.ToString();
                valo_resp = "Error de conexión";
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();

            }
            return dt;


        }

    }
}