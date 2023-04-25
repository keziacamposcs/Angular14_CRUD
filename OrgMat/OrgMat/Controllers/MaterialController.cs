using Microsoft.AspNetCore.Mvc;

namespace OrgMat.Controllers
{
    public class MaterialController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Editar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Excluir()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Visualizar()
        {
            return View();
        }
    }
}
