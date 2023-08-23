var builder = WebApplication.CreateBuilder(args);

//app.MapGet("/", () => "Bom dia Brasil!!!! ótimo dia para ser derrotado mais uma vez!");
//Adiciona o serviço de controller
builder.Services.AddControllers();

var app = builder.Build();

//Adiciona o mapeamento dos controllers
app.MapControllers();

app.UseHttpsRedirection();

app.Run();
