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
            return _context.Usuario.Where(x => x.situacaoUsuario == "Ativo")
               .ToList();
        }


        

        public void InserirUsuario(Usuario usuario)
        {
            usuario.situacaoUsuario = ("Ativo");
            _context.Add(usuario);
            _context.SaveChangesAsync();
        }

        public Usuario PesquisarId(int id)
        {
            return _context.Usuario.Include(usuario => usuario.departamento).FirstOrDefault(usuario => usuario.idUsuario == id);
        }

        public void DeletarUsuario(int id)
        {
            try
            {
                var usuario =  _context.Usuario.Find(id);
                usuario.situacaoUsuario = "Inativo";
                _context.Usuario.Update(usuario);
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }

        }


        public void loginTeste(Usuario usuario)
        {
             
        }


        public string Login(Usuario usuario)
        {
            
            bool existe = _context.Usuario.Any(x => x.loginUsuario == usuario.loginUsuario);
            if (existe)
            {
                if(_context.Usuario.Any(x => x.senhaUsuario == usuario.senhaUsuario))
                {
                    return "Autenticado";
                }
                else
                {
                    return "Senha incorreta";
                }

            }
            else
            {
                return "Usuario não encontrado";
            }
            
        }

        public void Update(Usuario usuario)
        {
            bool existe =  _context.Usuario.Any(x => x.idUsuario == usuario.idUsuario);
            if (!existe)
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
