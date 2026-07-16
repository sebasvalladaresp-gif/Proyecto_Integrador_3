using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api_Integrador.Migrations
{
    /// <inheritdoc />
    public partial class h01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Confederaciones",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confederaciones", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EstadoPartidoes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoPartidoes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FaseDeJuegos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaseDeJuegos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sedes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ciudad = table.Column<string>(type: "text", nullable: false),
                    Pais = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sedes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "selecciones",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    CodigoFifa = table.Column<string>(type: "text", nullable: false),
                    ConfederacionID = table.Column<int>(type: "integer", nullable: false),
                    GrupoID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_selecciones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_selecciones_Confederaciones_ConfederacionID",
                        column: x => x.ConfederacionID,
                        principalTable: "Confederaciones",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_selecciones_Grupos_GrupoID",
                        column: x => x.GrupoID,
                        principalTable: "Grupos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Correo = table.Column<string>(type: "text", nullable: false),
                    Contraseña = table.Column<string>(type: "text", nullable: false),
                    RolID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Administradores_Roles_RolID",
                        column: x => x.RolID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estadios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    SedeID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estadios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Estadios_Sedes_SedeID",
                        column: x => x.SedeID,
                        principalTable: "Sedes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistroAuditorias",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdministradorID = table.Column<int>(type: "integer", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroAuditorias", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RegistroAuditorias_Administradores_AdministradorID",
                        column: x => x.AdministradorID,
                        principalTable: "Administradores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SeleccionLocalID = table.Column<int>(type: "integer", nullable: false),
                    SeleccionVisitanteID = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Hora = table.Column<TimeSpan>(type: "interval", nullable: false),
                    EstadioID = table.Column<int>(type: "integer", nullable: false),
                    FaseID = table.Column<int>(type: "integer", nullable: false),
                    EstadoID = table.Column<int>(type: "integer", nullable: false),
                    GolesLocal = table.Column<int>(type: "integer", nullable: true),
                    GolesVisitante = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Partidos_Estadios_EstadioID",
                        column: x => x.EstadioID,
                        principalTable: "Estadios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partidos_EstadoPartidoes_EstadoID",
                        column: x => x.EstadoID,
                        principalTable: "EstadoPartidoes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partidos_FaseDeJuegos_FaseID",
                        column: x => x.FaseID,
                        principalTable: "FaseDeJuegos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partidos_selecciones_SeleccionLocalID",
                        column: x => x.SeleccionLocalID,
                        principalTable: "selecciones",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partidos_selecciones_SeleccionVisitanteID",
                        column: x => x.SeleccionVisitanteID,
                        principalTable: "selecciones",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_RolID",
                table: "Administradores",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "IX_Estadios_SedeID",
                table: "Estadios",
                column: "SedeID");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_EstadioID",
                table: "Partidos",
                column: "EstadioID");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_EstadoID",
                table: "Partidos",
                column: "EstadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_FaseID",
                table: "Partidos",
                column: "FaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_SeleccionLocalID",
                table: "Partidos",
                column: "SeleccionLocalID");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_SeleccionVisitanteID",
                table: "Partidos",
                column: "SeleccionVisitanteID");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroAuditorias_AdministradorID",
                table: "RegistroAuditorias",
                column: "AdministradorID");

            migrationBuilder.CreateIndex(
                name: "IX_selecciones_ConfederacionID",
                table: "selecciones",
                column: "ConfederacionID");

            migrationBuilder.CreateIndex(
                name: "IX_selecciones_GrupoID",
                table: "selecciones",
                column: "GrupoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partidos");

            migrationBuilder.DropTable(
                name: "RegistroAuditorias");

            migrationBuilder.DropTable(
                name: "Estadios");

            migrationBuilder.DropTable(
                name: "EstadoPartidoes");

            migrationBuilder.DropTable(
                name: "FaseDeJuegos");

            migrationBuilder.DropTable(
                name: "selecciones");

            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "Sedes");

            migrationBuilder.DropTable(
                name: "Confederaciones");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
