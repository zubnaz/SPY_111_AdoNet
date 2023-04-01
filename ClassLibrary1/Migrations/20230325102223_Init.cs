﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _06_02_EntityFramework.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airplanes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaxPassangers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplanes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrivelTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivelCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartureCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AirplaneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Flights_Airplanes_AirplaneId",
                        column: x => x.AirplaneId,
                        principalTable: "Airplanes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientFlight",
                columns: table => new
                {
                    ClientsId = table.Column<int>(type: "int", nullable: false),
                    FlightsNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFlight", x => new { x.ClientsId, x.FlightsNumber });
                    table.ForeignKey(
                        name: "FK_ClientFlight_Flights_FlightsNumber",
                        column: x => x.FlightsNumber,
                        principalTable: "Flights",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientFlight_Passengers_ClientsId",
                        column: x => x.ClientsId,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "Id", "MaxPassangers", "Model" },
                values: new object[] { 1, 120, "Boeing 727" });

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "Id", "MaxPassangers", "Model" },
                values: new object[] { 2, 90, "Am 727" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Number", "AirplaneId", "ArrivelCity", "ArrivelTime", "DepartureCity", "DepartureTime" },
                values: new object[] { 1, 1, "Lviv", new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kyiv", new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Number", "AirplaneId", "ArrivelCity", "ArrivelTime", "DepartureCity", "DepartureTime" },
                values: new object[] { 2, 2, "Lviv", new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Warshaw", new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_ClientFlight_FlightsNumber",
                table: "ClientFlight",
                column: "FlightsNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirplaneId",
                table: "Flights",
                column: "AirplaneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientFlight");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Airplanes");
        }
    }
}
