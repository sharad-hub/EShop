using Repository.Pattern.Ef6;
using Shop.Data.Mapping;
using Shop.Entities;
using Shop.Entities.Display;
using System.Data.Entity;
using System.Data.Entity.Infrastructure; 

namespace Shop.Data
{
    public partial class ShopDBContext : DataContext
    {
        static    ShopDBContext()
        {
            Database.SetInitializer<ShopDBContext>(null);
        }
        public ShopDBContext()
            : base("EShopDb")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CustomerDemographic> CustomerDemographics { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }      
        public DbSet<Territory> Territories { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Error> Errors { get; set; }

        public IDbSet<Menu> Menus { get; set; }

        public IDbSet<ProductLabel> ProductLabeles { get; set; }
        public IDbSet<ProductTag> ProductTags { get; set; }
        public IDbSet<CategoriesToShow> CategoriesToDisplay { get; set; }

        public IDbSet<Blog> Blogs { get; set; }
        public IDbSet<BlogLike> BlogLike { get; set; }
        public IDbSet<BlogComment> BlogComments { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CustomerDemographicMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new RegionMap());
            modelBuilder.Configurations.Add(new ShipperMap());
            modelBuilder.Configurations.Add(new SupplierMap());           
            modelBuilder.Configurations.Add(new TerritoryMap());

            modelBuilder.Configurations.Add(new UserRoleMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new MenuMap());

            modelBuilder.Configurations.Add(new BlogMap());
            modelBuilder.Configurations.Add(new BlogLikeMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new BlogCommentMap());

                base.OnModelCreating(modelBuilder);
        }
    }
}
