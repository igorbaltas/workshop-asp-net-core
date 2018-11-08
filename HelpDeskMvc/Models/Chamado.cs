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
        [Display(Name = "Número do chamado"), Key]
        public int idChamado { get; set; }
        public ChamadoStatus status { get; set; }
        public string descricaoChamado { get; set; }
        [Display(Name = "Problema")]
        public DateTime dataAbertura { get; set; }
        public DateTime dataEncerramento { get; set; }
        public string solucaoChamado { get; set; }
        public Usuario usuario { get; set; }
        [Display(Name = "Problema")]
        public Servico servico { get; set; }
        public int servicoId { get; set; }
        public int UsuarioId { get; set; }
        public int tecnicoId { get; set; }
        [Display(Name = "Departamento")]
        public Departamento departamento { get; set; }
        public int DepartamentoId { get; set; }
        public ICollection<Chamado> Listchamados = new List<Chamado>();



        public Chamado()
        {

        }

        public Chamado(int idChamado, ChamadoStatus status, string descricaoChamado, DateTime dataAbertura, DateTime dataEncerramento, string solucaoChamado, Usuario usuario, Servico servico, int servicoId, int usuarioId, int tecnicoId, Departamento departamento, int departamentoId)
        {
            this.idChamado = idChamado;
            this.status = status;
            this.descricaoChamado = descricaoChamado;
            this.dataAbertura = dataAbertura;
            this.dataEncerramento = dataEncerramento;
            this.solucaoChamado = solucaoChamado;
            this.usuario = usuario;
            this.servico = servico;
            this.servicoId = servicoId;
            UsuarioId = usuarioId;
            this.tecnicoId = tecnicoId;
            this.departamento = departamento;
            DepartamentoId = departamentoId;
        }
    }
}
