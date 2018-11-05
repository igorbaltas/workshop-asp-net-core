using HelpDeskMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskMvc.Services
{
    public class DepartamentoService
    {
        private readonly HelpDeskMvcContext _context;

        public DepartamentoService(HelpDeskMvcContext context)
        {
            _context = context;
        }

        public List<Departamento> ListarDepartamentos()
        {
            return _context.Departamento.OrderBy(x => x.dsDpto).ToList();
        }
    }
}
