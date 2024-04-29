using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CleanHosp_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "limpeza",
                columns: table => new
                {
                    limpeza_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ds_descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_limpeza", x => x.limpeza_id);
                });

            migrationBuilder.CreateTable(
                name: "local",
                columns: table => new
                {
                    local_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ala_id = table.Column<int>(type: "integer", nullable: false),
                    ds_descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_local", x => x.local_id);
                });

            migrationBuilder.CreateTable(
                name: "local_limpeza",
                columns: table => new
                {
                    localLimpeza_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ala_id = table.Column<int>(type: "integer", nullable: false),
                    pessoa_id = table.Column<int>(type: "integer", nullable: false),
                    dt_inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    dt_fim = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    limpeza_id = table.Column<int>(type: "integer", nullable: false),
                    produtos_utilizados_id = table.Column<int>(type: "integer", nullable: false),
                    equipamentos_utilizados_id = table.Column<int>(type: "integer", nullable: false),
                    ds_descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_local_limpeza", x => x.localLimpeza_id);
                });

            migrationBuilder.CreateTable(
                name: "pessoa",
                columns: table => new
                {
                    pessoa_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ds_nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    nr_cpf = table.Column<int>(type: "integer", maxLength: 11, nullable: false),
                    nr_telefone = table.Column<int>(type: "integer", maxLength: 20, nullable: true),
                    ds_email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ds_login = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ds_senha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoa", x => x.pessoa_id);
                });

            migrationBuilder.CreateTable(
                name: "ala",
                columns: table => new
                {
                    ala_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ds_descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    local_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ala", x => x.ala_id);
                    table.ForeignKey(
                        name: "FK_ala_local_local_id",
                        column: x => x.local_id,
                        principalTable: "local",
                        principalColumn: "local_id");
                });

            migrationBuilder.CreateTable(
                name: "equipamentos_utilizados",
                columns: table => new
                {
                    equipamentos_utilizados_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    equipamento_id = table.Column<int>(type: "integer", nullable: false),
                    nr_tempoUso = table.Column<int>(type: "integer", nullable: false),
                    LocalLimpezaModellocalLimpeza_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipamentos_utilizados", x => x.equipamentos_utilizados_id);
                    table.ForeignKey(
                        name: "FK_equipamentos_utilizados_local_limpeza_LocalLimpezaModelloca~",
                        column: x => x.LocalLimpezaModellocalLimpeza_id,
                        principalTable: "local_limpeza",
                        principalColumn: "localLimpeza_id");
                });

            migrationBuilder.CreateTable(
                name: "produtos_utilizados",
                columns: table => new
                {
                    produtos_utilizados_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantidade = table.Column<int>(type: "integer", nullable: false),
                    produto_id = table.Column<int>(type: "integer", nullable: false),
                    LocalLimpezaModellocalLimpeza_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos_utilizados", x => x.produtos_utilizados_id);
                    table.ForeignKey(
                        name: "FK_produtos_utilizados_local_limpeza_LocalLimpezaModellocalLim~",
                        column: x => x.LocalLimpezaModellocalLimpeza_id,
                        principalTable: "local_limpeza",
                        principalColumn: "localLimpeza_id");
                });

            migrationBuilder.CreateTable(
                name: "equipamento",
                columns: table => new
                {
                    equipamento_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ds_nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ds_marca = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ds_modelo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    dt_aquisicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ds_descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    vl_aquisicao = table.Column<decimal>(type: "numeric", nullable: false),
                    xAtivo = table.Column<bool>(type: "boolean", nullable: true),
                    EquipamentoUtilizadoequipamentos_utilizados_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipamento", x => x.equipamento_id);
                    table.ForeignKey(
                        name: "FK_equipamento_equipamentos_utilizados_EquipamentoUtilizadoequ~",
                        column: x => x.EquipamentoUtilizadoequipamentos_utilizados_id,
                        principalTable: "equipamentos_utilizados",
                        principalColumn: "equipamentos_utilizados_id");
                });

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    produto_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ds_nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ds_marca = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ds_descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    qtde_estoque = table.Column<int>(type: "integer", nullable: false),
                    vl_unitario = table.Column<decimal>(type: "numeric", nullable: false),
                    ProdutoUtilizadoModelprodutos_utilizados_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.produto_id);
                    table.ForeignKey(
                        name: "FK_produto_produtos_utilizados_ProdutoUtilizadoModelprodutos_u~",
                        column: x => x.ProdutoUtilizadoModelprodutos_utilizados_id,
                        principalTable: "produtos_utilizados",
                        principalColumn: "produtos_utilizados_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ala_local_id",
                table: "ala",
                column: "local_id");

            migrationBuilder.CreateIndex(
                name: "IX_equipamento_EquipamentoUtilizadoequipamentos_utilizados_id",
                table: "equipamento",
                column: "EquipamentoUtilizadoequipamentos_utilizados_id");

            migrationBuilder.CreateIndex(
                name: "IX_equipamentos_utilizados_LocalLimpezaModellocalLimpeza_id",
                table: "equipamentos_utilizados",
                column: "LocalLimpezaModellocalLimpeza_id");

            migrationBuilder.CreateIndex(
                name: "IX_produto_ProdutoUtilizadoModelprodutos_utilizados_id",
                table: "produto",
                column: "ProdutoUtilizadoModelprodutos_utilizados_id");

            migrationBuilder.CreateIndex(
                name: "IX_produtos_utilizados_LocalLimpezaModellocalLimpeza_id",
                table: "produtos_utilizados",
                column: "LocalLimpezaModellocalLimpeza_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ala");

            migrationBuilder.DropTable(
                name: "equipamento");

            migrationBuilder.DropTable(
                name: "limpeza");

            migrationBuilder.DropTable(
                name: "pessoa");

            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropTable(
                name: "local");

            migrationBuilder.DropTable(
                name: "equipamentos_utilizados");

            migrationBuilder.DropTable(
                name: "produtos_utilizados");

            migrationBuilder.DropTable(
                name: "local_limpeza");
        }
    }
}
