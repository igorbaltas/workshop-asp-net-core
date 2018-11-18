using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDeskMvc.Models;
using HelpDeskMvc.Models.ViewModels;
using HelpDeskMvc.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault.Models;

namespace HelpDeskMvc.Controllers
{
    public class ChamadosController : Controller
    {
        private readonly ChamadoService _chamadoService;
        private readonly ServicoService _servicoService;
        private readonly DepartamentoService _departamentoService;


        public ChamadosController(ChamadoService chamadoService, ServicoService servicoService, DepartamentoService departamentoService)
        {
            _chamadoService = chamadoService;
            _servicoService = servicoService;
            _departamentoService = departamentoService;
        }

        public IActionResult Index(int id, string nomeUsuario)
        {
            ViewBag.usuario = nomeUsuario;
            var list = _chamadoService.ListarChamados();
            return View(list);
        }

        public IActionResult MeusChamados(int id = 1)
        {
            var lista = _chamadoService.ListarChamadoUsuario(id);
            return View(lista);
        }

        public IActionResult Create()
        {
            var servicos =  _servicoService.ListarServicos();
            var departamentos = _departamentoService.ListarDepartamentos();
            var viewModel = new ChamadoFormViewModel { servicos = servicos, departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Chamado chamado)
        {
            
             _chamadoService.AbrirChamado(chamado);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult BuscaData(DateTime? minDate, DateTime? maxDate)
        {
            var result = _chamadoService.BuscarPorData(minDate, maxDate);
            return View(result);
        }

        public IActionResult BuscaId(int id)
        {
            var result = _chamadoService.BuscarPorId(id);
            return View(result);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var usuario =  _chamadoService.PesquisarId(id.Value);
            if (usuario == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            return View(usuario);
        }


        public IActionResult BuscaSimples()
        {
            return View();
        }

        public IActionResult BuscaAgrupada()
        {
            return View();
        }
    }
}