using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskMvc.Models.ViewModels
{
    public class DetalheChamadoViewModel
    {
        public Chamado chamado { get; set; }
        public ICollection<HistoricoChamado> histChamado { get; set; }

        public string calcularTempoChamado(DateTime dataAbertura)
        {
            TimeSpan idadeChamado = (DateTime.Now - dataAbertura);
            return (idadeChamado.Days).ToString();
        }
    }
}
