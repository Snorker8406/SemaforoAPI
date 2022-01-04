using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Semaforo.Logic.Models
{
    public partial class db_9bc4da_semaforoContext : DbContext
    {
        public db_9bc4da_semaforoContext()
        {
        }

        public db_9bc4da_semaforoContext(DbContextOptions<db_9bc4da_semaforoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountPayments> AccountPayments { get; set; }
        public virtual DbSet<AccountStatus> AccountStatus { get; set; }
        public virtual DbSet<AccountTypes> AccountTypes { get; set; }
        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<ClientStatus> ClientStatus { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<EmployeeRole> EmployeeRole { get; set; }
        public virtual DbSet<EmployeeSalary> EmployeeSalary { get; set; }
        public virtual DbSet<EmployeeSchedule> EmployeeSchedule { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Prices> Prices { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductPictures> ProductPictures { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<SalesDetails> SalesDetails { get; set; }
        public virtual DbSet<SalesTypes> SalesTypes { get; set; }
        public virtual DbSet<Sites> Sites { get; set; }
        public virtual DbSet<Sizes> Sizes { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=SQL5063.site4now.net;Initial Catalog=db_9bc4da_semaforo;User Id=db_9bc4da_semaforo_admin;Password=semaforo123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountPayments>(entity =>
            {
                entity.HasKey(e => e.AccountPaymentId);

                entity.ToTable("ACCOUNT_PAYMENTS");

                entity.Property(e => e.AccountPaymentId).HasColumnName("Account_Payment_ID");

                entity.Property(e => e.AccountId).HasColumnName("Account_ID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.PaymentDate)
                    .HasColumnName("Payment_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SiteId).HasColumnName("Site_ID");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountPayments)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACCOUNT_PAYMENTS_ACCOUNTS");
            });

            modelBuilder.Entity<AccountStatus>(entity =>
            {
                entity.ToTable("ACCOUNT_STATUS");

                entity.Property(e => e.AccountStatusId).HasColumnName("Account_Status_ID");

                entity.Property(e => e.AccountStatus1)
                    .IsRequired()
                    .HasColumnName("Account_Status")
                    .HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(250);
            });

            modelBuilder.Entity<AccountTypes>(entity =>
            {
                entity.HasKey(e => e.AccountTypeId);

                entity.ToTable("ACCOUNT_TYPES");

                entity.Property(e => e.AccountTypeId).HasColumnName("Account_Type_ID");

                entity.Property(e => e.AccountType)
                    .IsRequired()
                    .HasColumnName("Account_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(250);
            });

            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.ToTable("ACCOUNTS");

                entity.Property(e => e.AccountId).HasColumnName("Account_ID");

                entity.Property(e => e.AccountStatusId).HasColumnName("Account_Status_ID");

                entity.Property(e => e.AccountTypeId).HasColumnName("Account_Type_ID");

                entity.Property(e => e.Balance).HasColumnType("money");

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CancellationDate)
                    .HasColumnName("Cancellation_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ClientId).HasColumnName("Client_ID");

                entity.Property(e => e.Notes).HasMaxLength(1000);

                entity.Property(e => e.OpeningDate)
                    .HasColumnName("Opening_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SaleId).HasColumnName("Sale_ID");

                entity.Property(e => e.SettlementDate)
                    .HasColumnName("Settlement_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SiteId).HasColumnName("Site_ID");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.AccountStatus)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccountStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACCOUNTS_ACCOUNT_STATUS");

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccountTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACCOUNTS_ACCOUNT_TYPES");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACCOUNTS_CLIENTS");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.SaleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACCOUNTS_SALES");

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.SiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACCOUNTS_SITES");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACCOUNTS_USERS");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("ATTENDANCE");

                entity.Property(e => e.AttendanceId)
                    .HasColumnName("Attendance_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.StartDate)
                    .HasColumnName("Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.StopDate)
                    .HasColumnName("Stop_Date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Attendance)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ATTENDANCE_EMPLOYEES");
            });

            modelBuilder.Entity<Brands>(entity =>
            {
                entity.HasKey(e => e.BrandId);

                entity.ToTable("BRANDS");

                entity.Property(e => e.BrandId).HasColumnName("Brand_ID");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.SupplierId).HasColumnName("Supplier_ID");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("CATEGORIES");

                entity.Property(e => e.CategoryId).HasColumnName("Category_ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("Create_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ClientStatus>(entity =>
            {
                entity.ToTable("CLIENT_STATUS");

                entity.Property(e => e.ClientStatusId)
                    .HasColumnName("Client_Status_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.ClientId)
                    .HasName("PK_CLIENTE");

                entity.ToTable("CLIENTS");

                entity.Property(e => e.ClientId).HasColumnName("Client_ID");

                entity.Property(e => e.AccountAmountLimit)
                    .HasColumnName("Account_Amount_Limit")
                    .HasColumnType("money");

                entity.Property(e => e.AccountDaysLimit).HasColumnName("Account_Days_Limit");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Cellphone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ClientStatusId).HasColumnName("Client_Status_ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("Create_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Facebook).HasMaxLength(200);

                entity.Property(e => e.FacebookName)
                    .HasColumnName("Facebook_Name")
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Gender).HasMaxLength(1);

                entity.Property(e => e.LastModifiedBy).HasColumnName("Last_Modified_By");

                entity.Property(e => e.LastModify)
                    .HasColumnName("Last_Modify")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last_Name")
                    .HasMaxLength(30);

                entity.Property(e => e.LastNameMother)
                    .HasColumnName("Last_Name_Mother")
                    .HasMaxLength(30);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ProfileImage).HasColumnName("Profile_Image");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Student).HasDefaultValueSql("((0))");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.ClientStatus)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.ClientStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLIENTS_CLIENT_STATUS");
            });

            modelBuilder.Entity<EmployeeRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EMPLOYEE_ROLE");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.RoleId).HasColumnName("Role_ID");

                entity.HasOne(d => d.Employee)
                    .WithMany()
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLOYEE_ROLE_EMPLOYEES");

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLOYEE_ROLE_ROLE");
            });

            modelBuilder.Entity<EmployeeSalary>(entity =>
            {
                entity.ToTable("EMPLOYEE_SALARY");

                entity.Property(e => e.EmployeeSalaryId).HasColumnName("Employee_Salary_ID");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.SalaryDay)
                    .HasColumnName("Salary_Day")
                    .HasColumnType("money");

                entity.Property(e => e.SalaryHour)
                    .HasColumnName("Salary_Hour")
                    .HasColumnType("money");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeSalary)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLOYEE_SALARY_EMPLOYEES");
            });

            modelBuilder.Entity<EmployeeSchedule>(entity =>
            {
                entity.ToTable("EMPLOYEE_SCHEDULE");

                entity.Property(e => e.EmployeeScheduleId).HasColumnName("Employee_Schedule_ID");

                entity.Property(e => e.BreakTime).HasColumnName("Break_Time");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.StartTime).HasColumnName("Start_Time");

                entity.Property(e => e.StopTime).HasColumnName("Stop_Time");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeSchedule)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLOYEE_SCHEDULE_EMPLOYEES");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("EMPLOYEES");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.Cellphone).HasMaxLength(10);

                entity.Property(e => e.EndDate)
                    .HasColumnName("End_Date")
                    .HasColumnType("date");

                entity.Property(e => e.Facebook).HasMaxLength(300);

                entity.Property(e => e.FirstLastName)
                    .HasColumnName("First_Last_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.HealthInfo)
                    .HasColumnName("Health_Info")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MaritalStatus)
                    .HasColumnName("Marital_Status")
                    .HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(10);

                entity.Property(e => e.Picture).HasColumnType("image");

                entity.Property(e => e.SecondLastName)
                    .HasColumnName("Second_Last_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.StartDate)
                    .HasColumnName("Start_Date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Prices>(entity =>
            {
                entity.HasKey(e => e.PriceId)
                    .HasName("PK_PRICES_1");

                entity.ToTable("PRICES");

                entity.Property(e => e.PriceId)
                    .HasColumnName("Price_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.SizeId).HasColumnName("Size_ID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Prices)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRICES_PRODUCTS");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Prices)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK_PRICES_SIZES");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.CategoryId });

                entity.ToTable("PRODUCT_CATEGORY");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.CategoryId).HasColumnName("Category_ID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_CATEGORY_CATEGORIES");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCategory)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_CATEGORY_PRODUCTS");
            });

            modelBuilder.Entity<ProductPictures>(entity =>
            {
                entity.HasKey(e => e.ProductPictureId);

                entity.ToTable("PRODUCT_PICTURES");

                entity.Property(e => e.ProductPictureId).HasColumnName("Product_Picture_ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("Create_Date")
                    .HasColumnType("date");

                entity.Property(e => e.Picture).HasColumnType("image");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPictures)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_PICTURES_PRODUCTS");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("PRODUCTS");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.Barcode).HasMaxLength(50);

                entity.Property(e => e.BrandId).HasColumnName("Brand_ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("Create_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ProductPictureId).HasColumnName("Product_Picture_ID");

                entity.Property(e => e.SerialCount).HasColumnName("Serial_Count");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_PRODUCTS_BRANDS");

                entity.HasOne(d => d.ProductPicture)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductPictureId)
                    .HasConstraintName("FK_PRODUCTS_PRODUCT_PICTURES");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.RoleId).HasColumnName("Role_ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("Create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_by");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.LastModifiedBy).HasColumnName("Last_modified_by");

                entity.Property(e => e.LastModify)
                    .HasColumnName("Last_modify")
                    .HasColumnType("datetime");

                entity.Property(e => e.Role1)
                    .HasColumnName("Role")
                    .HasMaxLength(10);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.HasKey(e => e.SaleId);

                entity.ToTable("SALES");

                entity.Property(e => e.SaleId).HasColumnName("Sale_ID");

                entity.Property(e => e.ClientId).HasColumnName("Client_ID");

                entity.Property(e => e.ClientName)
                    .HasColumnName("Client_Name")
                    .HasMaxLength(150);

                entity.Property(e => e.Notes).HasMaxLength(250);

                entity.Property(e => e.SaleDate)
                    .HasColumnName("Sale_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SaleTypeId).HasColumnName("Sale_Type_ID");

                entity.Property(e => e.SiteId).HasColumnName("Site_ID");

                entity.Property(e => e.Total).HasColumnType("money");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_SALES_CLIENTS");

                entity.HasOne(d => d.SaleType)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.SaleTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SALES_SALES_TYPES");

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.SiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SALES_SITES");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SALES_USERS");
            });

            modelBuilder.Entity<SalesDetails>(entity =>
            {
                entity.HasKey(e => e.SaleDetailId);

                entity.ToTable("SALES_DETAILS");

                entity.Property(e => e.SaleDetailId).HasColumnName("Sale_Detail_ID");

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.SaleId).HasColumnName("Sale_ID");

                entity.Property(e => e.SizeId).HasColumnName("Size_ID");

                entity.Property(e => e.SpecialPrice)
                    .HasColumnName("Special_Price")
                    .HasColumnType("money");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SalesDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SALES_DETAILS_PRODUCTS");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.SalesDetails)
                    .HasForeignKey(d => d.SaleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SALES_DETAILS_SALES");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.SalesDetails)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK_SALES_DETAILS_SIZES");
            });

            modelBuilder.Entity<SalesTypes>(entity =>
            {
                entity.HasKey(e => e.SaleTypeId);

                entity.ToTable("SALES_TYPES");

                entity.Property(e => e.SaleTypeId).HasColumnName("Sale_Type_ID");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.SaleType)
                    .IsRequired()
                    .HasColumnName("Sale_Type")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Sites>(entity =>
            {
                entity.HasKey(e => e.SiteId);

                entity.ToTable("SITES");

                entity.Property(e => e.SiteId).HasColumnName("Site_ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Location).HasMaxLength(150);

                entity.Property(e => e.Logo)
                    .IsRequired()
                    .HasColumnType("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<Sizes>(entity =>
            {
                entity.HasKey(e => e.SizeId)
                    .HasName("PK_SIZES_1");

                entity.ToTable("SIZES");

                entity.Property(e => e.SizeId).HasColumnName("Size_ID");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("STOCK");

                entity.Property(e => e.StockId).HasColumnName("Stock_ID");

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasDefaultValueSql("((100))");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("Create_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PriceSpecial)
                    .HasColumnName("Price_Special")
                    .HasColumnType("money");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.SaleDetailId).HasColumnName("Sale_Detail_ID");

                entity.Property(e => e.SerialNumber).HasColumnName("Serial_Number");

                entity.Property(e => e.SiteId).HasColumnName("Site_ID");

                entity.Property(e => e.SizeId).HasColumnName("Size_ID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Stock)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STOCK_PRODUCTS");

                entity.HasOne(d => d.SaleDetail)
                    .WithMany(p => p.Stock)
                    .HasForeignKey(d => d.SaleDetailId)
                    .HasConstraintName("FK_STOCK_SALES_DETAILS");

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.Stock)
                    .HasForeignKey(d => d.SiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STOCK_SITES");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Stock)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK_STOCK_SIZES");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_USER");

                entity.ToTable("USERS");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.Cellphone).HasMaxLength(20);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("Create_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Facebook).HasMaxLength(200);

                entity.Property(e => e.FirstLastName)
                    .HasColumnName("First_Last_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.LastModifiedBy).HasColumnName("Last_Modified_By");

                entity.Property(e => e.LastModify)
                    .HasColumnName("Last_Modify")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.ProfileImage)
                    .HasColumnName("Profile_Image")
                    .HasColumnType("image");

                entity.Property(e => e.SecondLastName)
                    .HasColumnName("Second_Last_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
