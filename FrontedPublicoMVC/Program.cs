using Api_Consumer;
using DTO_Integrador;
using Modelos_Integrador;

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

// --- Servicio de Estadisticas (lectura publica: calendario, grupos, selecciones, etc.) ---
Crud<Partido>.Endpoint = $"{estadisticasBaseUrl}/Partidos";
Crud<PartidoDTO>.Endpoint = $"{estadisticasBaseUrl}/Partidos/PartidosDTO";
Crud<PartidoMarcadorDTO>.Endpoint = $"{estadisticasBaseUrl}/Partidos/Marcador";
Crud<Grupo>.Endpoint = $"{estadisticasBaseUrl}/Grupos";
Crud<Seleccion>.Endpoint = $"{estadisticasBaseUrl}/Selecciones";
Crud<SeleccionDto>.Endpoint = $"{estadisticasBaseUrl}/Selecciones/SeleccionDto";
Crud<Confederacion>.Endpoint = $"{estadisticasBaseUrl}/Confederaciones";
Crud<Estadio>.Endpoint = $"{estadisticasBaseUrl}/Estadios";
Crud<FaseDeJuego>.Endpoint = $"{estadisticasBaseUrl}/FaseDeJuegos";
Crud<Sede>.Endpoint = $"{estadisticasBaseUrl}/Sedes";

// --- Servicio UTNGolCoin (login, registro, predicciones, saldo, ranking) ---
// TODO: falta crear en C# las clases equivalentes a los DTO de Java del repo
// utncoin-api (LoginRequest, RegistroRequest, AuthResponse, UsuarioResponse,
// PrediccionRequest, PrediccionResponse, RankingItemResponse, SaldoResponse,
// TransaccionResponse) antes de poder registrar sus endpoints aca con Crud<T>.
// Las vemos en el proximo paso, cuando armemos Login/Registro y Predicciones.

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