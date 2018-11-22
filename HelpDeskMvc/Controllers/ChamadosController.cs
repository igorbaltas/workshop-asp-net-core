using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDeskMvc.Models;
using HelpDeskMvc.Models.ViewModels;
using HelpDeskMvc.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.AspNetCore.Http;

namespace HelpDeskMvc.Controllers
{
    public class ChamadosController : Controller
    {
        private readonly ChamadoService _chamadoService;
        private readonly ServicoService _servicoService;
        private readonly DepartamentoService _departamentoService;
        private readonly HistoricoChamadoService _historicoChamadoService;


        public ChamadosController(ChamadoService chamadoService, ServicoService servicoService, DepartamentoService departamentoService, HistoricoChamadoService historicoChamadoService)
        {
            _chamadoService = chamadoService;
            _servicoService = servicoService;
            _departamentoService = departamentoService;
            _historicoChamadoService = historicoChamadoService;
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
            chamado.UsuarioId = (int)HttpContext.Session.GetInt32("id");


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

        public IActionResult Details(int id)
        {
            var historico = _historicoChamadoService.ListarHistorico(id);
            var chamado = _chamadoService.PesquisarId(id);
            var viewModel = new DetalheChamadoViewModel { histChamado  = historico, chamado = chamado};
            /*if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }*/

            
            /*if (chamado == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }*/
            //chamadoModel.calcularTempoChamado(chamado);
            return View(viewModel);
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