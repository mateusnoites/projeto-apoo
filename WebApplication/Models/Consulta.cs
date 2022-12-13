using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication.Models.ViewModels;

namespace WebApplication.Models
{
    public class Consulta
    {
        public long ConsultaId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataHora { get; set; }
        public string Sintomas { get; set; }
        public long PetId { get; set; }
        public long UsuarioId { get; set; }
        public Pet Pet { get; set; }
        public Veterinario Veterinario { get; set; }
        public List<CheckBoxViewModel> ExamesCK { get; set; }
        public virtual ICollection<Exame> Exames { get; set; }
    }
}