using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalSolutionsET.Migrations
{
    /// <inheritdoc />
    public partial class InitialCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GS_ET_ENDERECO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Logradouro = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Bairro = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Cep = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    Numero = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Complemento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cidade = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Uf = table.Column<string>(type: "NVARCHAR2(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_ET_ENDERECO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GS_ET_USUARIO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Cpf = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Rg = table.Column<string>(type: "NVARCHAR2(9)", maxLength: 9, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    EnderecoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_ET_USUARIO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GS_ET_USUARIO_GS_ET_ENDERECO_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "GS_ET_ENDERECO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GS_ET_ANUNCIO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Status = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    DataAnuncio = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Energia = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Valor = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CompradorId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_ET_ANUNCIO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GS_ET_ANUNCIO_GS_ET_USUARIO_CompradorId",
                        column: x => x.CompradorId,
                        principalTable: "GS_ET_USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GS_ET_ANUNCIO_GS_ET_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "GS_ET_USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GS_ET_PAGAMENTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Valor = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    TipoPagamento = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    StatusPagamento = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AnuncioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_ET_PAGAMENTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GS_ET_PAGAMENTO_GS_ET_ANUNCIO_AnuncioId",
                        column: x => x.AnuncioId,
                        principalTable: "GS_ET_ANUNCIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GS_ET_PAGAMENTO_GS_ET_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "GS_ET_USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GS_ET_ANUNCIO_CompradorId",
                table: "GS_ET_ANUNCIO",
                column: "CompradorId");

            migrationBuilder.CreateIndex(
                name: "IX_GS_ET_ANUNCIO_UsuarioId",
                table: "GS_ET_ANUNCIO",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_GS_ET_PAGAMENTO_AnuncioId",
                table: "GS_ET_PAGAMENTO",
                column: "AnuncioId");

            migrationBuilder.CreateIndex(
                name: "IX_GS_ET_PAGAMENTO_UsuarioId",
                table: "GS_ET_PAGAMENTO",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_GS_ET_USUARIO_EnderecoId",
                table: "GS_ET_USUARIO",
                column: "EnderecoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GS_ET_PAGAMENTO");

            migrationBuilder.DropTable(
                name: "GS_ET_ANUNCIO");

            migrationBuilder.DropTable(
                name: "GS_ET_USUARIO");

            migrationBuilder.DropTable(
                name: "GS_ET_ENDERECO");
        }
    }
}
