using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shop.Application.Extentions;
using Shop.Domain.Entities.Contact;
using Shop.Domain.Entities.Identity;
using Shop.Domain.Entities.Site;
using Shop.Domain.Entities.Chat;
using Shop.Domain.Entities.MarketPlaceStore;
using Shop.Domain.Entities.MarketPlaceStore.Products;


namespace Shop.Data.Context
{
    public partial class MollaShopDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, string,
        IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        private readonly IConfiguration _configuration;
        public MollaShopDBContext(DbContextOptions<MollaShopDBContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
    }

    public partial class MollaShopDBContext
    {
        public DbSet<AppSetting> AppSetting { get; set; }

        public DbSet<ContactUs> ContactUs { get; set; }

        public DbSet<Slider> Slider { get; set; }

        public DbSet<QA> QA { get; set; }

        public DbSet<ChatMessage> ChatMessages { get; set; }

        public DbSet<Store> Store { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductGallery> ProductGalleries { get; set; }

        //public DbSet<UserChatGroup> UserChatGroups { get; set; }
    }




    public partial class MollaShopDBContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {

            #region Product

            builder.Entity<Product>().ToTable("Product");

            builder.Entity<Product>()
                .HasKey(pk => pk.Id);

            builder.Entity<Product>()
                .HasOne(s => s.Store)
                .WithMany(p => p.Products)
                .HasForeignKey(fk => fk.StoreId).IsRequired().OnDelete(DeleteBehavior.NoAction);

            #endregion


            #region Category

            builder.Entity<Category>().ToTable("Category");


            builder.Entity<Category>()
                 .HasKey(pk => pk.Id);

            #endregion


            #region ProductCategory

            builder.Entity<ProductCategory>().ToTable("ProductCategory");

            builder.Entity<ProductCategory>()
                 .HasKey(pk => pk.Id);

            builder.Entity<ProductCategory>()
                 .HasOne(p => p.Product)
                 .WithMany(pg => pg.productCategories)
                 .HasForeignKey(fk => fk.ProductId).IsRequired().OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ProductCategory>()
                 .HasOne(p => p.Category)
                 .WithMany(pg => pg.productCategories)
                .HasForeignKey(fk => fk.CategoryId).IsRequired().OnDelete(DeleteBehavior.NoAction);

            #endregion


            #region ProductGallery

            builder.Entity<ProductGallery>().ToTable("ProductGallery");


            builder.Entity<ProductGallery>()
                .HasKey(pk => pk.Id);


            builder.Entity<ProductGallery>()
                .HasOne(p => p.Product)
                .WithMany(pg => pg.productGalleries)
                .HasForeignKey(fk => fk.ProductId);

            #endregion

            #region User

            builder.Entity<ApplicationUser>().ToTable("User");

            builder.Entity<ApplicationUser>().HasKey(t => t.Id);

            //builder.Entity<ApplicationUser>().HasIndex(a=>a.UserName).IsUnique();


            #endregion

            #region Role

            builder.Entity<ApplicationRole>().ToTable("Role");

            builder.Entity<ApplicationRole>().HasKey(t => t.Id);


            builder.Entity<ApplicationRole>()
                    .HasData(new ApplicationRole
                    {
                        Id = "ea345380-5af2-4d0c-a0e2-65f3eeabb898",
                        Name = "AplicationAdmin",
                        NormalizedName = "APLICATIONADMIN"
                    });

            builder.Entity<ApplicationRole>()
                .HasData(new ApplicationRole
                {
                    Id = "19b499d6-8920-43c0-a6d7-bbe48c42f7b3",
                    Name = "AplicationUser",
                    NormalizedName = "APLICATIONUSER"
                });


            builder.Entity<ApplicationRole>()
                .HasData(new ApplicationRole
                {
                    Id = "ac0e1032-58c2-449a-8b47-7f6838386bc0",
                    Name = "AplicationSeller",
                    NormalizedName = "APLICATIONSELLER"
                });


            builder.Entity<ApplicationRole>()
               .HasData(new ApplicationRole
               {
                   Id = "07171c7f-a97d-45f8-a76e-2df3398a7e8e",
                   Name = "AplicationSupport",
                   NormalizedName = "APLICATIONSUPPORT"
               });


            #endregion

            #region ChatMessages


            //builder.Entity<ChatMessage>().ToTable("ChatMessage");


            //builder.Entity<ChatMessage>()
            //    .HasKey(pk => pk.Id);



            //builder.Entity<ChatMessage>()
            //    .HasOne(cg => cg.ChatGroup)
            //    .WithMany(c => c.Chats)
            //    .HasForeignKey(fk => fk.ChatGroupId).IsRequired(false)
            //    .OnDelete(DeleteBehavior.Restrict);


