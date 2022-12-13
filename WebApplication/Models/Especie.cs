using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Especie
    {
        public long EspecieId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
    }
}