using HelpDeskMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskMvc.Services
{
    public class InventarioService
    {
        private readonly HelpDeskMvcContext _context;

        public InventarioService(HelpDeskMvcContext context)
        {
            _context = context;
        }
    }
}
