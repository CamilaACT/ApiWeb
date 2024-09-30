﻿using ApiProyecto.model.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProyecto.model.proc
{
    public class Menu
    {
        public static Respuesta listaMenu(int us_id)
        {

            Respuesta res = new Respuesta() { CodigoError = 0, Message = "Sin Resultados", Result = null };

            try
            {

                data.DAO.c_base_datos cb = new data.DAO.c_base_datos();
                System.Data.DataTable dt;
                string strCon = util.Conexion.Conexion.CadenaConexion();
                string[] vector = new string[1];
                cb.sp = "usp_Web_roles_B_roles";//poner el nombre correcto
                vector[0] = "@us_id,i," + us_id;

                dt = cb.consultar(vector, 1, strCon);
                res.CodigoError = cb.valo_erro;
                if (res.CodigoError == -1)
                {
                    res.Message = "OK";
                    res.Message = cb.valo_resp;
                    var dataAsList = DataTableToList(dt);
                    res.Result = dataAsList;

                }
                else
                {
                    res.Message = "Que pena me da tu caso";
                    res.Message = cb.valo_resp;
                }

            }
            catch (Exception ex)
            {
                res.CodigoError = -100;
                res.Message = "Error inesperado";
                res.Message = ex.Message;
            }
            return res;
        }

        public static List<Dictionary<string, object>> DataTableToList(DataTable dt)
        {
            var list = new List<Dictionary<string, object>>();

            foreach (DataRow row in dt.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    dict[col.ColumnName] = row[col];
                }
                list.Add(dict);
            }

            return list;
        }
    }
}
