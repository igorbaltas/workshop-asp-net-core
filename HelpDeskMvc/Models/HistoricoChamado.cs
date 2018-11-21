using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskMvc.Models
{
    public class HistoricoChamado
    {
        [Key]
        public int idLogChamado { get; set; }
        public string dsLog { get; set; }
        public DateTime dataLog { get; set; }
        public Chamado chamado { get; set; }
        public int ChamadoId { get; set; }
        public Usuario usuario { get; set; }
        public int UsuarioId { get; set; }

        public HistoricoChamado()
        {

        }

        public HistoricoChamado(int idLogChamado, string dsLog, DateTime dataLog, Chamado chamado, int chamadoId, Usuario usuario, int usuarioId)
        {
            this.idLogChamado = idLogChamado;
            this.dsLog = dsLog;
            this.dataLog = dataLog;
            this.chamado = chamado;
            ChamadoId = chamadoId;
            this.usuario = usuario;
            UsuarioId = usuarioId;
        }


    }
}
