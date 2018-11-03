using HelpDeskMvc.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskMvc.Models
{
    public class Chamado
    {
        [Display(Name = "ID"), Key]
        public int idChamado { get; set; }
        public ChamadoStatus status { get; set; }
        public string descricaoChamado { get; set; }
        public DateTime dataAbertura { get; set; }
        public DateTime dataEncerramento { get; set; }
        public string solucaoChamado { get; set; }
        public Usuario usuarios { get; set; }
        public Servico servicos { get; set; }



        public Chamado()
        {

        }

        public Chamado(int idChamado, ChamadoStatus status, string descricaoChamado, DateTime dataAbertura, DateTime dataEncerramento, string solucaoChamado, Usuario usuarios, Servico servicos)
        {
            this.idChamado = idChamado;
            this.status = status;
            this.descricaoChamado = descricaoChamado;
            this.dataAbertura = dataAbertura;
            this.dataEncerramento = dataEncerramento;
            this.solucaoChamado = solucaoChamado;
            this.usuarios = usuarios;
            this.servicos = servicos;
        }
    }
}
