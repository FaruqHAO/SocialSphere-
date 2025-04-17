using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoApplication.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEventModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendees_Tickets_TicketId",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "EarlyBird",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Tickets",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "OrganizerName",
                table: "Events",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Events",
                newName: "GoogleMapsUrl");

            migrationBuilder.RenameColumn(
                name: "EventDate",
                table: "Events",
                newName: "StartDateTime");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "Attendees",
                newName: "TicketTypeId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Attendees",
                newName: "QRCodePath");

            migrationBuilder.RenameIndex(
                name: "IX_Attendees_TicketId",
                table: "Attendees",
                newName: "IX_Attendees_TicketTypeId");

            migrationBuilder.AddColumn<DateTime>(
                name: "EarlyBirdEndDate",
                table: "Tickets",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EarlyBirdPrice",
                table: "Tickets",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Events",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDateTime",
                table: "Events",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EventModelId",
                table: "Attendees",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Attendees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "Attendees",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnWaitingList",
                table: "Attendees",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisteredAt",
                table: "Attendees",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_EventModelId",
                table: "Attendees",
                column: "EventModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendees_Events_EventModelId",
                table: "Attendees",
                column: "EventModelId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendees_Tickets_TicketTypeId",
                table: "Attendees",
                column: "TicketTypeId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendees_Events_EventModelId",
                table: "Attendees");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendees_Tickets_TicketTypeId",
                table: "Attendees");

            migrationBuilder.DropIndex(
                name: "IX_Attendees_EventModelId",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "EarlyBirdEndDate",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "EarlyBirdPrice",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EndDateTime",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventModelId",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "IsOnWaitingList",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "RegisteredAt",
                table: "Attendees");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tickets",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Events",
                newName: "OrganizerName");

            migrationBuilder.RenameColumn(
                name: "StartDateTime",
                table: "Events",
                newName: "EventDate");

            migrationBuilder.RenameColumn(
                name: "GoogleMapsUrl",
                table: "Events",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "TicketTypeId",
                table: "Attendees",
                newName: "TicketId");

            migrationBuilder.RenameColumn(
                name: "QRCodePath",
                table: "Attendees",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Attendees_TicketTypeId",
                table: "Attendees",
                newName: "IX_Attendees_TicketId");

            migrationBuilder.AddColumn<bool>(
                name: "EarlyBird",
                table: "Tickets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendees_Tickets_TicketId",
                table: "Attendees",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
