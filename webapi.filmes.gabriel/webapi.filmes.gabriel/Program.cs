using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//app.MapGet("/", () => "Bom dia Brasil!!!! ótimo dia para ser derrotado mais uma vez!");
//Adiciona o serviço de controller
builder.Services.AddControllers();

//Adiciona serviço de JWT Bearer (Forma de autenticação)
builder.Services.AddAuthentication(Options =>
{
    Options.DefaultChallengeScheme = "JwtBearer";
    Options.DefaultAuthenticateScheme = "JwtBearer";
})

.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        //Valida quem está solicitando
        ValidateIssuer = true,

        //Valida que está recebendo
        ValidateAudience = true,

        //Define se o tempo de expiração será validado
        ValidateLifetime = true,

        //Forma de criptografia e valida a chave de autenticação
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chaves-autenticacao-webapi-dev")),

    //Valida o tempo de expiração do token
    ClockSkew = TimeSpan.FromMinutes(5),

    //Nome do issuer (De onde está vindo)
    ValidIssuer = "webapi.filmes.gabriel",

    //Nome do audience (Para Onde está indo)
    ValidAudience = "webapi.filmes.gabriel"
};

});








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
// Termina a configuracao do SWAGGERS

//Adiciona o mapeamento dos controllers
app.MapControllers();

// Aqui adiciona autenticação 
app.UseAuthentication();

// Aqui adiciona autorização
app.UseAuthorization();

app.UseHttpsRedirection();

app.Run();
