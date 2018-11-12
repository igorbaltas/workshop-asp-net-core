using HelpDeskMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HelpDeskMvc.Services.Exceptions;

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
 
            return _context.Chamado.Where(x => x.status == Models.Enums.ChamadoStatus.Aberto).Include(x => x.servico)
                .ToList();
        }            


        public void AbrirChamado(Chamado chamado)
        {
            chamado.status = 0;
            chamado.dataAbertura = DateTime.Now;
            _context.Add(chamado);
            _context.SaveChanges();
        }

        public Chamado PesquisarId(int id)
        {
            return _context.Chamado.Include(x => x.servico).Include(x => x.departamento).Include(x => x.usuario).Include(x => x.tecnico).FirstOrDefault(x => x.idChamado == id);
           

        }
    }
}
