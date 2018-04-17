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

namespace gabcwb2018_iaas
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1 : IService1
    {
        public string mensagem(string msg)
        {
            try
            {
                //using (var conn = new SqlConnection(db.conn()))
                //{


                //}



                return "OK";
            }
            catch (Exception exc)
            {
                return "ERRO - " + exc;
            }

        }
    }
}
