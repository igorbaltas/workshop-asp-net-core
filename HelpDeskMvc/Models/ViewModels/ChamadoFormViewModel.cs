using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskMvc.Models.ViewModels
{
    public class ChamadoFormViewModel
    {
        public Chamado chamado { get; set; }
        public ICollection<Servico> servicos { get; set; }
        public ICollection<Departamento> departamentos { get; set; }
    }
}
