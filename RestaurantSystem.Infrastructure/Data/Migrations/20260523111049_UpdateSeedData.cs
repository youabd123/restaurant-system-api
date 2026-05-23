using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Fräscha sallader med lokala råvaror", "Sallader" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Smått och gott att dela på", "Förrätter" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Grillade rätter från land och hav", "Kött & Fisk" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 6, "Söta avslutningar", "Efterrätter" },
                    { 7, "Kalla drycker och läsk", "Dryck" },
                    { 8, "Noggrant utvalda viner", "Viner" }
                });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Tomatsås, mozzarella och färsk basilika", 115.00m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Tomatsås, mozzarella och parmaskinka", 135.00m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 1, "Tomatsås, mozzarella, skinka, champinjoner, oliver och kronärtskocka", "Quattro Stagioni", 145.00m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 1, "Tomatsås, mozzarella och salami piccante", "Diavola", 140.00m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 1, "Tryffelkräm, mozzarella, porcini och rucola", "Tartufo", 165.00m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 2, "Klassisk krämig sås med pancetta och pecorino", "Spaghetti Carbonara", 145.00m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 2, "Långsamt kokt köttfärssås med parmesan", "Tagliatelle Bolognese", 150.00m });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "CategoryId", "Description", "IsAvailable", "Name", "Price" },
                values: new object[,]
                {
                    { 8, 2, "Kryddig tomatsås med vitlök och chili", true, "Penne Arrabiata", 130.00m },
                    { 9, 2, "Hemgjorda gnocchi med basilikopesto och körsbärstomater", true, "Gnocchi al Pesto", 155.00m },
                    { 10, 3, "Romansallad, krutonger, parmesan och caesardressing", true, "Caesar Sallad", 115.00m },
                    { 11, 3, "Buffelmozzarella, tomater, basilika och olivolja", true, "Caprese", 125.00m },
                    { 12, 3, "Rucola, parmesanflagor, valnötter och balsamicodressing", true, "Rucola & Parmesan", 110.00m },
                    { 13, 4, "Rostat bröd med vitlökssmör och örter", true, "Vitlöksbröd", 55.00m },
                    { 14, 4, "Rostade brödschivor med tomater, vitlök och basilika", true, "Bruschetta", 65.00m },
                    { 15, 4, "Tunnskivad oxfilé med rucola, parmesan och tryffelolja", true, "Carpaccio", 145.00m },
                    { 16, 4, "Krämig burrata med rostade tomater och pesto", true, "Burrata", 135.00m },
                    { 17, 5, "Grillad oxfilé med rucola, parmesan och tryffelolja", true, "Tagliata di Manzo", 285.00m },
                    { 18, 5, "Ugnsbakad havsabborre med citron och kapris", true, "Branzino al Forno", 245.00m },
                    { 19, 5, "Grillad kycklingbröst med rosmarin och citron", true, "Pollo alla Griglia", 195.00m },
                    { 20, 5, "Vitlöksstekta räkor med chili och persilja", true, "Gamberi al Aglio", 225.00m },
                    { 21, 6, "Klassisk italiensk efterrätt med mascarpone", true, "Tiramisu", 85.00m },
                    { 22, 6, "Vaniljpannacotta med hallonsås", true, "Panna Cotta", 75.00m },
                    { 23, 6, "Tre kulor italiensk glass, välj smak", true, "Gelato", 65.00m },
                    { 24, 6, "Krispiga rör med ricottakräm och pistaschnötter", true, "Cannoli", 70.00m },
                    { 25, 7, "33cl", true, "Coca Cola", 35.00m },
                    { 26, 7, "Sparkling eller still, 33cl", true, "Mineralvatten", 30.00m },
                    { 27, 7, "Pressad apelsin- eller citronjuice", true, "Freshly Squeezed Juice", 55.00m },
                    { 28, 7, "Klassisk italiensk espresso", true, "Espresso", 35.00m },
                    { 29, 7, "Espresso med mjölkskum", true, "Cappuccino", 45.00m },
                    { 30, 8, "Toscansk rödvin, glas", true, "Chianti Classico", 95.00m },
                    { 31, 8, "Friskt vitt vin från Norditalien, glas", true, "Pinot Grigio", 85.00m },
                    { 32, 8, "Italienskt mousserande vin, glas", true, "Prosecco", 90.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Smått och gott att dela på", "Förrätter" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Söta avslutningar", "Efterrätter" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Kalla drycker och läsk", "Dryck" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Tomatsås, ost och basilika", 95.00m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Tomatsås, ost och skinka", 105.00m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 2, "Klassisk krämig sås med pancetta", "Carbonara", 135.00m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 3, "Serveras med aioli", "Vitlöksbröd", 45.00m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 4, "Klassisk italiensk efterrätt", "Tiramisu", 75.00m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 5, "33cl", "Coca Cola", 25.00m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 5, "33cl", "Mineralvatten", 20.00m });
        }
    }
}
