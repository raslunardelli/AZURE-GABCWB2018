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
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;

namespace gabcwb2018_iaas
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1 : IService1
    {
        public string mensagem(string msg)
        {
            try
            {
                //using (var conn = new SqlConnection(db.conn("gabcwbpaasvm.brazilsouth.cloudapp.azure.com", "gabcwb2018", "sa", "xxx")))
                using (var conn = new SqlConnection(db.conn("gabcwb.database.windows.net", "gabcwb2018", "rafael", "xxx")))
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

                //using (StreamWriter sw = File.AppendText("C:\\gabcwb2018\\log.txt"))
                //{
                //    sw.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Mensagem Gravada");
                //}
                storageLog();

                return "OK";
            }
            catch (Exception exc)
            {
                return "ERRO - " + exc;
            }
        }



        public static void storageLog()
        {
            try
            {
                CloudStorageAccount storageAccount = new CloudStorageAccount(
                    new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
                    "gabcwb",
                    "xxx"), true);

                CloudFileClient fileClient = storageAccount.CreateCloudFileClient();

                CloudFileShare share = fileClient.GetShareReference("gabcwb");

                if (share.Exists())
                {
                    CloudFileDirectory rootDir = share.GetRootDirectoryReference();

                    var cloudFile = rootDir.GetFileReference("log.txt");

                    cloudFile.UploadText(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Mensagem Gravada");
                }
            }

            catch (Exception exc)
            {
                
            }
        }
    }
}