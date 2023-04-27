using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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

}

