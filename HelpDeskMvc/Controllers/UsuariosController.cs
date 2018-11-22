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
using Microsoft.AspNetCore.Http;

namespace HelpDeskMvc.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UsuarioService _usuarioService;
        private readonly DepartamentoService _departamentoService;
        // private readonly HelpDeskMvcContext _context;
        private readonly HelpDeskMvcContext _context;


        public UsuariosController(UsuarioService usuarioService, DepartamentoService departamentoService, HelpDeskMvcContext context)
        {
            _usuarioService = usuarioService;
            _departamentoService = departamentoService;
            _context = context;
        }

        public IActionResult Index(string usuario, int id)
        {
            var list = _usuarioService.ListarUsuarios();
            if (HttpContext.Session.GetString("usuario") == null)
            {
                return RedirectToAction("Login", "Usuarios");
            }
            else
            {
                ViewBag.usuario = HttpContext.Session.GetString("usuario");
                ViewBag.id = HttpContext.Session.GetInt32("id");
                return View(list);

            }
        }

        public IActionResult Logout()
        {   
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
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
            if (!ModelState.IsValid)
            {
                var departamentos = _departamentoService.ListarDepartamentos();
                var viewModel = new UsuarioFormViewModel { usuario = usuario, departamentos = departamentos };
                return View(viewModel);
            }

           /* if (_usuarioService.verificarUsuario)
            {
                _usuarioService.InserirUsuario(usuario);
            }*/
            _usuarioService.InserirUsuario(usuario);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public ActionResult Login()
        {
            if(HttpContext.Session.GetString("usuario") != null)
            {
                return RedirectToAction("Index", "Usuarios", new { usuario = HttpContext.Session.GetString("usuario").ToString(), id = HttpContext.Session.GetInt32("id")});
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
           // HelpDeskMvcContext _context = new HelpDeskMvcContext();
            var usuarioLogado = _context.Usuario.SingleOrDefault(x => x.loginUsuario == usuario.loginUsuario && x.senhaUsuario == usuario.senhaUsuario);

            usuario.idUsuario = usuarioLogado.idUsuario;

            if (usuarioLogado != null)
            {
                ViewBag.message = "loggedIn";
                ViewBag.triedOnce = "yes";

                
                HttpContext.Session.SetString("usuario", usuario.loginUsuario);
                
                HttpContext.Session.SetInt32("id", usuario.idUsuario);

                return RedirectToAction("Index","Usuarios", new {usuario = usuario.nomeUsuario,  id = usuario.idUsuario });
            }
            else
            {
                ViewBag.triedOnce = "yes";
                return View();
            }





            /* if (autenticacao.Equals("Autenticado"))
             {
                 return RedirectToAction(nameof(Index));
             }
             if (autenticacao.Equals("Senha incorreta"))
             {
                 RedirectToAction(nameof(Login));
                 ViewBag.Alerta = "Senha Incorreta";
             }
             if (autenticacao.Equals("Usuário não encontrado"))
             {
                 RedirectToAction(nameof(Login));
             }
             return View(usuario);*/
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var usuario = _usuarioService.PesquisarId(id.Value);
            if (usuario == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {
                _usuarioService.DeletarUsuario(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });

            }

        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var usuario = _usuarioService.PesquisarId(id.Value);
            if (usuario == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            return View(usuario);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var usuario = _usuarioService.PesquisarId(id.Value);
            if (usuario == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
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
            if (!ModelState.IsValid)
            {
                var departamentos = _departamentoService.ListarDepartamentos();
                var viewModel = new UsuarioFormViewModel { usuario = usuario, departamentos = departamentos };
                return View(viewModel);
            }
            if (id != usuario.idUsuario)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não corresponde" });
            }
            try
            {
                _usuarioService.Update(usuario);
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
