using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskMvc.Models
{
    public class Servico
    {
        [Display(Name = "ID"), Key]
        public int idServico { get; set; }
        public string dsServico { get; set; }
        public string slaServico { get; set; }
        public string criticidadeServico { get; set; }
        public ICollection<Chamado> ListChamados { get; set; } = new List<Chamado>();

        public Servico()
        {

        }

        public Servico(int idServico, string dsServico, string slaServico, string criticidadeServico)
        {
            this.idServico = idServico;
            this.dsServico = dsServico;
            this.slaServico = slaServico;
            this.criticidadeServico = criticidadeServico;
        }
    }
}
