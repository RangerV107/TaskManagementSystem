using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    DocReadyFlag = table.Column<bool>(type: "bit", nullable: false),
                    TaskReadyFlag = table.Column<bool>(type: "bit", nullable: false),
                    TaskCancelFlag = table.Column<bool>(type: "bit", nullable: false),
                    PlannedCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CancelDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsibleExecutor_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsibleExecutor_UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionTasks_TaskTypes_TaskTypeId",
                        column: x => x.TaskTypeId,
                        principalTable: "TaskTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncomingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegistrPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegistrPerson_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrPerson_UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InDocuments_ProductionTasks_ProductionTaskId",
                        column: x => x.ProductionTaskId,
                        principalTable: "ProductionTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsePerson_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsePerson_UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeliveryType = table.Column<int>(type: "int", nullable: false),
                    SentDocsDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OutgoingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Executor_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Executor_UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExecutorNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    SendRespCommand = table.Column<bool>(type: "bit", nullable: false),
                    SendRespCommandDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RespCommandPerson_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RespCommandPerson_UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlannsedRespDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualRespDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutDocuments_ProductionTasks_ProductionTaskId",
                        column: x => x.ProductionTaskId,
                        principalTable: "ProductionTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionTasks_CancellationBasics",
                columns: table => new
                {
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductionTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionTasks_CancellationBasics", x => new { x.ProductionTaskId, x.DocumentId });
                    table.ForeignKey(
                        name: "FK_ProductionTasks_CancellationBasics_ProductionTasks_ProductionTaskId",
                        column: x => x.ProductionTaskId,
                        principalTable: "ProductionTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionTasks_CompletionBasics",
                columns: table => new
                {
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductionTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionTasks_CompletionBasics", x => new { x.ProductionTaskId, x.DocumentId });
                    table.ForeignKey(
                        name: "FK_ProductionTasks_CompletionBasics_ProductionTasks_ProductionTaskId",
                        column: x => x.ProductionTaskId,
                        principalTable: "ProductionTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExecutorReport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlannedCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    InitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Executor_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Executor_UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConfirmDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportFlag = table.Column<bool>(type: "bit", nullable: false),
                    TaskReadyFlag = table.Column<bool>(type: "bit", nullable: false),
                    CancelFlag = table.Column<bool>(type: "bit", nullable: false),
                    CancelDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductionTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpperTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_ProductionTasks_ProductionTaskId",
                        column: x => x.ProductionTaskId,
                        principalTable: "ProductionTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Tasks_UpperTaskId",
                        column: x => x.UpperTaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InDocuments_Documents",
                columns: table => new
                {
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InDocuments_Documents", x => new { x.InDocumentId, x.DocumentId });
                    table.ForeignKey(
                        name: "FK_InDocuments_Documents_InDocuments_InDocumentId",
                        column: x => x.InDocumentId,
                        principalTable: "InDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutDocuments_Documents",
                columns: table => new
                {
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OutDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutDocuments_Documents", x => new { x.OutDocumentId, x.DocumentId });
                    table.ForeignKey(
                        name: "FK_OutDocuments_Documents_OutDocuments_OutDocumentId",
                        column: x => x.OutDocumentId,
                        principalTable: "OutDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks_ReportDocs",
                columns: table => new
                {
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductionSubTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks_ReportDocs", x => new { x.ProductionSubTaskId, x.DocumentId });
                    table.ForeignKey(
                        name: "FK_Tasks_ReportDocs_Tasks_ProductionSubTaskId",
                        column: x => x.ProductionSubTaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InDocuments_ProductionTaskId",
                table: "InDocuments",
                column: "ProductionTaskId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutDocuments_ProductionTaskId",
                table: "OutDocuments",
                column: "ProductionTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionTasks_TaskTypeId",
                table: "ProductionTasks",
                column: "TaskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProductionTaskId",
                table: "Tasks",
                column: "ProductionTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UpperTaskId",
                table: "Tasks",
                column: "UpperTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InDocuments_Documents");

            migrationBuilder.DropTable(
                name: "OutDocuments_Documents");

            migrationBuilder.DropTable(
                name: "ProductionTasks_CancellationBasics");

            migrationBuilder.DropTable(
                name: "ProductionTasks_CompletionBasics");

            migrationBuilder.DropTable(
                name: "Tasks_ReportDocs");

            migrationBuilder.DropTable(
                name: "InDocuments");

            migrationBuilder.DropTable(
                name: "OutDocuments");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "ProductionTasks");

            migrationBuilder.DropTable(
                name: "TaskTypes");
        }
    }
}
