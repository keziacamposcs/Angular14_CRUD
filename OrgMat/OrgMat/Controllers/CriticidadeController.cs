using Microsoft.AspNetCore.Mvc;
using OrgMat.Data;
using OrgMat.Models;
using Microsoft.EntityFrameworkCore;

namespace OrgMat.Controllers
{
    public class CriticidadeController : Controller
    {
        // Construtor
        private readonly ApplicationDbContext contexto;

        public CriticidadeController(ApplicationDbContext contexto)
        {
            this.contexto = contexto;
        }
        // Fim - Construtor

        //Pagina de Lista
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var criticidades = await contexto.Criticidade.ToListAsync();
            return View(criticidades);
        }

        //Pagina de Cadastro
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        // Criando um novo Criticidade
        [HttpPost]
        public async Task<IActionResult> Create(CriticidadeModel createCriticidadeRequest)
        {
            var criticidade = new CriticidadeModel
            {
                criticidade = createCriticidadeRequest.criticidade
            };

            contexto.Criticidade.Add(criticidade);
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

        //Visualização
        [HttpGet]
        public async Task<IActionResult> Visualizar(int id)
        {
            var criticidade = await contexto.Criticidade.FirstOrDefaultAsync(c => c.id_criticidade == id);
            return View(criticidade);
        }
        // Fim - Visualização

        //Atualização
        // GET - Página de edição
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var criticidade = await contexto.Criticidade.FirstOrDefaultAsync(c => c.id_criticidade == id);
            if (criticidade == null)
            {
                return NotFound();
            }
            return View(criticidade);
        }

        //Atualização
        // POST - Atualizar
        [HttpPost]
        public async Task<IActionResult> Atualizar(CriticidadeModel updateCriticidadeRequest)
        {
            var criticidade = await contexto.Criticidade.FindAsync(updateCriticidadeRequest.id_criticidade);
            
            if (criticidade == null)
            {
                return NotFound();
            }
            criticidade.criticidade = updateCriticidadeRequest.criticidade;

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
        // Fim - Atualização

        //Deletar
        [HttpPost]
        public async Task<IActionResult> Deletar(CriticidadeModel deleteCriticidadeRequest)
        {
            var criticidade = await contexto.Criticidade.FindAsync(deleteCriticidadeRequest.id_criticidade);

            if (criticidade == null)
            {
                return NotFound();
            }
            contexto.Criticidade.Remove(criticidade);
            await contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
