using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lanches.Migrations
{
    /// <inheritdoc />
    public partial class AddEmptyLanche : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Lanches VALUES('X-Salada','Sanduiche delicioso acompanhado de batata e refrigerante!'" +
                ",'Batata palha, hamburguer ao ponto, maionese, salada fresca, ovo, mussarela, presunto, milho... Tudo que um sanduiche deveria ter!',22.90," +
                "'https://img.freepik.com/fotos-gratis/saboroso-hamburguer-de-carne-com-queijo-e-salada-de-frente-no-fundo-escuro_140725-89597.jpg', 'https://img.freepik.com/fotos-gratis/saboroso-hamburguer-de-carne-com-queijo-e-salada-de-frente-no-fundo-escuro_140725-89597.jpg'," +
                "1,1,1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Lanches");
        }
    }
}
