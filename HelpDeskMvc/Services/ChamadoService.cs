using HelpDeskMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskMvc.Services
{
    public class ChamadoService
    {

        private readonly HelpDeskMvcContext _context;

        public ChamadoService(HelpDeskMvcContext context)
        {
            _context = context;
        }

        public List<Chamado> ListarChamados()
        {
            return _context.Chamado.ToList();
        }
    }
}
