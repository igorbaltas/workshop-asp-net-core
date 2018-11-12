using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskMvc.Models.ViewModels
{
    public class EditarChamadoFormViewModel
    {
        public Chamado chamado { get; set; }
        public HistoricoChamado logChamado { get; set; }
        public Servico servico { get; set; }
        public ICollection<HistoricoChamado> histChamado { get; set; }
    }
}
