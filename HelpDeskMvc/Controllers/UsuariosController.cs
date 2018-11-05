using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDeskMvc.Services;
using Microsoft.AspNetCore.Mvc;
using HelpDeskMvc.Models;
using HelpDeskMvc.Models.ViewModels;
using HelpDeskMvc.Services.Exceptions;

namespace HelpDeskMvc.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UsuarioService _usuarioService;
        private readonly DepartamentoService _departamentoService;

        public UsuariosController(UsuarioService usuarioService, DepartamentoService departamentoService)
        {
            _usuarioService = usuarioService;
            _departamentoService = departamentoService;
        }

        public IActionResult Index()
        {
            var list = _usuarioService.ListarUsuarios();
            return View(list);
        }

        public IActionResult Create()
        {
            var departamentos = _departamentoService.ListarDepartamentos();
            var viewModel = new UsuarioFormViewModel { departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Usuario usuario)
        {
            _usuarioService.InserirUsuario(usuario);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = _usuarioService.PesquisarId(id.Value);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _usuarioService.DeletarUsuario(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = _usuarioService.PesquisarId(id.Value);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = _usuarioService.PesquisarId(id.Value);
            if (usuario == null)
            {
                return NotFound();
            }

            List<Departamento> departamentos = _departamentoService.ListarDepartamentos();
            UsuarioFormViewModel viewModel = new UsuarioFormViewModel { usuario = usuario, departamentos = departamentos };
            return View(viewModel);
            ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Usuario usuario)
        {
            if(id != usuario.idUsuario)
            {
                return BadRequest();
            }
            try
            { 
            _usuarioService.Update(usuario);
            return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }


    }
}
