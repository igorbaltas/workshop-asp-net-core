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
        [Display(Name = "Serviço")]
        public string dsServico { get; set; }
        [Display(Name = "SLA")]
        public string slaServico { get; set; }
        [Display(Name = "CRITICIDADE")]
        public string criticidadeServico { get; set; }
        public ICollection<Chamado> ListChamados { get; set; } = new List<Chamado>();
        public ICollection<Servico> ListCriticidade { get; set; }

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


        public List<Servico> ListarCriticidade()
        {
            return new List<Servico>
            {
            new Servico { criticidadeServico = "Baixo" },
            new Servico { criticidadeServico = "Médio" },
            new Servico { criticidadeServico = "Alto" },
            };
        }
    }
}
