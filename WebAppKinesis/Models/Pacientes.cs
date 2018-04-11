using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppKinesis.Models
{
    public class Pacientes
    {
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Edad { get; set; }
        public string Profesion { get; set; }
        public string EstadoCivil { get; set; }
        public string NumHijos { get; set; }

        public HistoriaClinica HistPac { get; set; }

    }
}