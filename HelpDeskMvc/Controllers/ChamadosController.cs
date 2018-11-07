using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDeskMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskMvc.Controllers
{
    public class ChamadosController : Controller
    {
        private readonly ChamadoService _chamadoService;

        public ChamadosController(ChamadoService chamadoService)
        {
            _chamadoService = chamadoService;
        }

        public IActionResult Index()
        {
            var list = _chamadoService.ListarChamados();
            return View(list);
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