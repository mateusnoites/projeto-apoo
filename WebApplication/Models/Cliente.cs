using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Cliente : Usuario
    {
        public string Cpf { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
    }
}