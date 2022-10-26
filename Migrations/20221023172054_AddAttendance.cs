using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace esluzba.Migrations
{
    public partial class AddAttendance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_Attendances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Attendances__Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "_Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Attendances__Users_UserId",
                        column: x => x.UserId,
                        principalTable: "_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX__Attendances_ServiceId",
                table: "_Attendances",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX__Attendances_UserId",
                table: "_Attendances",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_Attendances");
        }
    }
}
