using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Semaforo.Logic.Migrations
{
    public partial class initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACCOUNT_STATUS",
                columns: table => new
                {
                    Account_Status_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, collation: "Modern_Spanish_CI_AS"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, collation: "Modern_Spanish_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNT_STATUS", x => x.Account_Status_ID);
                });

            migrationBuilder.CreateTable(
                name: "ACCOUNT_TYPES",
                columns: table => new
                {
                    Account_Type_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, collation: "Modern_Spanish_CI_AS"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, collation: "Modern_Spanish_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNT_TYPES", x => x.Account_Type_ID);
                });

            migrationBuilder.CreateTable(
                name: "BRANDS",
                columns: table => new
                {
                    Brand_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Supplier_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRANDS", x => x.Brand_ID);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORIES",
                columns: table => new
                {
                    Category_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, collation: "Modern_Spanish_CI_AS"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Create_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIES", x => x.Category_ID);
                });

            migrationBuilder.CreateTable(
                name: "CLIENT_STATUS",
                columns: table => new
                {
                    Client_Status_ID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, collation: "Modern_Spanish_CI_AS"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, collation: "Modern_Spanish_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENT_STATUS", x => x.Client_Status_ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_COMBOS",
                columns: table => new
                {
                    Product_Combo_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_COMBOS", x => x.Product_Combo_ID);
                });

            migrationBuilder.CreateTable(
                name: "PROVIDERS",
                columns: table => new
                {
                    Provider_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Contact_Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Cellphone = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Bank_Accounts = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Whatsapp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Image = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROVIDERS", x => x.Provider_ID);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    Role_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Create_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Created_by = table.Column<int>(type: "int", nullable: false),
                    Last_modify = table.Column<DateTime>(type: "datetime", nullable: false),
                    Last_modified_by = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, collation: "Modern_Spanish_CI_AS"),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Description = table.Column<string>(type: "ntext", nullable: true, collation: "Modern_Spanish_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.Role_ID);
                });

            migrationBuilder.CreateTable(
                name: "SALES_TYPES",
                columns: table => new
                {
                    Sale_Type_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, collation: "Modern_Spanish_CI_AS"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, collation: "Modern_Spanish_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALES_TYPES", x => x.Sale_Type_ID);
                });

            migrationBuilder.CreateTable(
                name: "SCHOOL_LEVELS",
                columns: table => new
                {
                    School_Level_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHOOL_LEVELS", x => x.School_Level_ID);
                });

            migrationBuilder.CreateTable(
                name: "SITES",
                columns: table => new
                {
                    Site_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, collation: "Modern_Spanish_CI_AS"),
                    Logo = table.Column<byte[]>(type: "image", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, collation: "Modern_Spanish_CI_AS"),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Image = table.Column<byte[]>(type: "image", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, collation: "Modern_Spanish_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SITES", x => x.Site_ID);
                });

            migrationBuilder.CreateTable(
                name: "SIZES",
                columns: table => new
                {
                    Size_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, collation: "Modern_Spanish_CI_AS"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, collation: "Modern_Spanish_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIZES", x => x.Size_ID);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Create_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Created_By = table.Column<int>(type: "int", nullable: false),
                    Last_Modify = table.Column<DateTime>(type: "datetime", nullable: false),
                    Last_Modified_By = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, collation: "Modern_Spanish_CI_AS"),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, collation: "Modern_Spanish_CI_AS"),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, collation: "Modern_Spanish_CI_AS"),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "Modern_Spanish_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.User_ID);
                });

            migrationBuilder.CreateTable(
                name: "CLIENTS",
                columns: table => new
                {
                    Client_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Client_Status_ID = table.Column<int>(type: "int", nullable: false),
                    Create_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Last_Modify = table.Column<DateTime>(type: "datetime", nullable: false),
                    Last_Modified_By = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, collation: "Modern_Spanish_CI_AS"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, collation: "Modern_Spanish_CI_AS"),
                    Last_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, collation: "Modern_Spanish_CI_AS"),
                    Last_Name_Mother = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Account_Days_Limit = table.Column<int>(type: "int", nullable: true),
                    Account_Amount_Limit = table.Column<decimal>(type: "money", nullable: true),
                    Student = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, collation: "Modern_Spanish_CI_AS"),
                    Cellphone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, collation: "Modern_Spanish_CI_AS"),
                    Whatsapp = table.Column<bool>(type: "bit", nullable: false),
                    Facebook = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Facebook_Name = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Profile_Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "Modern_Spanish_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTS", x => x.Client_ID);
                    table.ForeignKey(
                        name: "FK_CLIENTS_CLIENT_STATUS",
                        column: x => x.Client_Status_ID,
                        principalTable: "CLIENT_STATUS",
                        principalColumn: "Client_Status_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SCHOOLS",
                columns: table => new
                {
                    School_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    School_Level_ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Phone_Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Principal_Info = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Logo = table.Column<byte[]>(type: "image", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Photo = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHOOLS", x => x.School_ID);
                    table.ForeignKey(
                        name: "FK_SCHOOLS_SCHOOL_LEVELS",
                        column: x => x.School_Level_ID,
                        principalTable: "SCHOOL_LEVELS",
                        principalColumn: "School_Level_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEES",
                columns: table => new
                {
                    Employee_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    First_Last_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Second_Last_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Birthdate = table.Column<DateTime>(type: "date", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Start_Date = table.Column<DateTime>(type: "date", nullable: true),
                    End_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Photo = table.Column<byte[]>(type: "image", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cellphone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    WhatsApp = table.Column<bool>(type: "bit", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Facebook = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Facebook_Profile_Image = table.Column<byte[]>(type: "image", nullable: true),
                    Health_Info = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Marital_Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "Modern_Spanish_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEES", x => x.Employee_ID);
                    table.ForeignKey(
                        name: "FK_EMPLOYEES_USERS",
                        column: x => x.User_ID,
                        principalTable: "USERS",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SALES",
                columns: table => new
                {
                    Sale_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Client_ID = table.Column<int>(type: "int", nullable: true),
                    Site_ID = table.Column<int>(type: "int", nullable: false),
                    Sale_Type_ID = table.Column<int>(type: "int", nullable: false),
                    Sale_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Client_Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Total = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALES", x => x.Sale_ID);
                    table.ForeignKey(
                        name: "FK_SALES_CLIENTS",
                        column: x => x.Client_ID,
                        principalTable: "CLIENTS",
                        principalColumn: "Client_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SALES_SALES_TYPES",
                        column: x => x.Sale_Type_ID,
                        principalTable: "SALES_TYPES",
                        principalColumn: "Sale_Type_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SALES_SITES",
                        column: x => x.Site_ID,
                        principalTable: "SITES",
                        principalColumn: "Site_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SALES_USERS",
                        column: x => x.User_ID,
                        principalTable: "USERS",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMBROIDERIES",
                columns: table => new
                {
                    Embroidery_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    School_ID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EMB_File = table.Column<byte[]>(type: "binary(50)", fixedLength: true, maxLength: 50, nullable: true),
                    DST_File = table.Column<byte[]>(type: "binary(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Stiches = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Color_Secuence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    Image_Design = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Image = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMBROIDERIES", x => x.Embroidery_ID);
                    table.ForeignKey(
                        name: "FK_EMBROIDERIES_SCHOOLS",
                        column: x => x.School_ID,
                        principalTable: "SCHOOLS",
                        principalColumn: "School_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ATTENDANCE",
                columns: table => new
                {
                    Attendance_ID = table.Column<int>(type: "int", nullable: false),
                    Employee_ID = table.Column<int>(type: "int", nullable: false),
                    Weekday = table.Column<int>(type: "int", nullable: false),
                    Start_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Stop_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTENDANCE", x => x.Attendance_ID);
                    table.ForeignKey(
                        name: "FK_ATTENDANCE_EMPLOYEES",
                        column: x => x.Employee_ID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "Employee_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEE_ROLE",
                columns: table => new
                {
                    Employee_ID = table.Column<int>(type: "int", nullable: false),
                    Role_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE_ROLE", x => new { x.Employee_ID, x.Role_ID });
                    table.ForeignKey(
                        name: "FK_EMPLOYEE_ROLE_EMPLOYEES",
                        column: x => x.Employee_ID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "Employee_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EMPLOYEE_ROLE_ROLE",
                        column: x => x.Role_ID,
                        principalTable: "ROLES",
                        principalColumn: "Role_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEE_SALARY",
                columns: table => new
                {
                    Employee_Salary_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_ID = table.Column<int>(type: "int", nullable: false),
                    Weekday = table.Column<int>(type: "int", nullable: true),
                    Salary_Day = table.Column<decimal>(type: "money", nullable: true),
                    Salary_Hour = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE_SALARY", x => x.Employee_Salary_ID);
                    table.ForeignKey(
                        name: "FK_EMPLOYEE_SALARY_EMPLOYEES",
                        column: x => x.Employee_ID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "Employee_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEE_SCHEDULE",
                columns: table => new
                {
                    Employee_Schedule_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_ID = table.Column<int>(type: "int", nullable: false),
                    Weekday = table.Column<int>(type: "int", nullable: false),
                    Start_Time = table.Column<TimeSpan>(type: "time", nullable: true),
                    Stop_Time = table.Column<TimeSpan>(type: "time", nullable: true),
                    Break_Time = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE_SCHEDULE", x => x.Employee_Schedule_ID);
                    table.ForeignKey(
                        name: "FK_EMPLOYEE_SCHEDULE_EMPLOYEES",
                        column: x => x.Employee_ID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "Employee_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ACCOUNTS",
                columns: table => new
                {
                    Account_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client_ID = table.Column<int>(type: "int", nullable: false),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Site_ID = table.Column<int>(type: "int", nullable: false),
                    Account_Type_ID = table.Column<int>(type: "int", nullable: false),
                    Sale_ID = table.Column<int>(type: "int", nullable: false),
                    Account_Status_ID = table.Column<int>(type: "int", nullable: false),
                    Opening_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Settlement_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Cancellation_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Barcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, collation: "Modern_Spanish_CI_AS"),
                    Balance = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNTS", x => x.Account_ID);
                    table.ForeignKey(
                        name: "FK_ACCOUNTS_ACCOUNT_STATUS",
                        column: x => x.Account_Status_ID,
                        principalTable: "ACCOUNT_STATUS",
                        principalColumn: "Account_Status_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACCOUNTS_ACCOUNT_TYPES",
                        column: x => x.Account_Type_ID,
                        principalTable: "ACCOUNT_TYPES",
                        principalColumn: "Account_Type_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACCOUNTS_CLIENTS",
                        column: x => x.Client_ID,
                        principalTable: "CLIENTS",
                        principalColumn: "Client_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACCOUNTS_SALES",
                        column: x => x.Sale_ID,
                        principalTable: "SALES",
                        principalColumn: "Sale_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACCOUNTS_SITES",
                        column: x => x.Site_ID,
                        principalTable: "SITES",
                        principalColumn: "Site_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACCOUNTS_USERS",
                        column: x => x.User_ID,
                        principalTable: "USERS",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ACCOUNT_PAYMENTS",
                columns: table => new
                {
                    Account_Payment_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account_ID = table.Column<int>(type: "int", nullable: false),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Site_ID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    Payment_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, collation: "Modern_Spanish_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNT_PAYMENTS", x => x.Account_Payment_ID);
                    table.ForeignKey(
                        name: "FK_ACCOUNT_PAYMENTS_ACCOUNTS",
                        column: x => x.Account_ID,
                        principalTable: "ACCOUNTS",
                        principalColumn: "Account_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    Product_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand_ID = table.Column<int>(type: "int", nullable: true),
                    Product_Picture_ID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Create_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Barcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "Modern_Spanish_CI_AS"),
                    Serial_Count = table.Column<long>(type: "bigint", nullable: true),
                    Serialize = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.Product_ID);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_BRANDS",
                        column: x => x.Brand_ID,
                        principalTable: "BRANDS",
                        principalColumn: "Brand_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_CATEGORY",
                columns: table => new
                {
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Category_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_CATEGORY", x => new { x.Product_ID, x.Category_ID });
                    table.ForeignKey(
                        name: "FK_PRODUCT_CATEGORY_CATEGORIES",
                        column: x => x.Category_ID,
                        principalTable: "CATEGORIES",
                        principalColumn: "Category_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRODUCT_CATEGORY_PRODUCTS",
                        column: x => x.Product_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_COMBO_DETAILS",
                columns: table => new
                {
                    Product_Combo_Detail_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Combo_ID = table.Column<int>(type: "int", nullable: false),
                    Product_ID = table.Column<int>(type: "int", nullable: true),
                    Embroidery_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_COMBO_DETAILS", x => x.Product_Combo_Detail_ID);
                    table.ForeignKey(
                        name: "FK_PRODUCT_COMBO_DETAILS_EMBROIDERIES",
                        column: x => x.Embroidery_ID,
                        principalTable: "EMBROIDERIES",
                        principalColumn: "Embroidery_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRODUCT_COMBO_DETAILS_PRODUCT_COMBOS",
                        column: x => x.Product_Combo_ID,
                        principalTable: "PRODUCT_COMBOS",
                        principalColumn: "Product_Combo_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRODUCT_COMBO_DETAILS_PRODUCTS",
                        column: x => x.Product_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_PICTURES",
                columns: table => new
                {
                    Product_Picture_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<byte[]>(type: "image", nullable: true),
                    Create_Date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_PICTURES", x => x.Product_Picture_ID);
                    table.ForeignKey(
                        name: "FK_PRODUCT_PICTURES_PRODUCTS",
                        column: x => x.Product_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_PRICES",
                columns: table => new
                {
                    Price_ID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Size_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRICES_1", x => x.Price_ID);
                    table.ForeignKey(
                        name: "FK_PRICES_PRODUCTS",
                        column: x => x.Product_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRICES_SIZES",
                        column: x => x.Size_ID,
                        principalTable: "SIZES",
                        principalColumn: "Size_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_PROVIDERS",
                columns: table => new
                {
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Provider_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_PRODUCT_PROVIDERS_PRODUCTS",
                        column: x => x.Product_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRODUCT_PROVIDERS_PROVIDERS",
                        column: x => x.Provider_ID,
                        principalTable: "PROVIDERS",
                        principalColumn: "Provider_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_SCHOOLS",
                columns: table => new
                {
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    School_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS_SCHOOLS", x => new { x.Product_ID, x.School_ID });
                    table.ForeignKey(
                        name: "FK_PRODUCT_SCHOOLS_PRODUCTS",
                        column: x => x.Product_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRODUCT_SCHOOLS_SCHOOLS",
                        column: x => x.School_ID,
                        principalTable: "SCHOOLS",
                        principalColumn: "School_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SALES_DETAILS",
                columns: table => new
                {
                    Sale_Detail_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sale_ID = table.Column<int>(type: "int", nullable: false),
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Size_ID = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Special_Price = table.Column<decimal>(type: "money", nullable: true),
                    Barcode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, collation: "Modern_Spanish_CI_AS"),
                    Delivered = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALES_DETAILS", x => x.Sale_Detail_ID);
                    table.ForeignKey(
                        name: "FK_SALES_DETAILS_PRODUCTS",
                        column: x => x.Product_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SALES_DETAILS_SALES",
                        column: x => x.Sale_ID,
                        principalTable: "SALES",
                        principalColumn: "Sale_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SALES_DETAILS_SIZES",
                        column: x => x.Size_ID,
                        principalTable: "SIZES",
                        principalColumn: "Size_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STOCK",
                columns: table => new
                {
                    Stock_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Site_ID = table.Column<int>(type: "int", nullable: false),
                    Size_ID = table.Column<int>(type: "int", nullable: true),
                    Sale_Detail_ID = table.Column<int>(type: "int", nullable: true),
                    Price_Special = table.Column<decimal>(type: "money", nullable: true),
                    Create_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Serial_Number = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Barcode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false, defaultValueSql: "((100))", collation: "Modern_Spanish_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOCK", x => x.Stock_ID);
                    table.ForeignKey(
                        name: "FK_STOCK_PRODUCTS",
                        column: x => x.Product_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOCK_SALES_DETAILS",
                        column: x => x.Sale_Detail_ID,
                        principalTable: "SALES_DETAILS",
                        principalColumn: "Sale_Detail_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOCK_SITES",
                        column: x => x.Site_ID,
                        principalTable: "SITES",
                        principalColumn: "Site_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOCK_SIZES",
                        column: x => x.Size_ID,
                        principalTable: "SIZES",
                        principalColumn: "Size_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_PAYMENTS_Account_ID",
                table: "ACCOUNT_PAYMENTS",
                column: "Account_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNTS_Account_Status_ID",
                table: "ACCOUNTS",
                column: "Account_Status_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNTS_Account_Type_ID",
                table: "ACCOUNTS",
                column: "Account_Type_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNTS_Client_ID",
                table: "ACCOUNTS",
                column: "Client_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNTS_Sale_ID",
                table: "ACCOUNTS",
                column: "Sale_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNTS_Site_ID",
                table: "ACCOUNTS",
                column: "Site_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNTS_User_ID",
                table: "ACCOUNTS",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ATTENDANCE_Employee_ID",
                table: "ATTENDANCE",
                column: "Employee_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTS_Client_Status_ID",
                table: "CLIENTS",
                column: "Client_Status_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMBROIDERIES_School_ID",
                table: "EMBROIDERIES",
                column: "School_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_ROLE_Role_ID",
                table: "EMPLOYEE_ROLE",
                column: "Role_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_SALARY_Employee_ID",
                table: "EMPLOYEE_SALARY",
                column: "Employee_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_SCHEDULE_Employee_ID",
                table: "EMPLOYEE_SCHEDULE",
                column: "Employee_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_User_ID",
                table: "EMPLOYEES",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_CATEGORY_Category_ID",
                table: "PRODUCT_CATEGORY",
                column: "Category_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_COMBO_DETAILS_Embroidery_ID",
                table: "PRODUCT_COMBO_DETAILS",
                column: "Embroidery_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_COMBO_DETAILS_Product_Combo_ID",
                table: "PRODUCT_COMBO_DETAILS",
                column: "Product_Combo_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_COMBO_DETAILS_Product_ID",
                table: "PRODUCT_COMBO_DETAILS",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_PICTURES_Product_ID",
                table: "PRODUCT_PICTURES",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_PRICES_Product_ID",
                table: "PRODUCT_PRICES",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_PRICES_Size_ID",
                table: "PRODUCT_PRICES",
                column: "Size_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_PROVIDERS_Product_ID",
                table: "PRODUCT_PROVIDERS",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_PROVIDERS_Provider_ID",
                table: "PRODUCT_PROVIDERS",
                column: "Provider_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_SCHOOLS_School_ID",
                table: "PRODUCT_SCHOOLS",
                column: "School_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_Brand_ID",
                table: "PRODUCTS",
                column: "Brand_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_Product_Picture_ID",
                table: "PRODUCTS",
                column: "Product_Picture_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SALES_Client_ID",
                table: "SALES",
                column: "Client_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SALES_Sale_Type_ID",
                table: "SALES",
                column: "Sale_Type_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SALES_Site_ID",
                table: "SALES",
                column: "Site_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SALES_User_ID",
                table: "SALES",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SALES_DETAILS_Product_ID",
                table: "SALES_DETAILS",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SALES_DETAILS_Sale_ID",
                table: "SALES_DETAILS",
                column: "Sale_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SALES_DETAILS_Size_ID",
                table: "SALES_DETAILS",
                column: "Size_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SCHOOLS_School_Level_ID",
                table: "SCHOOLS",
                column: "School_Level_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_Product_ID",
                table: "STOCK",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_Sale_Detail_ID",
                table: "STOCK",
                column: "Sale_Detail_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_Site_ID",
                table: "STOCK",
                column: "Site_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_Size_ID",
                table: "STOCK",
                column: "Size_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTS_PRODUCT_PICTURES",
                table: "PRODUCTS",
                column: "Product_Picture_ID",
                principalTable: "PRODUCT_PICTURES",
                principalColumn: "Product_Picture_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCT_PICTURES_PRODUCTS",
                table: "PRODUCT_PICTURES");

            migrationBuilder.DropTable(
                name: "ACCOUNT_PAYMENTS");

            migrationBuilder.DropTable(
                name: "ATTENDANCE");

            migrationBuilder.DropTable(
                name: "EMPLOYEE_ROLE");

            migrationBuilder.DropTable(
                name: "EMPLOYEE_SALARY");

            migrationBuilder.DropTable(
                name: "EMPLOYEE_SCHEDULE");

            migrationBuilder.DropTable(
                name: "PRODUCT_CATEGORY");

            migrationBuilder.DropTable(
                name: "PRODUCT_COMBO_DETAILS");

            migrationBuilder.DropTable(
                name: "PRODUCT_PRICES");

            migrationBuilder.DropTable(
                name: "PRODUCT_PROVIDERS");

            migrationBuilder.DropTable(
                name: "PRODUCT_SCHOOLS");

            migrationBuilder.DropTable(
                name: "STOCK");

            migrationBuilder.DropTable(
                name: "ACCOUNTS");

            migrationBuilder.DropTable(
                name: "ROLES");

            migrationBuilder.DropTable(
                name: "EMPLOYEES");

            migrationBuilder.DropTable(
                name: "CATEGORIES");

            migrationBuilder.DropTable(
                name: "EMBROIDERIES");

            migrationBuilder.DropTable(
                name: "PRODUCT_COMBOS");

            migrationBuilder.DropTable(
                name: "PROVIDERS");

            migrationBuilder.DropTable(
                name: "SALES_DETAILS");

            migrationBuilder.DropTable(
                name: "ACCOUNT_STATUS");

            migrationBuilder.DropTable(
                name: "ACCOUNT_TYPES");

            migrationBuilder.DropTable(
                name: "SCHOOLS");

            migrationBuilder.DropTable(
                name: "SALES");

            migrationBuilder.DropTable(
                name: "SIZES");

            migrationBuilder.DropTable(
                name: "SCHOOL_LEVELS");

            migrationBuilder.DropTable(
                name: "CLIENTS");

            migrationBuilder.DropTable(
                name: "SALES_TYPES");

            migrationBuilder.DropTable(
                name: "SITES");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropTable(
                name: "CLIENT_STATUS");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "BRANDS");

            migrationBuilder.DropTable(
                name: "PRODUCT_PICTURES");
        }
    }
}
