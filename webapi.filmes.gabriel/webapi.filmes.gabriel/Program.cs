var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Bom dia Brasil!!!! �timo dia para ser derrotado mais uma vez!");
app.UseHttpsRedirection();
app.Run();
