using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModels
{
    public class CheckBoxViewModel
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public bool Checked { get; set; }
    }
}