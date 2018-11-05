using HelpDeskMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HelpDeskMvc.Services.Exceptions;

namespace HelpDeskMvc.Services
{
    public class UsuarioService
    {
        private readonly HelpDeskMvcContext _context;

        public UsuarioService(HelpDeskMvcContext context)
        {
            _context = context;
        }

        public List<Usuario> ListarUsuarios()
        {
            return _context.Usuario.ToList();
        }

        public void InserirUsuario(Usuario usuario)
        {
            usuario.situacaoUsuario = ("Ativo");
            _context.Add(usuario);
            _context.SaveChanges();
        }

        public Usuario PesquisarId(int id)
        {
            return _context.Usuario.Include(usuario => usuario.departamento).FirstOrDefault(usuario => usuario.idUsuario == id);
        }

        public void DeletarUsuario(int id)
        {
            var usuario = _context.Usuario.Find(id);
            _context.Usuario.Remove(usuario);
            _context.SaveChanges();
        }

        public void Update(Usuario usuario)
        {
            if (!_context.Usuario.Any(x => x.idUsuario == usuario.idUsuario))
            {
                throw new NotFoundException("Id não encontrado!");
            }
            try
            {
                usuario.situacaoUsuario = ("Ativo");
                _context.Update(usuario);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
