﻿using System;
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
            if (_context.Departamento.Any() ||
                _context.Usuario.Any() ||
                _context.Chamado.Any() ||
                    _context.Servico.Any() ||
                    _context.HistoricoChamado.Any() ||
                    _context.Inventario.Any())
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
            Departamento d9 = new Departamento(9, "LABORATÓRIO 5");


            Usuario u1 = new Usuario(1, "Administrador", "admin", "admin", "ativo", "administrador", d1, 1);
            Usuario u2 = new Usuario(6, "Técnico", "tec", "tec", "Ativo", "Padrão", d1, 1);

            Servico s1 = new Servico(1, "REDE - COMUNICACAO", "6 HORAS", "ALTO");
            Servico s2 = new Servico(2, "DESKTOP - CONFIGURAÇÃO", "3 DIAS", "BAIXO");
            Servico s3 = new Servico(3, "ACESSO - CRIAÇÃO", "2 DIAS", "ALTO");
            Servico s4 = new Servico(4, "SERVIDOR - ESPAÇO EM DISCO", "1 SEMANA", "MÉDIO");
            Servico s5 = new Servico(5, "CABEAMENTO", "3 SEMANAS", "MÉDIO");
            Servico s6 = new Servico(6, "DESKTOP - DANIFICADO", "2 SEMANAS", "BAIXO");

            Chamado c1 = new Chamado(1, ChamadoStatus.Aberto, "Mouse", DateTime.Now, new DateTime(2019, 10, 7), "Trocado", u1, s1, 1, 1, 6, u2, d1, 1);

            HistoricoChamado h1 = new HistoricoChamado(1, "Log teste", DateTime.Now, c1, 1, u2, 6);

            Inventario i1 = new Inventario(1, "MAQ01", "WINDOWS10", "DESKTOP", "CORE I5", "4GB", "LABORATÓRIO1");

            _context.Departamento.AddRange(d1, d2, d3, d4, d5, d6, d7, d8, d9);
            _context.Usuario.Add(u1);
            _context.Servico.AddRange(s2, s3, s4, s5, s6);
            _context.Chamado.Add(c1);
            _context.HistoricoChamado.Add(h1);
            _context.Inventario.Add(i1);



            _context.SaveChanges();
        }
    }
}
