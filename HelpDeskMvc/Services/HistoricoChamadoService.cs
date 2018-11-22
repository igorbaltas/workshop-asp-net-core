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

        public List<HistoricoChamado> ListarHistorico(int id)
        {
            return _context.HistoricoChamado.Where(x => x.ChamadoId == id).Include(x => x.chamado).ToList();
        }




    }
}
