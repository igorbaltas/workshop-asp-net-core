using HelpDeskMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace HelpDeskMvc.Services
{
    public class DepartamentoService
    {
        private readonly HelpDeskMvcContext _context;

        public DepartamentoService(HelpDeskMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> ListarDepartamentosAsync()
        {
            return await _context.Departamento.OrderBy(x => x.dsDpto).ToListAsync();
        }
    }
}
