using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskMvc.Models
{
    public class Usuario
    {
        [Display(Name = "ID"), Key]
        public int idUsuario { get; set; }
        [Display(Name = "Nome")]
        public string nomeUsuario { get; set; }
        [Display(Name = "Login")]
        public string loginUsuario { get; set; }
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string senhaUsuario { get; set; }
        [Display(Name = "Situação")]
        public string situacaoUsuario { get; set; }
        [Display(Name = "Perfil")]
        public string nvlAcesso { get; set; }
        public Departamento departamento  { get; set; }
        public int DepartamentoId { get; set; }
        public ICollection<Chamado> Listchamados = new List<Chamado>();

        public Usuario()
        {

        }

        public Usuario(int idUsuario, string nomeUsuario, string loginUsuario, string senhaUsuario, string situacaoUsuario, string nvlAcesso, Departamento departamento)
        {
            this.idUsuario = idUsuario;
            this.nomeUsuario = nomeUsuario;
            this.loginUsuario = loginUsuario;
            this.senhaUsuario = senhaUsuario;
            this.situacaoUsuario = situacaoUsuario;
            this.nvlAcesso = nvlAcesso;
            this.departamento = departamento;
        }

        public void AbrirChamado(Chamado chamado)
        {
            Listchamados.Add(chamado);
        }

        /*
        public double TotalChamados(DateTime inicio, DateTime final)
        {
            return Listchamado.Where(chamado => chamado.dataAbertura >= inicio && chamado.dataEncerramento <= final).Count(chamado => Listchamado);
        }*/
    }
}
