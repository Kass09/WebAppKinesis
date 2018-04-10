using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppKinesis.Models
{
    public class LoginProtocol
    {
        MySqlDataReader lectorMysql;

        public bool LoginUserMySql(string user)
        {
            bool es = false;
            try
            {
                string consulta = $"SELECT Usuario FROM USERLOGIN x  WHERE x.USUARIO = '{user}'";
                var command = new MySqlCommand(consulta, DBHelper.Conection());
                lectorMysql = command.ExecuteReader();
                if (lectorMysql.Read())
                {
                    if (user == lectorMysql["Usuario"].ToString())
                    {
                        es = true;
                    }
                    else { es = false; }
                }
                lectorMysql.Close();
                DBHelper.CloseMySql();
            }
            catch (System.Exception) { throw; }
            return es;
        }

        public int LoginFindMySql(string user, string pass)
        {
            int estado = 0;
            try
            {
                if (LoginUserMySql(user))
                {
                    string consulta = $"SELECT usuario, contrasena from USERLOGIN x  where x.usuario = '{user}' and x.contrasena = '{pass}'";
                    var command = new MySqlCommand(consulta, DBHelper.Conection());
                    lectorMysql = command.ExecuteReader();
                    if (lectorMysql.Read())
                    {
                        if (user == lectorMysql["usuario"].ToString() && pass == lectorMysql["contrasena"].ToString())
                        {
                            estado = 1;
                        }
                    }
                    else
                    {
                        estado = 2;
                    }
                }
                else
                {
                    estado = 3;
                }

            }
            catch (System.Exception)
            {

                throw;
            }
            finally { DBHelper.CloseMySql(); lectorMysql.Close(); }
            return estado;
        }
    }
}