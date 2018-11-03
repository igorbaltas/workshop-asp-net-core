using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDeskMvc.Models;
using HelpDeskMvc.Models.Enums;

namespace HelpDeskMvc.Data
{
    public class SeedingService
    {
        private HelpDeskMvcContext _context;

        public SeedingService(HelpDeskMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Departamento.Any() ||
                _context.Usuario.Any() ||
                _context.Chamado.Any())
            {
                return;
            }

            Departamento d1 = new Departamento(1, "TI");
            Departamento d2 = new Departamento(2, "DIRETORIA");
            Departamento d3 = new Departamento(3, "SECRETARIA");
            Departamento d4 = new Departamento(4, "BIBLIOTECA");
            Departamento d5 = new Departamento(5, "LABORATÓRIO 1");
            Departamento d6 = new Departamento(6, "LABORATÓRIO 2");
            Departamento d7 = new Departamento(7, "LABORATÓRIO 3");
            Departamento d8 = new Departamento(8, "LABORATÓRIO 4");

            Usuario u1 = new Usuario(1, "Administrador", "admin", "admin", "ativo", "administrador", d1);

            Chamado c1 = new Chamado(1, ChamadoStatus.aguardandoAtendimento, "Mouse", DateTime.Now, new DateTime(2018, 10, 7), "Trocado",u1);

            _context.Departamento.AddRange(d1, d2, d3, d4, d5, d6, d7, d8);
            _context.Usuario.Add(u1);
            _context.Chamado.Add(c1);

            _context.SaveChanges();
        }
    }
}
