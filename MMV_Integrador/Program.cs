using Api_Consumer;
using DTO_Integrador;
using Modelos_Integrador;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


var baseUrl = builder.Configuration["ApiSettings:EstadisticasBaseUrl"];

Crud<Administrador>.Endpoint = $"{baseUrl}/Administradores";
Crud<Partido>.Endpoint = $"{baseUrl}/Partidos";
Crud<RegistroAuditoria>.Endpoint = $"{baseUrl}/RegistroAuditorias";
Crud<Seleccion>.Endpoint = $"{baseUrl}/Selecciones";
Crud<AccionAdministrativa>.Endpoint = $"{baseUrl}/AccionesAdministrativas";


Crud<AdministradorDTO>.Endpoint = $"{baseUrl}/Administradores";
Crud<PartidoDTO>.Endpoint = $"{baseUrl}/Partidos";
Crud<RegistroAuditoriaDTO>.Endpoint = $"{baseUrl}/RegistroAuditorias";
Crud<SeleccionDto>.Endpoint = $"{baseUrl}/Selecciones";

Crud<Confederacion>.Endpoint = $"{baseUrl}/Confederaciones";
Crud<Estadio>.Endpoint = $"{baseUrl}/Estadios";
Crud<EstadoPartido>.Endpoint = $"{baseUrl}/EstadoPartidos";
Crud<FaseDeJuego>.Endpoint = $"{baseUrl}/FaseDeJuegos";
Crud<Grupo>.Endpoint = $"{baseUrl}/Grupos";
Crud<Rol>.Endpoint = $"{baseUrl}/Roles";
Crud<Sede>.Endpoint = $"{baseUrl}/Sedes";

var app = builder.Build();

// Configure the HTTP request pipeline.
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
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();