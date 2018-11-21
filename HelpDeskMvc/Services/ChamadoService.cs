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

        public List<Chamado> ListarChamadoUsuario(int id)
        {
            return _context.Chamado.Where(x => x.UsuarioId == id).Include(x => x.servico).ToList();
        }

        public List<Chamado> ListarChamados()
        {
 
            return _context.Chamado.Where(x => x.status == Models.Enums.ChamadoStatus.Aberto).Include(x => x.servico)
                .ToList();
        }



        public List<HistoricoChamado> BuscarLogId(int? id)
        {
            var result = from obj in _context.HistoricoChamado select obj;
            if (id.HasValue)
            {
                result = result.Where(x => x.ChamadoId == id);
            }
            return result.ToList();
        }




        public void AbrirChamado(Chamado chamado)
        {
            chamado.tecnicoId = 1;
            chamado.status = 0;
            chamado.dataAbertura = DateTime.Now;
            _context.Add(chamado);
            _context.SaveChanges();
        }

        public List<Chamado> BuscarPorData(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.Chamado select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.dataAbertura >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.dataAbertura <= maxDate.Value);
            }
            return result.Include(x => x.departamento).Include(x => x.usuario).OrderBy(x => x.dataAbertura).ToList();
        }

        public List<Chamado> BuscarPorId(int? id)
        {
            var result = from obj in _context.Chamado select obj;
            if (id.HasValue)
            {
                result = result.Where(x => x.idChamado == id);
            }
            return result.Include(x => x.departamento).Include(x => x.usuario).OrderBy(x => x.dataAbertura).ToList();
        }

        //TESTAR MÉTODO



       

        //TESTAR MÉTODO
        public int Encerrado()
        {
            return _context.Chamado.Where(x => x.status == Models.Enums.ChamadoStatus.Encerrado).Count();
        }

        public Chamado PesquisarId(int id)
        {
            return _context.Chamado.Include(x => x.servico).Include(x => x.departamento).Include(x => x.usuario).Include(x => x.tecnico).FirstOrDefault(x => x.idChamado == id);
           

        }
    }
}
