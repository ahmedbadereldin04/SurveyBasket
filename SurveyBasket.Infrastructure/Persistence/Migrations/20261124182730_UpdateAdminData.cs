#nullable disable

namespace SurveyBasket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdminData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "01a1e0c4-fa3e-7fdf-9d16-a039b18cb9ad",
                columns: new[] { "FirstName", "LastName", "NormalizedUserName", "UserName" },
                values: new object[] { "Ahmed", "Badereldin", "ADMIN", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "01a1e0c4-fa3e-7fdf-9d16-a039b18cb9ad",
                columns: new[] { "FirstName", "LastName", "NormalizedUserName", "UserName" },
                values: new object[] { "Admin", "Ahmed", "ADMINBADERELDIN@GMAIL.COM", "adminbadereldin@gmail.com" });
        }
    }
}
