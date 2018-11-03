using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskMvc.Models
{
    public class Departamento
    {
        [Display(Name = "ID"), Key]
        public int idDpto { get; set; }
        [Display(Name = "Departamentos")]
        public string dsDpto { get; set; }
        public ICollection<Usuario> ListUsuarios { get; set; } = new List<Usuario>();

        public Departamento()
        {

        }

        public Departamento(int idDpto, string dsDpto)
        {
            this.idDpto = idDpto;
            this.dsDpto = dsDpto;
        }

        public void AddUsuario(Usuario usuario)
        {
            ListUsuarios.Add(usuario);
        }

       

    }
}
