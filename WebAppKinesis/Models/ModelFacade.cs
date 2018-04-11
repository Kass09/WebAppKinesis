using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppKinesis.Models
{
    public class ModelFacade
    {
        public int CheckLogin(string user, string pass)
        {
            return new LoginProtocol().LoginFindMySql(user, pass);
        }

        public int AddHistoria(Pacientes pac)
        {
            return new PacienteProtocol().AddHistoria(pac);
        }

        public Pacientes BuscarPaciente(string cedula)
        {
            return new PacienteProtocol().ListarPaciente(cedula);
        }
    }
}