using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//app.MapGet("/", () => "Bom dia Brasil!!!! ótimo dia para ser derrotado mais uma vez!");
//Adiciona o serviço de controller
builder.Services.AddControllers();

//Adicione o gerador do swagger á coleção de serviços e editar os nomes
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filmes Gabriel",
        Description = "API para gerenciamento de filmes - Introdução da sprint 2 - Backend API",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact 
        {
            Name = "Gabriel Coral Russo - Aluno Senai",
            Url = new Uri("https://github.com/GCRusso")
        },
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();


//Aqui comeca a configuração do SWAGGER
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
// Termina a configuracao do SWAGGER

//Adiciona o mapeamento dos controllers
app.MapControllers();

app.UseHttpsRedirection();

app.Run();
