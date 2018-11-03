using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskMvc.Models
{
    public class HelpDeskMvcContext : DbContext
    {
        public HelpDeskMvcContext (DbContextOptions<HelpDeskMvcContext> options)
            : base(options)
        {
        }

        public DbSet<HelpDeskMvc.Models.Departamento> Departamento { get; set; }
    }
}
