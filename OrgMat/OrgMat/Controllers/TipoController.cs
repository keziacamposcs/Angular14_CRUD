using Microsoft.AspNetCore.Mvc;
using OrgMat.Data;
using OrgMat.Models;
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
            var tipos = await contexto.Tipo.ToListAsync();
            return View(tipos);
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

        // Visualização
        [HttpGet]
        public async Task<IActionResult> Visualizar(int id)
        {
            var tipo = await contexto.Tipo.FirstOrDefaultAsync(t => t.id_tipo == id);

            return View(tipo);
        }
        // Fim - Visualização


        // GET: Página de edição
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var tipo = await contexto.Tipo.FirstOrDefaultAsync(t => t.id_tipo == id);
            if (tipo == null)
            {
                return NotFound();
            }
            return View(tipo);
        }

        // POST: Atualizar registro
        [HttpPost]
        public async Task<IActionResult> Atualizar(TipoModel updateTipoRequest)
        {
            var tipo = await contexto.Tipo.FindAsync(updateTipoRequest.id_tipo);

            if (tipo == null)
            {
                return NotFound();
            }

            tipo.tipo = updateTipoRequest.tipo;

            try
            {
                await contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var tipo = contexto.Tipo.Find(id);
            return View(tipo);
        }

    }
}
