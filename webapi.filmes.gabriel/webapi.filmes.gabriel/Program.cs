var builder = WebApplication.CreateBuilder(args);

//app.MapGet("/", () => "Bom dia Brasil!!!! �timo dia para ser derrotado mais uma vez!");
//Adiciona o servi�o de controller
builder.Services.AddControllers();

var app = builder.Build();

//Adiciona o mapeamento dos controllers
app.MapControllers();

app.UseHttpsRedirection();

app.Run();
