using Api_Consumer;
using DTO_Integrador;
using Modelos_Integrador;
// Entidades (POST, PUT, DELETE)
Crud<Administrador>.Endpoint = "https://localhost:7185/api/Administradores";
Crud<Partido>.Endpoint = "https://localhost:7185/api/Partidos";
Crud<RegistroAuditoria>.Endpoint = "https://localhost:7185/api/RegistroAuditorias";
Crud<Seleccion>.Endpoint = "https://localhost:7185/api/Selecciones";

// DTO (GET)
Crud<AdministradorDTO>.Endpoint = "https://localhost:7185/api/Administradores/AdministradorDTO";
Crud<PartidoDTO>.Endpoint = "https://localhost:7185/api/Partidos/PartidosDTO";
Crud<RegistroAuditoriaDTO>.Endpoint = "https://localhost:7185/api/RegistroAuditorias/RegistroAuditoriaDTO";
Crud<SeleccionDto>.Endpoint = "https://localhost:7185/api/Selecciones/SeleccionDto";
Crud<AccionAdministrativa>.Endpoint = "https://localhost:7185/api/AccionesAdministrativas";

//Resto de entidades
Crud<Confederacion>.Endpoint = "https://localhost:7185/api/Confederaciones";
Crud<Estadio>.Endpoint = "https://localhost:7185/api/Estadios";
Crud<EstadoPartido>.Endpoint = "https://localhost:7185/api/EstadoPartidos";
Crud<FaseDeJuego>.Endpoint = "https://localhost:7185/api/FaseDeJuegos";
Crud<Grupo>.Endpoint = "https://localhost:7185/api/Grupos";
Crud<Rol>.Endpoint = "https://localhost:7185/api/Roles";
Crud<Sede>.Endpoint = "https://localhost:7185/api/Sedes";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

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
