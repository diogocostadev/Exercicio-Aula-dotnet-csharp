using Biblioteca.Servico.Servicos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<GerenciadorDeLivros>();

builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Livro}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
