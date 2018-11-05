using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDeskMvc.Services;
using Microsoft.AspNetCore.Mvc;
using HelpDeskMvc.Models;
using HelpDeskMvc.Models.ViewModels;
using HelpDeskMvc.Services.Exceptions;
using System.Diagnostics;

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

        public async Task<IActionResult> Index()
        {
            var list = await _usuarioService.ListarUsuariosAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var departamentos = await _departamentoService.ListarDepartamentosAsync();
            var viewModel = new UsuarioFormViewModel { departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                var departamentos =  await _departamentoService.ListarDepartamentosAsync();
                var viewModel = new UsuarioFormViewModel { usuario = usuario, departamentos = departamentos };
                return View(viewModel);
            }
            await _usuarioService.InserirUsuarioAsync(usuario);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido"});
            }

            var usuario = await _usuarioService.PesquisarIdAsync(id.Value);
            if (usuario == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _usuarioService.DeletarUsuarioAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var usuario = await _usuarioService.PesquisarIdAsync(id.Value);
            if (usuario == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            return View(usuario);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var usuario = await _usuarioService.PesquisarIdAsync(id.Value);
            if (usuario == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            List<Departamento> departamentos = await _departamentoService.ListarDepartamentosAsync();
            UsuarioFormViewModel viewModel = new UsuarioFormViewModel { usuario = usuario, departamentos = departamentos };
            return View(viewModel);
            ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = await _departamentoService.ListarDepartamentosAsync();
                var viewModel = new UsuarioFormViewModel { usuario = usuario, departamentos = departamentos };
                return View(viewModel);
            }
            if (id != usuario.idUsuario)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não corresponde" });
            }
            try
            { 
            await _usuarioService.UpdateAsync(usuario);
            return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }


    }
}
