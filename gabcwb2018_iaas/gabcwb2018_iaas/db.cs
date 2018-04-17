using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gabcwb2018_iaas
{
    public class db
    {
        public static string conn(string ip, string db, string user, string pass)
        {
            return "Server=tcp:" + ip
            + ",1433;Initial Catalog=" + db
            + ";Persist Security Info=False;user id=" + user
            + ";password=" + pass
            + ";MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }
    }
}