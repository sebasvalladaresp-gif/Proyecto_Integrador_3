using Api_Consumer;
using DTO_Integrador;
using Modelos_Integrador;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var baseUrl = builder.Configuration["ApiSettings:EstadisticasBaseUrl"];

Crud<PartidoDTO>.Endpoint = $"{baseUrl}/Partidos/PartidosDTO";
Crud<SeleccionDto>.Endpoint = $"{baseUrl}/Selecciones/SeleccionDto";
Crud<Grupo>.Endpoint = $"{baseUrl}/Grupos";
Crud<FaseDeJuego>.Endpoint = $"{baseUrl}/FaseDeJuegos";
Crud<Estadio>.Endpoint = $"{baseUrl}/Estadios";
Crud<Sede>.Endpoint = $"{baseUrl}/Sedes";

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
