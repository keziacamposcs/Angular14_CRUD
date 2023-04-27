using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrgMat.Controllers;
using OrgMat.Models;

namespace OrgMat.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    //Tipo
    public DbSet<TipoModel> Tipo { get; set; }

    //Criticidade
    public DbSet<CriticidadeModel> Criticidade { get; set; }

    //Setor
    public DbSet<SetorModel> Setor { get; set; }

    //Cliente
    public DbSet<ClienteModel> Cliente { get; set; }

    //Local
    public DbSet<LocalModel> Local { get; set; }

    //Equipamento
    public DbSet<EquipamentoModel> Equipamento { get; set; }

    //Fornecedor
    public DbSet<FornecedorModel> Fornecedor { get; set; }

}

