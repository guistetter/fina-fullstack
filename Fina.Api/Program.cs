using Fina.Api.Data;
using Fina.Api.Handlers;
using Fina.Core.Handlers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
const string connectionString = "Server=localhost,1433;Database=fina;User ID=sa; Password=C!b32ffd6f;Trusted_Connection=False;TrustServerCertificate=True";

builder.Services.AddDbContext<AppDbContext>(
    x => x.UseSqlServer(connectionString));
//injecao de dpendencia

builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
//cria nova instancia do handler e não do banco
builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
