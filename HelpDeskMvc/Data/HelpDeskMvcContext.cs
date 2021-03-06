﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskMvc.Models
{
    public class HelpDeskMvcContext : DbContext
    {
        public HelpDeskMvcContext(DbContextOptions<HelpDeskMvcContext> options)
            : base(options)
        {
        }

        /*public HelpDeskMvcContext()
        {

        }*/

        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Chamado> Chamado { get; set; }
        public DbSet<Servico> Servico { get; set; }
        public DbSet<HistoricoChamado> HistoricoChamado { get; set; }
        public DbSet<Inventario> Inventario { get; set; }

    }
}
