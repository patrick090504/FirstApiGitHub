using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstApi.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert Into Products(Name,Description,Price,Stock,CategoryId) Values('Caderno espiral','Caderno espiral 100 folhas',7.45,50,1)");

            migrationBuilder.Sql("Insert Into Products(Name,Description,Price,Stock,CategoryId) Values('Estojo escolar','Estojo escolar cinza',5.65,70,1)");

            migrationBuilder.Sql("Insert Into Products(Name,Description,Price,Stock,CategoryId) Values('Lapis','Lapis cinza',3.58,21,1)");

            migrationBuilder.Sql("Insert Into Products(Name,Description,Price,Stock,CategoryId) Values('Caderno','Caderno escolar cinza',10.52,31,1)");

            migrationBuilder.Sql("Insert Into Products(Name,Description,Price,Stock,CategoryId) Values('Borracha','Borracha branca',1.35,55,1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
