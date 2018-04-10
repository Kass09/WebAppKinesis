using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppKinesis.Models
{
    public class DBHelper
    {
        private static MySqlConnection cnnMysql;
        private static string dataConectMysql = "datasource=127.0.0.1;port=3306; username=root;password=;database=kinesisdb;";

        public static MySqlConnection Conection()
        {
            try
            {
                cnnMysql = new MySqlConnection(dataConectMysql);
                cnnMysql.Open();
            }
            catch (MySqlException)
            { throw; }
            return cnnMysql;
        }
        public static void CloseMySql() { cnnMysql.Close(); }

    }
}
