using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskMvc.Models.ViewModels
{
    public class UsuarioFormViewModel
    {
        public Usuario usuario { get; set; }
        public ICollection<Departamento> departamentos { get; set; }
    }
}
