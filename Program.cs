using Microsoft.EntityFrameworkCore;
using TaskManagerPoC.Data;

var builder = WebApplication.CreateBuilder(args);

// --- REGISTRO DE SERVIÇOS (Container de DI) ---

// Configura o Banco de Dados SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=tasks.db"));

// Registra suporte para Controllers de API
builder.Services.AddControllers();

// Configurações para Documentação (Swagger)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --- CONFIGURAÇÃO DO PIPELINE DE REQUISIÇÕES (Middleware) ---

// Se estiver em desenvolvimento, ativa o Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redireciona HTTP para HTTPS (Padrão de segurança)
app.UseHttpsRedirection();

// Mapeia as rotas dos Controllers para os endpoints
app.MapControllers();

// Aplica as migrações automaticamente ao iniciar o container
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    // Isso cria o banco e as tabelas se não existirem
    context.Database.Migrate();
}

app.Run();