using Microsoft.AspNetCore.Mvc;
using OrgMat.Data;
using OrgMat.Models;
using Microsoft.EntityFrameworkCore;

namespace OrgMat.Controllers
{
    public class FornecedorController : Controller
    {
        // Construtor
        private readonly ApplicationDbContext contexto;

        public FornecedorController(ApplicationDbContext contexto)
        {
            this.contexto = contexto;
        }
        // Fim - Construtor

        //Pagina de Lista
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var fornecedores = await contexto.Fornecedor.ToListAsync();
            return View(fornecedores);
        }

        //Pagina de Cadastro
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        // Criando um novo Fornecedor
        [HttpPost]
        public async Task<IActionResult> Create([Bind("fornecedor,cnpj,endereco,telefone,email,vendedor")] FornecedorModel createFornecedorRequest)
        {
            var fornecedor = new FornecedorModel
            {
                fornecedor = createFornecedorRequest.fornecedor,
                cnpj = createFornecedorRequest.cnpj,
                endereco = createFornecedorRequest.endereco,
                telefone = createFornecedorRequest.telefone,
                email = createFornecedorRequest.email,
                vendedor = createFornecedorRequest.vendedor
            };
            contexto.Fornecedor.Add(fornecedor);
            try
            {
                await contexto.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        // Fim - Criando um novo Fornecedor

        //Visualização
        [HttpGet]
        public async Task<IActionResult> Visualizar(int id)
        {
            var fornecedor = await contexto.Fornecedor.FirstOrDefaultAsync(f => f.id_fornecedor == id);
            return View(fornecedor);
        }
        // Fim - Visualização

        //Atualização
        // GET - Página de edição
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var fornecedor = await contexto.Fornecedor.FirstOrDefaultAsync(f => f.id_fornecedor == id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return View(fornecedor);
        }

        //Atualização
        // POST - Atualizar
        [HttpPost]
        public async Task<IActionResult> Atualizar(FornecedorModel updateFornecedorRequest)
        {
            var fornecedor = await contexto.Fornecedor.FindAsync(updateFornecedorRequest.id_fornecedor);

            if (fornecedor == null)
            {
                return NotFound();
            }
            fornecedor.fornecedor = updateFornecedorRequest.fornecedor;
            fornecedor.cnpj = updateFornecedorRequest.cnpj;
            fornecedor.endereco = updateFornecedorRequest.endereco;
            fornecedor.telefone = updateFornecedorRequest.telefone;
            fornecedor.email = updateFornecedorRequest.email;
            fornecedor.vendedor = updateFornecedorRequest.vendedor;

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
        public async Task<IActionResult> Deletar(FornecedorModel deleteFornecedorRequest)
        {
            var fornecedor = await contexto.Fornecedor.FindAsync(deleteFornecedorRequest.id_fornecedor);

            if (fornecedor == null)
            {
                return NotFound();
            }
            contexto.Fornecedor.Remove(fornecedor);
            await contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
