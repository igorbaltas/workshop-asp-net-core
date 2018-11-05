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

        public async Task<List<Usuario>> ListarUsuariosAsync()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task InserirUsuarioAsync(Usuario usuario)
        {
            usuario.situacaoUsuario = ("Ativo");
            _context.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> PesquisarIdAsync(int id)
        {
            return await _context.Usuario.Include(usuario => usuario.departamento).FirstOrDefaultAsync(usuario => usuario.idUsuario == id);
        }

        public async Task DeletarUsuarioAsync(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            bool existe = await _context.Usuario.AnyAsync(x => x.idUsuario == usuario.idUsuario);
            if (!existe)
            {
                throw new NotFoundException("Id não encontrado!");
            }
            try
            {
                usuario.situacaoUsuario = ("Ativo");
                _context.Update(usuario);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
