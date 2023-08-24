var builder = WebApplication.CreateBuilder(args);

//app.MapGet("/", () => "Bom dia Brasil!!!! ótimo dia para ser derrotado mais uma vez!");
//Adiciona o serviço de controller
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

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
