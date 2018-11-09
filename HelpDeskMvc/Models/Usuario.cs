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

        [Required(ErrorMessage = "{0} obrigatório")]
        [StringLength (100, MinimumLength = 3, ErrorMessage = "{0} deve conter entre {2} e {1} caracteres")]
        [Display(Name = "Nome")]
        public string nomeUsuario { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "{0} deve conter entre {2} e {1}")]
        [Display(Name = "Login")]
        public string loginUsuario { get; set; }

        [Required(ErrorMessage = "{0} obrigatória")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} deve conter entre {2} e {1}")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string senhaUsuario { get; set; }

        [Display(Name = "Situação")]
        public string situacaoUsuario { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Perfil")]
        public string nvlAcesso { get; set; }

        [Display(Name = "Departamento")]
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
