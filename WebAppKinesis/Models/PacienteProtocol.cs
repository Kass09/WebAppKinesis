using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace WebAppKinesis.Models
{
    public class PacienteProtocol
    {
        MySqlDataReader lectorMysql;
        public int AddHistoria(Pacientes pac)
        {
            int estado = 0;
            try
            {
                if (!VerificarUsuario(pac.Cedula))
                {
                    string queryPac = $"INSERT INTO PACIENTES VALUES " +
                        $"( " +
                        $" '{pac.Cedula}', '{pac.Nombres}', '{pac.Direccion}', '{pac.Telefono}', '{pac.FechaNacimiento.ToShortDateString()}', " +
                        $" '{pac.Edad}', '{pac.Profesion}', '{pac.EstadoCivil}', '{pac.NumHijos}' " +
                        $")";

                    string queryHistoria = $"INSERT INTO HISTORIACLINICA VALUES " +
                        $"( NULL, " +
                        $" '{pac.HistPac.FechaRegistro}', '{pac.HistPac.DescEnfermedad}', '{pac.HistPac.OtraEnfermedad}', '{pac.HistPac.Peso}', " +
                        $" '{pac.HistPac.Talla}', '{pac.HistPac.Altura}', '{pac.HistPac.MasaMuscular}', '{pac.HistPac.Silueta}', '{pac.HistPac.CostumbreAlimenticias}', " +
                        $" '{pac.HistPac.ModoVida}', '{pac.HistPac.SiFuma}', '{pac.HistPac.SiAlcohol}', '{pac.HistPac.CalidadSueño}', '{pac.HistPac.DeportesPracticados}', '{pac.Cedula}' " +
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
                                    estado = 1;
                                }
                                else { estado = -1; }
                            }
                        }
                        else { estado = -1; }
                    }
                }
                else { estado = 2; }
            }
            catch (System.Exception)
            {
                estado = -1;
            }
            finally { DBHelper.CloseMySql(); }
            return estado;
        }

        public Boolean VerificarUsuario( string id)
        {
            Boolean estado = false;
            try
            {
                string consulta = $"SELECT cedula FROM PACIENTES x  WHERE x.CEDULA = '{id}'";
                var command = new MySqlCommand(consulta, DBHelper.Conection());
                lectorMysql = command.ExecuteReader();
                if (lectorMysql.Read())
                {
                    if (id == lectorMysql["Cedula"].ToString())
                    {
                        estado = true;
                    }
                    else { estado = false; }
                }
                lectorMysql.Close();
                DBHelper.CloseMySql();
            }
            catch (System.Exception) { throw; }
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
                        persona.FechaNacimiento = DateTime.Parse(lectorMysql["FechaNacimiento"].ToString());
                        persona.Edad = lectorMysql["Edad"].ToString();
                        persona.Profesion = lectorMysql["Profesion"].ToString();
                        persona.EstadoCivil = lectorMysql["EstadoCivil"].ToString();
                        persona.NumHijos = lectorMysql["NumHijos"].ToString();

                        persona.HistPac.Fecha = lectorMysql["FechaRegistro"].ToString();
                        persona.HistPac.DescEnfermedad = lectorMysql["DescEnfermedad"].ToString();
                        persona.HistPac.Peso = lectorMysql["Peso"].ToString();
                        persona.HistPac.Talla = lectorMysql["Talla"].ToString();
                    }
                }
                lectorMysql.Close();
                DBHelper.CloseMySql();
            }
            catch (System.Exception) { throw; }
            return listaPacientes;
        }

        public Pacientes ListarPaciente(string cedula)
        {
            Pacientes persona = new Pacientes() { HistPac = new HistoriaClinica()};
            try
            {
                string consulta = $"SELECT * FROM PACIENTES, HISTORIACLINICA WHERE PACIENTES.CEDULA = HISTORIACLINICA.CEDULAPAC AND PACIENTES.CEDULA = '{cedula}'";
                using (MySqlCommand command = new MySqlCommand(consulta, DBHelper.Conection()))
                {
                    lectorMysql = command.ExecuteReader();
                    if (lectorMysql.Read())
                    {
                        persona.Cedula = lectorMysql["Cedula"].ToString();
                        persona.Nombres = lectorMysql["Nombres"].ToString();
                        persona.Direccion = lectorMysql["Direccion"].ToString();
                        persona.Telefono = lectorMysql["Telefono"].ToString();
                        persona.FechaNacimiento = DateTime.Parse(lectorMysql["FechaNacimiento"].ToString());
                        persona.Edad = lectorMysql["Edad"].ToString();
                        persona.Profesion = lectorMysql["Profesion"].ToString();
                        persona.EstadoCivil = lectorMysql["EstadoCivil"].ToString();
                        persona.NumHijos = lectorMysql["NumeroHijos"].ToString();

                        persona.HistPac.Fecha = lectorMysql["FechaRegistro"].ToString();
                        persona.HistPac.DescEnfermedad = lectorMysql["DescEnfermedad"].ToString();
                        persona.HistPac.OtraEnfermedad = lectorMysql["OtraEnfermedad"].ToString();
                        persona.HistPac.Peso = lectorMysql["Peso"].ToString();
                        persona.HistPac.Talla = lectorMysql["Talla"].ToString();
                        persona.HistPac.Altura = lectorMysql["Altura"].ToString();
                        persona.HistPac.MasaMuscular = lectorMysql["MasaCorporal"].ToString();
                        persona.HistPac.CostumbreAlimenticias = lectorMysql["CostumbresAlimenticias"].ToString();
                        persona.HistPac.ModoVida = lectorMysql["ModoVida"].ToString();
                        persona.HistPac.SiFuma = lectorMysql["SiFuma"].ToString();
                        persona.HistPac.SiAlcohol = lectorMysql["SiAlcohol"].ToString();
                        persona.HistPac.CalidadSueño = lectorMysql["CalidadSueno"].ToString();
                        persona.HistPac.DeportesPracticados = lectorMysql["DeportesPracticados"].ToString();
                    }
                    else
                    {
                        persona = null;
                    }
                }
                lectorMysql.Close();
                DBHelper.CloseMySql();
            }
            catch (System.Exception) { throw; }
            return persona;
        }
         
    }
}