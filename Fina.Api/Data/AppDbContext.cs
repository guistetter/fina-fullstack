using System.Reflection;
using Fina.Api.Data.Mappings;
using Fina.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Fina.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; } = null!;//null not n�o tenho valor agora mas eu garanto que vou ter um valor e n�o sera nulo
    public DbSet<Transaction> Transactions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //varre por todas as classes buscando todas as classes que est�o 
        //implementanto a itnerface IEntityConfiguration
}