using Microsoft.AspNetCore.Mvc;
using OrgMat.Data;
using OrgMat.Models;
using Microsoft.EntityFrameworkCore;

namespace OrgMat.Controllers
{
    public class SetorController : Controller
    {
        // Construtor
        private readonly ApplicationDbContext contexto;

        public SetorController(ApplicationDbContext contexto)
        {
            this.contexto = contexto;
        }
        // Fim - Construtor

        //Pagina de Lista
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var setores = await contexto.Setor.ToListAsync();
            return View(setores);
        }

        //Pagina de Cadastro
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        // Criando um novo Setor
        [HttpPost]
        public async Task<IActionResult> Create(SetorModel createSetorRequest)
        {
            var setor = new SetorModel
            {
                setor = createSetorRequest.setor
            };

            contexto.Setor.Add(setor);
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
        // Fim - Criando um novo Setor

        //Visualização
        [HttpGet]
        public async Task<IActionResult> Visualizar(int id)
        {
            var setor = await contexto.Setor.FirstOrDefaultAsync(s => s.id_setor == id);
            return View(setor);
        }
        // Fim - Visualização

        //Atualização
        // GET - Página de edição
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var setor = await contexto.Setor.FirstOrDefaultAsync(s => s.id_setor == id);
            if (setor == null)
            {
                return NotFound();
            }
            return View(setor);
        }

        //Atualização
        // POST - Atualizar
        [HttpPost]
        public async Task<IActionResult> Atualizar(SetorModel updateSetorRequest)
        {
            var setor = await contexto.Setor.FindAsync(updateSetorRequest.id_setor);
            
            if (setor == null)
            {
                return NotFound();
            }
            setor.setor = updateSetorRequest.setor;

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
        public async Task<IActionResult> Deletar(SetorModel deleteSetorRequest)
        {
            var setor = await contexto.Setor.FindAsync(deleteSetorRequest.id_setor);

            if (setor == null)
            {
                return NotFound();
            }
            contexto.Setor.Remove(setor);
            await contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
