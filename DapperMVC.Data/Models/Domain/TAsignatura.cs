using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperMVC.Data.Models.Domain
{
    public class TAsignatura
    {
        public int IdAsignatura { get; set; }
        public string CodAsignatura { get; set; } = string.Empty;
        public int IdTipoAsignatura { get; set; }
        public decimal ECTS { get; set; }
        public string Asignatura { get; set; } = string.Empty;
        public bool EsPersonalizable { get; set; }
        public decimal? Horas { get; set; }
        public int? IdModalidad { get; set; }
        public bool PublicarWeb { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }
    }
}
