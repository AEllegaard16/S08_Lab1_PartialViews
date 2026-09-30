using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZombieParty.Migrations
{
    /// <inheritdoc />
    public partial class Seed_HuntingLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HuntingLogs",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Nous avons exploré la forêt au nord du village. Plusieurs traces de zombies ont été trouvées près de la rivière.", "Première sortie dans la forêt" },
                    { 2, "Une patrouille a été envoyée dans le vieux quartier afin de vérifier les maisons abandonnées. Trois zombies ont été repérés.", "Patrouille du vieux quartier" },
                    { 3, "Une activité inhabituelle a été observée autour du cimetière. L'équipe a dû battre en retraite après avoir été encerclée.", "Nuit au cimetière" },
                    { 4, "La ferme abandonnée a été sécurisée. Plusieurs zombies étaient cachés dans la grange et autour de la maison.", "Nettoyage de la ferme" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HuntingLogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HuntingLogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HuntingLogs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HuntingLogs",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
