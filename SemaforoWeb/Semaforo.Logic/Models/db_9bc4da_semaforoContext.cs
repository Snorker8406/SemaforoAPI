using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

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

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountPayment> AccountPayments { get; set; }
        public virtual DbSet<AccountStatus> AccountStatuses { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientStatus> ClientStatuses { get; set; }
        public virtual DbSet<Embroidery> Embroideries { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public virtual DbSet<EmployeeSalary> EmployeeSalaries { get; set; }
        public virtual DbSet<EmployeeSchedule> EmployeeSchedules { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductCombo> ProductCombos { get; set; }
        public virtual DbSet<ProductComboDetail> ProductComboDetails { get; set; }
        public virtual DbSet<ProductPicture> ProductPictures { get; set; }
        public virtual DbSet<ProductPrice> ProductPrices { get; set; }
        public virtual DbSet<ProductProvider> ProductProviders { get; set; }
        public virtual DbSet<ProductSchool> ProductSchools { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SalesDetail> SalesDetails { get; set; }
        public virtual DbSet<SalesType> SalesTypes { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<SchoolLevel> SchoolLevels { get; set; }
        public virtual DbSet<Site> Sites { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=SQL5063.site4now.net;Initial Catalog=db_9bc4da_semaforo;User Id=db_9bc4da_semaforo_admin;Password=semaforo123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("ACCOUNTS");

                entity.Property(e => e.AccountId).HasColumnName("Account_ID");

                entity.Property(e => e.AccountStatusId).HasColumnName("Account_Status_ID");

                entity.Property(e => e.AccountTypeId).HasColumnName("Account_Type_ID");

                entity.Property(e => e.Balance).HasColumnType("money");

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.CancellationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Cancellation_Date");

                entity.Property(e => e.ClientId).HasColumnName("Client_ID");

                entity.Property(e => e.Notes)
                    .HasMaxLength(1000)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.OpeningDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Opening_Date");

                entity.Property(e => e.SaleId).HasColumnName("Sale_ID");

                entity.Property(e => e.SettlementDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Settlement_Date");

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

            modelBuilder.Entity<AccountPayment>(entity =>
            {
                entity.ToTable("ACCOUNT_PAYMENTS");

                entity.Property(e => e.AccountPaymentId).HasColumnName("Account_Payment_ID");

                entity.Property(e => e.AccountId).HasColumnName("Account_ID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.Notes)
                    .HasMaxLength(500)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Payment_Date");

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

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.ToTable("ACCOUNT_TYPES");

                entity.Property(e => e.AccountTypeId).HasColumnName("Account_Type_ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("ATTENDANCE");

                entity.Property(e => e.AttendanceId)
                    .ValueGeneratedNever()
                    .HasColumnName("Attendance_ID");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Start_Date");

                entity.Property(e => e.StopDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Stop_Date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ATTENDANCE_EMPLOYEES");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("BRANDS");

                entity.Property(e => e.BrandId).HasColumnName("Brand_ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.SupplierId).HasColumnName("Supplier_ID");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORIES");

                entity.Property(e => e.CategoryId).HasColumnName("Category_ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Date");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("CLIENTS");

                entity.Property(e => e.ClientId).HasColumnName("Client_ID");

                entity.Property(e => e.AccountAmountLimit)
                    .HasColumnType("money")
                    .HasColumnName("Account_Amount_Limit");

                entity.Property(e => e.AccountDaysLimit).HasColumnName("Account_Days_Limit");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(300)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Cellphone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.ClientStatusId).HasColumnName("Client_Status_ID");

                entity.Property(e => e.Comments).UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Date");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Facebook)
                    .HasMaxLength(200)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.FacebookName)
                    .HasMaxLength(100)
                    .HasColumnName("Facebook_Name")
                    .IsFixedLength(true)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Gender).HasMaxLength(1);

                entity.Property(e => e.LastModifiedBy).HasColumnName("Last_Modified_By");

                entity.Property(e => e.LastModify)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Modify");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("Last_Name")
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.LastNameMother)
                    .HasMaxLength(30)
                    .HasColumnName("Last_Name_Mother")
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.ProfileImage).HasColumnName("Profile_Image");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Student).HasDefaultValueSql("((0))");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.ClientStatus)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.ClientStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLIENTS_CLIENT_STATUS");
            });

            modelBuilder.Entity<ClientStatus>(entity =>
            {
                entity.ToTable("CLIENT_STATUS");

                entity.Property(e => e.ClientStatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("Client_Status_ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            modelBuilder.Entity<Embroidery>(entity =>
            {
                entity.ToTable("EMBROIDERIES");

                entity.Property(e => e.EmbroideryId).HasColumnName("Embroidery_ID");

                entity.Property(e => e.ColorSecuence).HasColumnName("Color_Secuence");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.DstFile)
                    .HasMaxLength(10)
                    .HasColumnName("DST_File")
                    .IsFixedLength(true);

                entity.Property(e => e.EmbFile)
                    .HasMaxLength(50)
                    .HasColumnName("EMB_File")
                    .IsFixedLength(true);

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.ImageDesign)
                    .HasMaxLength(10)
                    .HasColumnName("Image_Design")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.SchoolId).HasColumnName("School_ID");

                entity.Property(e => e.Stiches).HasMaxLength(50);

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Embroideries)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_EMBROIDERIES_SCHOOLS");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("EMPLOYEES");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.Cellphone)
                    .HasMaxLength(10)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Comments).UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("End_Date");

                entity.Property(e => e.Facebook)
                    .HasMaxLength(300)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.FacebookProfileImage)
                    .HasColumnType("image")
                    .HasColumnName("Facebook_Profile_Image");

                entity.Property(e => e.FirstLastName)
                    .HasMaxLength(100)
                    .HasColumnName("First_Last_Name")
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.HealthInfo)
                    .HasMaxLength(10)
                    .HasColumnName("Health_Info")
                    .IsFixedLength(true)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(20)
                    .HasColumnName("Marital_Status")
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.SecondLastName)
                    .HasMaxLength(100)
                    .HasColumnName("Second_Last_Name")
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("Start_Date");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_EMPLOYEES_USERS");
            });

            modelBuilder.Entity<EmployeeRole>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.RoleId });

                entity.ToTable("EMPLOYEE_ROLE");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.RoleId).HasColumnName("Role_ID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeRoles)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLOYEE_ROLE_EMPLOYEES");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.EmployeeRoles)
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
                    .HasColumnType("money")
                    .HasColumnName("Salary_Day");

                entity.Property(e => e.SalaryHour)
                    .HasColumnType("money")
                    .HasColumnName("Salary_Hour");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeSalaries)
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
                    .WithMany(p => p.EmployeeSchedules)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLOYEE_SCHEDULE_EMPLOYEES");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCTS");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(50)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.BrandId).HasColumnName("Brand_ID");

                entity.Property(e => e.Comments).UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Date");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .UseCollation("Modern_Spanish_CI_AS");

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

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.CategoryId });

                entity.ToTable("PRODUCT_CATEGORY");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.CategoryId).HasColumnName("Category_ID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_CATEGORY_CATEGORIES");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCategories)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_CATEGORY_PRODUCTS");
            });

            modelBuilder.Entity<ProductCombo>(entity =>
            {
                entity.ToTable("PRODUCT_COMBOS");

                entity.Property(e => e.ProductComboId).HasColumnName("Product_Combo_ID");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<ProductComboDetail>(entity =>
            {
                entity.ToTable("PRODUCT_COMBO_DETAILS");

                entity.Property(e => e.ProductComboDetailId).HasColumnName("Product_Combo_Detail_ID");

                entity.Property(e => e.EmbroideryId).HasColumnName("Embroidery_ID");

                entity.Property(e => e.ProductComboId).HasColumnName("Product_Combo_ID");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.HasOne(d => d.Embroidery)
                    .WithMany(p => p.ProductComboDetails)
                    .HasForeignKey(d => d.EmbroideryId)
                    .HasConstraintName("FK_PRODUCT_COMBO_DETAILS_EMBROIDERIES");

                entity.HasOne(d => d.ProductCombo)
                    .WithMany(p => p.ProductComboDetails)
                    .HasForeignKey(d => d.ProductComboId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_COMBO_DETAILS_PRODUCT_COMBOS");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductComboDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_PRODUCT_COMBO_DETAILS_PRODUCTS");
            });

            modelBuilder.Entity<ProductPicture>(entity =>
            {
                entity.ToTable("PRODUCT_PICTURES");

                entity.Property(e => e.ProductPictureId).HasColumnName("Product_Picture_ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("Create_Date");

                entity.Property(e => e.Picture).HasColumnType("image");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPictures)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_PICTURES_PRODUCTS");
            });

            modelBuilder.Entity<ProductPrice>(entity =>
            {
                entity.HasKey(e => e.PriceId)
                    .HasName("PK_PRICES_1");

                entity.ToTable("PRODUCT_PRICES");

                entity.Property(e => e.PriceId)
                    .ValueGeneratedNever()
                    .HasColumnName("Price_ID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.SizeId).HasColumnName("Size_ID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPrices)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRICES_PRODUCTS");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.ProductPrices)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK_PRICES_SIZES");
            });

            modelBuilder.Entity<ProductProvider>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PRODUCT_PROVIDERS");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.ProviderId).HasColumnName("Provider_ID");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_PROVIDERS_PRODUCTS");

                entity.HasOne(d => d.Provider)
                    .WithMany()
                    .HasForeignKey(d => d.ProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_PROVIDERS_PROVIDERS");
            });

            modelBuilder.Entity<ProductSchool>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.SchoolId })
                    .HasName("PK_PRODUCTS_SCHOOLS");

                entity.ToTable("PRODUCT_SCHOOLS");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.SchoolId).HasColumnName("School_ID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductSchools)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_SCHOOLS_PRODUCTS");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.ProductSchools)
                    .HasForeignKey(d => d.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_SCHOOLS_SCHOOLS");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.ToTable("PROVIDERS");

                entity.Property(e => e.ProviderId).HasColumnName("Provider_ID");

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.BankAccounts)
                    .HasMaxLength(500)
                    .HasColumnName("Bank_Accounts");

                entity.Property(e => e.Cellphone).HasMaxLength(250);

                entity.Property(e => e.ContactName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("Contact_Name");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Phone).HasMaxLength(250);

                entity.Property(e => e.Website).HasMaxLength(250);

                entity.Property(e => e.Whatsapp).HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLES");

                entity.Property(e => e.RoleId).HasColumnName("Role_ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_date");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_by");

                entity.Property(e => e.Description)
                    .HasColumnType("ntext")
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.LastModifiedBy).HasColumnName("Last_modified_by");

                entity.Property(e => e.LastModify)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_modify");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("SALES");

                entity.Property(e => e.SaleId).HasColumnName("Sale_ID");

                entity.Property(e => e.ClientId).HasColumnName("Client_ID");

                entity.Property(e => e.ClientName)
                    .HasMaxLength(150)
                    .HasColumnName("Client_Name")
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Notes)
                    .HasMaxLength(250)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.SaleDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Sale_Date");

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

            modelBuilder.Entity<SalesDetail>(entity =>
            {
                entity.HasKey(e => e.SaleDetailId);

                entity.ToTable("SALES_DETAILS");

                entity.Property(e => e.SaleDetailId).HasColumnName("Sale_Detail_ID");

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.SaleId).HasColumnName("Sale_ID");

                entity.Property(e => e.SizeId).HasColumnName("Size_ID");

                entity.Property(e => e.SpecialPrice)
                    .HasColumnType("money")
                    .HasColumnName("Special_Price");

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

            modelBuilder.Entity<SalesType>(entity =>
            {
                entity.HasKey(e => e.SaleTypeId);

                entity.ToTable("SALES_TYPES");

                entity.Property(e => e.SaleTypeId).HasColumnName("Sale_Type_ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.ToTable("SCHOOLS");

                entity.Property(e => e.SchoolId).HasColumnName("School_ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Ciudad).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.Logo).HasColumnType("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("Phone_Number");

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.PrincipalInfo)
                    .HasMaxLength(300)
                    .HasColumnName("Principal_Info");

                entity.Property(e => e.SchoolLevelId).HasColumnName("School_Level_ID");

                entity.Property(e => e.State).HasMaxLength(30);

                entity.HasOne(d => d.SchoolLevel)
                    .WithMany(p => p.Schools)
                    .HasForeignKey(d => d.SchoolLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SCHOOLS_SCHOOL_LEVELS");
            });

            modelBuilder.Entity<SchoolLevel>(entity =>
            {
                entity.ToTable("SCHOOL_LEVELS");

                entity.Property(e => e.SchoolLevelId).HasColumnName("School_Level_ID");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.ToTable("SITES");

                entity.Property(e => e.SiteId).HasColumnName("Site_ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(20)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Location)
                    .HasMaxLength(150)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Logo)
                    .IsRequired()
                    .HasColumnType("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("SIZES");

                entity.Property(e => e.SizeId).HasColumnName("Size_ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("STOCK");

                entity.Property(e => e.StockId).HasColumnName("Stock_ID");

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasDefaultValueSql("((100))")
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Date");

                entity.Property(e => e.PriceSpecial)
                    .HasColumnType("money")
                    .HasColumnName("Price_Special");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.SaleDetailId).HasColumnName("Sale_Detail_ID");

                entity.Property(e => e.SerialNumber).HasColumnName("Serial_Number");

                entity.Property(e => e.SiteId).HasColumnName("Site_ID");

                entity.Property(e => e.SizeId).HasColumnName("Size_ID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STOCK_PRODUCTS");

                entity.HasOne(d => d.SaleDetail)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.SaleDetailId)
                    .HasConstraintName("FK_STOCK_SALES_DETAILS");

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.SiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STOCK_SITES");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK_STOCK_SIZES");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.Comments).UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Date");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.LastModifiedBy).HasColumnName("Last_Modified_By");

                entity.Property(e => e.LastModify)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Modify");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
