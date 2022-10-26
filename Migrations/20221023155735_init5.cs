using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace esluzba.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_Parishes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Parishes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ParishId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Day = table.Column<int>(type: "integer", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Services__Parishes_ParishId",
                        column: x => x.ParishId,
                        principalTable: "_Parishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    FingerprintCode = table.Column<string>(type: "text", nullable: false),
                    ParishId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Users__Parishes_ParishId",
                        column: x => x.ParishId,
                        principalTable: "_Parishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_UserServicesRelation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserServicesRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK__UserServicesRelation__Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "_Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__UserServicesRelation__Users_UserId",
                        column: x => x.UserId,
                        principalTable: "_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX__Services_ParishId",
                table: "_Services",
                column: "ParishId");

            migrationBuilder.CreateIndex(
                name: "IX__Users_ParishId",
                table: "_Users",
                column: "ParishId");

            migrationBuilder.CreateIndex(
                name: "IX__UserServicesRelation_ServiceId",
                table: "_UserServicesRelation",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX__UserServicesRelation_UserId",
                table: "_UserServicesRelation",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_UserServicesRelation");

            migrationBuilder.DropTable(
                name: "_Services");

            migrationBuilder.DropTable(
                name: "_Users");

            migrationBuilder.DropTable(
                name: "_Parishes");
        }
    }
}
