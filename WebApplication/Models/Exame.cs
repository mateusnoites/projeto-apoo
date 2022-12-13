using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Exame
    {
        public long ExameId { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}