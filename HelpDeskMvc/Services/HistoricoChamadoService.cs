using HelpDeskMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HelpDeskMvc.Services.Exceptions;

namespace HelpDeskMvc.Services
{
    public class HistoricoChamadoService
    {

        private readonly HelpDeskMvcContext _context;

        public HistoricoChamadoService(HelpDeskMvcContext context)
        {
            _context = context;
        }

        /*public List<HistoricoChamado> ListarHistorico()
        {

         //   return _context.Chamado.Where(x => x.status == Models.Enums.ChamadoStatus.Aberto).Include(x => x.servico)
               // .ToList();
        }*/

        /*public HistoricoChamado PesquisarId(int id)
        {
            return _context.chamado.Include(x => x.servico).Include(x => x.departamento).Include(x => x.usuario).Include(x => x.tecnico).FirstOrDefault(x => x.idChamado == id);


        }*/
    }
}
