using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebAppKinesis.Models
{
    public class PacienteProtocol
    {
        MySqlDataReader lectorMysql;
        public Boolean AddHistoria(Pacientes pac)
        {
            Boolean estado = false;
            try
            {
                string queryPac = $"INSERT INTO PACIENTES VALUES" +
                    $"( " +
                    $" '{pac.Cedula}','{pac.Nombres}', '{pac.Direccion}', '{pac.Telefono}', " +
                    $" '{pac.FechaNacimiento.ToShortDateString()}', '{pac.Edad}', '{pac.EstadoCivil}, '{pac.NumHijos} " +
                    $")";

                string queryHistoria = $"INSERT INTO HISTORIACLINICA VALUES " +
                    $"(" +
                    $" '{pac.HistPac.FechaRegistro}', '{pac.HistPac.DescEnfermedad}', '{pac.HistPac.OtraEnfermedad}', '{pac.HistPac.Peso}', "  +
                    $" '{pac.HistPac.Talla}', '{pac.HistPac.MasaMuscular}', '{pac.HistPac.Altura}', '{pac.HistPac.Silueta}', '{pac.HistPac.CostumbreAlimenticias}', " +
                    $" '{pac.HistPac.ModoVida}', '{pac.HistPac.SiFuma}', '{pac.HistPac.SiAlcohol}', '{pac.HistPac.DeportesPracticados}' " +
                    $")";


                using (var command = new MySqlCommand(queryPac, DBHelper.Conection()))
                {
                    var x = command.ExecuteNonQuery();
                    if (x > 0)
                    {
                        using (var command1 = new MySqlCommand(queryHistoria, DBHelper.Conection()))
                        {
                            var y = command1.ExecuteNonQuery();
                            if (y > 0)
                            {
                                estado = true;
                            }
                            else { estado = false; }
                        }                        
                    }
                    else { estado = false; }                    
                }
            }
            catch (System.Exception)
            {
                estado = false;
            }
            finally { DBHelper.CloseMySql(); }
            return estado;
        }

        public List<Pacientes> BuscarHistorias()
        {
            List<Pacientes> listaPacientes = new List<Pacientes>();
            Pacientes persona = new Pacientes();
            try
            {
                string consulta = $"SELECT * FROM PACIENTES, HISTORIACLINICA WHERE PACIENTES.CEDULA = HISTORIACLINICA.CEDULAPAC";
                using(MySqlCommand command = new MySqlCommand(consulta, DBHelper.Conection()))
                {
                    lectorMysql = command.ExecuteReader();
                    while (lectorMysql.Read())
                    {
                        persona.Cedula = lectorMysql["Cedula"].ToString();
                        persona.Nombres = lectorMysql["Nombres"].ToString();
                        persona.Direccion = lectorMysql["Direccion"].ToString();
                        persona.Telefono = lectorMysql["Telefono"].ToString();
                        persona.FechaNacimiento = (DateTime) lectorMysql["FechaNacimiento"];
                        persona.Edad = lectorMysql["Edad"].ToString();

                        persona.HistPac.Fecha = lectorMysql["FechaRegistro"].ToString();
                        persona.HistPac.DescEnfermedad = lectorMysql["DescEnfermedad"].ToString();
                        persona.HistPac.Peso = lectorMysql["Peso"].ToString();
                        persona.HistPac.Talla = (float)lectorMysql["Talla"];
                    }
                }
                lectorMysql.Close();
                DBHelper.CloseMySql();
            }
            catch (System.Exception) { throw; }
            return listaPacientes;
        }

         
    }
}