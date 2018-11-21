using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDeskMvc.Models;
using HelpDeskMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskMvc.Controllers
{
    public class InventariosController : Controller
    {

        private readonly InventarioService _inventarioService;
        // private readonly HelpDeskMvcContext _context;
        private readonly HelpDeskMvcContext _context;


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}