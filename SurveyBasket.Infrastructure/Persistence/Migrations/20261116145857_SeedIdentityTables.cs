using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SurveyBasket.Infrastructure.Migrations;

/// <inheritdoc />
public partial class SeedIdentityTables : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "AspNetRoles",
            columns: new[] { "Id", "ConcurrencyStamp", "IsDefault", "IsDeleted", "Name", "NormalizedName" },
            values: new object[,]
            {
                { "01a1e48b-3d28-773d-9710-77a362969017", "01a1e48d-2cb3-74af-99a9-71e87e748840", false, false, "Admin", "ADMIN" },
                { "01a1e48b-6481-7c4b-b15d-cb4c476d450b", "01a1e48d-9def-73b5-815c-1453985070e9", true, false, "Member", "MEMBER" }
            });

        migrationBuilder.InsertData(
            table: "AspNetUsers",
            columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
            values: new object[] { "01a1e0c4-fa3e-7fdf-9d16-a039b18cb9ad", 0, "01a1e0d3-8664-7b16-a125-a4aba9c38324", "adminbadereldin@gmail.com", true, "Admin", "Ahmed", false, null, "ADMINBADERELDIN@GMAIL.COM", "ADMINBADERELDIN@GMAIL.COM", "AQAAAAIAAYagAAAAEMszMUwLPJEJzdJRvp0K87tgYO1yqo51S/q6wK+4xRgtfwUT7ZNhxDf2rm3VsIRfTQ==", null, false, "04D4DEA288FA44C9B9FD41F6E95B377C", false, "adminbadereldin@gmail.com" });

        migrationBuilder.InsertData(
            table: "AspNetRoleClaims",
            columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
            values: new object[,]
            {
                { 1, "permission", "polls:read", "01a1e48b-3d28-773d-9710-77a362969017" },
                { 2, "permission", "polls:add", "01a1e48b-3d28-773d-9710-77a362969017" },
                { 3, "permission", "polls:update", "01a1e48b-3d28-773d-9710-77a362969017" },
                { 4, "permission", "polls:delete", "01a1e48b-3d28-773d-9710-77a362969017" },
                { 5, "permission", "questions:read", "01a1e48b-3d28-773d-9710-77a362969017" },
                { 6, "permission", "questions:add", "01a1e48b-3d28-773d-9710-77a362969017" },
                { 7, "permission", "questions:update", "01a1e48b-3d28-773d-9710-77a362969017" },
                { 8, "permission", "users:read", "01a1e48b-3d28-773d-9710-77a362969017" },
                { 9, "permission", "users:add", "01a1e48b-3d28-773d-9710-77a362969017" },
                { 10, "permission", "users:update", "01a1e48b-3d28-773d-9710-77a362969017" },
                { 11, "permission", "roles:read", "01a1e48b-3d28-773d-9710-77a362969017" },
                { 12, "permission", "roles:add", "01a1e48b-3d28-773d-9710-77a362969017" },
                { 13, "permission", "roles:update", "01a1e48b-3d28-773d-9710-77a362969017" },
                { 14, "permission", "results:read", "01a1e48b-3d28-773d-9710-77a362969017" }
            });

        migrationBuilder.InsertData(
            table: "AspNetUserRoles",
            columns: new[] { "RoleId", "UserId" },
            values: new object[] { "01a1e48b-3d28-773d-9710-77a362969017", "01a1e0c4-fa3e-7fdf-9d16-a039b18cb9ad" });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "AspNetRoleClaims",
            keyColumn: "Id",
            keyValue: 1);

        migrationBuilder.DeleteData(
            table: "AspNetRoleClaims",
            keyColumn: "Id",
            keyValue: 2);

        migrationBuilder.DeleteData(
            table: "AspNetRoleClaims",
            keyColumn: "Id",
            keyValue: 3);

        migrationBuilder.DeleteData(
            table: "AspNetRoleClaims",
            keyColumn: "Id",
            keyValue: 4);

        migrationBuilder.DeleteData(
            table: "AspNetRoleClaims",
            keyColumn: "Id",
            keyValue: 5);

        migrationBuilder.DeleteData(
            table: "AspNetRoleClaims",
            keyColumn: "Id",
            keyValue: 6);

        migrationBuilder.DeleteData(
            table: "AspNetRoleClaims",
            keyColumn: "Id",
            keyValue: 7);

        migrationBuilder.DeleteData(
            table: "AspNetRoleClaims",
            keyColumn: "Id",
            keyValue: 8);

        migrationBuilder.DeleteData(
            table: "AspNetRoleClaims",
            keyColumn: "Id",
            keyValue: 9);

        migrationBuilder.DeleteData(
            table: "AspNetRoleClaims",
            keyColumn: "Id",
            keyValue: 10);

        migrationBuilder.DeleteData(
            table: "AspNetRoleClaims",
            keyColumn: "Id",
            keyValue: 11);

        migrationBuilder.DeleteData(
            table: "AspNetRoleClaims",
            keyColumn: "Id",
            keyValue: 12);

        migrationBuilder.DeleteData(
            table: "AspNetRoleClaims",
            keyColumn: "Id",
            keyValue: 13);

        migrationBuilder.DeleteData(
            table: "AspNetRoleClaims",
            keyColumn: "Id",
            keyValue: 14);

        migrationBuilder.DeleteData(
            table: "AspNetRoles",
            keyColumn: "Id",
            keyValue: "01a1e48b-6481-7c4b-b15d-cb4c476d450b");

        migrationBuilder.DeleteData(
            table: "AspNetUserRoles",
            keyColumns: new[] { "RoleId", "UserId" },
            keyValues: new object[] { "01a1e48b-3d28-773d-9710-77a362969017", "01a1e0c4-fa3e-7fdf-9d16-a039b18cb9ad" });

        migrationBuilder.DeleteData(
            table: "AspNetRoles",
            keyColumn: "Id",
            keyValue: "01a1e48b-3d28-773d-9710-77a362969017");

        migrationBuilder.DeleteData(
            table: "AspNetUsers",
            keyColumn: "Id",
            keyValue: "01a1e0c4-fa3e-7fdf-9d16-a039b18cb9ad");
    }
}
