using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Secretario : Usuario
    {
        [DataType(DataType.Date)]
        public DateTime Dt_admissao { get; set; }
    }
}