            //builder.Entity<ChatMessage>()
            //    .HasOne(u => u.User)
            //    .WithMany(c => c.ChatMessages)
            //    .HasForeignKey(fk => fk.UserId)
            //    .OnDelete(DeleteBehavior.Restrict);


            #endregion

            #region Store

            builder.Entity<Store>().ToTable("Store");

            builder.Entity<Store>().HasKey(pk => pk.Id);

            #endregion

            #region AppSetting

            builder.Entity<AppSetting>().ToTable("AboutUs");

            builder.Entity<AppSetting>()
                .HasKey(pk => pk.Id);

            builder.Entity<AppSetting>()
                .HasData(new AppSetting
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = _configuration.GetSection("Email")["AboutUsEmail"],
                    Description = "فروشگاه روبیک مارکت ",
                    PhoneNumber = _configuration.GetSection("Email")["PhoneNumber"],
                    CreatedAt = UserExtention.GetPersianDateTime(DateTime.Now)
                });

            #endregion

            #region ContactUs

            builder.Entity<ContactUs>().ToTable("ContactUs");


            builder.Entity<ContactUs>()
                .HasOne(u => u.User)
                .WithMany(c => c.ContactUs)
                .HasForeignKey(fk => fk.UserId).IsRequired(false);

            #endregion

            #region Slider

            builder.Entity<Slider>().ToTable("Slider");


            builder.Entity<Slider>()
                .HasKey(pk => pk.Id);

            #endregion

            #region QA

            builder.Entity<QA>().ToTable("QA");

            builder.Entity<QA>().HasKey(pk => pk.Id);

            builder.Entity<QA>().HasData(new QA
            {
                Id = "ae086c96-f400-4af7-b0bd-0e416e91c4c4"
                ,
                Question = "روبیک مارکت چیست ؟",
                Answer =
                "روبیک مارکت یک پلتفرم فروشگاه انلاین است که ماهانه صدها کالای جذاب و پرطرفدار را با قیمت های باورنکردنی برای کاربران خود به حراج می گذارد." +
                " شما می توانید از طریق وب سایت ، لیست حراج های روزانه را مشاهده کرده و برای شرکت در آنها ثبت نام کنید",
                CreatedAt = UserExtention.GetPersianDateTime(DateTime.Now)
            },

            new QA
            {
                Id = "f839f213-d2be-4032-8dcc-586424c288e0"
                ,
                Question = "چگونه به روبیک مارکت اعتماد کنم؟",
                Answer =
                "روییک مارکت دارای نماد اعتماد الکترونیک از مرکز تجارت الکترونیک (وزارت صنعت ، معدن و تجارت) است " +
                "و با کلیک بر روی نماد مذکور در وب سایت روبیک مارکت می توانید مشخصات دقیق آن را ملاحظه نمایید",
                CreatedAt = UserExtention.GetPersianDateTime(DateTime.Now)
            },

            new QA
            {
                Id = "00b8689e-5add-4607-95b6-ddc60d6c9ca8",
                Question = "روش تماس با روبیک مارکت چگونه است ؟",
                Answer = "تماس تلفنی با کارشناسان پشتیبانی روییک مارکت از طریق شماره تماس مندرج در بخش تماس با ما (در شرایط ویژه کرونایی به دلیل دورکاری تمام پرسنل، تماس تلفنی غیر فعال است)",
                CreatedAt = UserExtention.GetPersianDateTime(DateTime.Now)
            },


            new QA
            {
                Id = "70f20b22-620f-4dfc-9da8-561cd00d6cab",
                Question = "هزینه ارسال کالا چگونه محاسبه می شود؟"
                ,
                Answer = "هزینه ارسال کالا به صورت ثابت می باشد.  لذا توصیه می شود به منظور صرفه جویی در هزینه ارسال خود، چند کالا را همزمان با هم سفارش دهید",
                CreatedAt = UserExtention.GetPersianDateTime(DateTime.Now)
            });

            #endregion

            #region UserRole

            builder.Entity<ApplicationUserRole>().ToTable("UserRole");

            builder.Entity<ApplicationUserRole>().HasKey(t => t.Id);


            builder.Entity<ApplicationUserRole>()
                .HasOne(u => u.user)
                .WithMany(ur => ur.userRoles)
                .HasForeignKey(fk => fk.UserId).IsRequired();

            builder.Entity<ApplicationUserRole>()
               .HasOne(u => u.role)
               .WithMany(ur => ur.userRoles)
               .HasForeignKey(fk => fk.RoleId).IsRequired();

            #endregion

            #region IgnoredTables
            builder.Ignore<IdentityUserToken<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityUserClaim<string>>();
            #endregion
        }
    }



}
