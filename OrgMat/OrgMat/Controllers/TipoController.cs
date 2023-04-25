using Microsoft.AspNetCore.Mvc;
using OrgMat.Data;
using OrgMat.Models;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace OrgMat.Controllers
{
    public class TipoController : Controller
    {
        // Construtor
        private readonly ApplicationDbContext contexto;

        public TipoController(ApplicationDbContext contexto)
        {
            this.contexto = contexto;
        }

        // Fim - Construtor

        //Pagina de Lista
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            Task<List<TipoModel>> task = contexto.Tipo.ToListAsync();
            return base.View(await task);
        }


        //Pagina de Cadastro
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        // Criando um novo Tipo
        [HttpPost]
        public async Task<IActionResult> Create(TipoModel createTipoRequest)
        {
            var tipo = new TipoModel
            {
                tipo = createTipoRequest.tipo
            };

            contexto.Tipo.Add(tipo);
            try
            {
                await contexto.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // Fim - Criando um novo Tipo

    }
}
