using HelpDeskMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace HelpDeskMvc.Services
{
    public class ServicoService
    {
        private readonly HelpDeskMvcContext _context;

        public ServicoService(HelpDeskMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Servico>> ListarServicosAsync()
        {
            return await _context.Servico.OrderBy(x => x.dsServico).ToListAsync();
        }

    }
}
