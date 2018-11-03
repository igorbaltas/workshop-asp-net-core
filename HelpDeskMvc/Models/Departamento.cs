using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskMvc.Models
{
    public class Departamento
    {
        [Display(Name = "ID"), Key]
        public int idDpto { get; set; }
        public string dsDpto { get; set; }
    }
}
