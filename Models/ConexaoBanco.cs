using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace AgendaTelefonica.Models
{
    public class ConexaoBanco
    {
        #region DECLARAÇÃO DE VARIÁVEIS
        //Define cadeia de conexão
        public static string connString = @"Server=DESKTOP-C5VR0B7\SQLEXPRESS;Integrated Security=true;Initial Catalog=CONTEC;Trusted_Connection=true";
        #endregion

        #region MÉTODOS
        public void ConectaBD(string strconn)
        {
            //Instancia uma nova conexão de acordo com a string
            SqlConnection conn = new SqlConnection(strconn);

            try
            {
                //Abre Conexão
                conn.Open();
            }
            catch (Exception e)
            {
                //Fecha Conexão
                conn.Close();
                throw e;
            }
            finally
            {
                //Fecha Conexão
                conn.Close();
            }

        }
        #endregion
    }
}