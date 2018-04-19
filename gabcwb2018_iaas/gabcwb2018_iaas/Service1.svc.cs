using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.IO;

namespace gabcwb2018_iaas
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1 : IService1
    {
        public string mensagem(string msg)
        {
            try
            {
                using (var conn = new SqlConnection(db.conn("gabcwbpaasvm.brazilsouth.cloudapp.azure.com", "gabcwb2018", "sa", "xxx")))
                {
                    string query = new StringBuilder().AppendFormat(
                    @"insert into mensagens values ('{0}')"
                    , msg).ToString();

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.CommandTimeout = 0;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                using (StreamWriter sw = File.AppendText("C:\\gabcwb2018\\log.txt"))
                {
                    sw.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Mensagem Gravada");
                }

                return "OK";
            }
            catch (Exception exc)
            {
                return "ERRO - " + exc;
            }
        }

    }
}