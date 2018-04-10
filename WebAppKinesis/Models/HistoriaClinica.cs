using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppKinesis.Models
{
    public class HistoriaClinica
    {
        public DateTime FechaRegistro { get => DateTime.Now;}
        public string Fecha { get; set; }
        
        public string DescEnfermedad { get; set; }
        public string OtraEnfermedad { get; set; }
        public string Peso { get; set; }
        public float Talla { get; set; }
        public float MasaMuscular { get; set; }
        public float Altura { get; set; }
        public string Silueta { get; set; }
        public string CostumbreAlimenticias { get; set; }

        public string ModoVida { get; set; }
        public string SiFuma { get; set; }
        public string SiAlcohol { get; set; }
        public string CalidadSueño { get; set; }
        public string DeportesPracticados { get; set; }
    }
}