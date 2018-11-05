using HelpDeskMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return _context.Usuario.FirstOrDefault(usuario => usuario.idUsuario == id);
        }

        public void DeletarUsuario(int id)
        {
            var usuario = _context.Usuario.Find(id);
            _context.Usuario.Remove(usuario);
            _context.SaveChanges();
        }
    }
}
