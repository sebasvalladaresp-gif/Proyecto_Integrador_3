using Api_Consumer;
using DTO_Integrador;
using Modelos_Integrador;

// Entidades (POST, PUT, DELETE)
Crud<Administrador>.Endpoint = "https://localhost:7185/api/Administradores";
Crud<Partido>.Endpoint = "https://localhost:7185/api/Partidos";
Crud<RegistroAuditoria>.Endpoint = "https://localhost:7185/api/RegistroAuditorias";
Crud<Seleccion>.Endpoint = "https://localhost:7185/api/Selecciones";

// DTO (GET)
Crud<GrupoDTO>.Endpoint = "https://localhost:7185/api/Grupos";
Crud<AdministradorDTO>.Endpoint = "https://localhost:7185/api/Administradores/AdministradorDTO";
Crud<PartidoDTO>.Endpoint = "https://localhost:7185/api/Partidos/PartidosDTO";
Crud<RegistroAuditoriaDTO>.Endpoint = "https://localhost:7185/api/RegistroAuditorias/RegistroAuditoriaDTO";
Crud<SeleccionDto>.Endpoint = "https://localhost:7185/api/Selecciones/SeleccionDto";
Crud<AccionAdministrativa>.Endpoint = "https://localhost:7185/api/AccionesAdministrativas";

//Resto de entidades
Crud<Confederacion>.Endpoint = "https://localhost:7185/api/Confederaciones";
Crud<Estadio>.Endpoint = "https://localhost:7185/api/Estadios";

Crud<Grupo>.Endpoint = "https://localhost:7185/api/Grupos";
Crud<Rol>.Endpoint = "https://localhost:7185/api/Roles";
Crud<Sede>.Endpoint = "https://localhost:7185/api/Sedes";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Necesitamos sesion para guardar el JWT que devuelve UTNGolCoin al hacer login,
// ya que ese servicio es stateless (JWT) pero este frontend renderiza server-side
// y necesita "recordar" al usuario logueado entre requests.
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var estadisticasBaseUrl = builder.Configuration["ApiSettings:EstadisticasBaseUrl"];
var utnGolCoinBaseUrl = builder.Configuration["ApiSettings:UtnGolCoinBaseUrl"];



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();