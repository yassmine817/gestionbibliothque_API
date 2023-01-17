using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestionbibliothque_API.Controllers
{
    public class TypeLivreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
