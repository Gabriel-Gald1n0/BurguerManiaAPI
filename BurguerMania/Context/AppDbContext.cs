using Microsoft.EntityFrameworkCore;
using BurguerManiaAPI.Models;

namespace BurguerManiaAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<UsersModel> Users { get; set; } = null!;
        public DbSet<CategorysModel> Categories { get; set; } = null!;
        public DbSet<ProductsModel> Products { get; set; } = null!;
        public DbSet<OrdersModel> Orders { get; set; } = null!;
        public DbSet<StatusModel> Status { get; set; } = null!;
        public DbSet<OrderProductsModel> OrdersProducts { get; set; } = null!;
        public DbSet<UserOrdersModel> UsersOrders { get; set; } = null!;
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração para a tabela Users
            modelBuilder.Entity<UsersModel>()
                .Property(u => u.Name)
                .HasColumnType("VARCHAR(100)");

            modelBuilder.Entity<UsersModel>()
                .Property(u => u.Email)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            modelBuilder.Entity<UsersModel>()
                .Property(u => u.Password)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            // Configuração para a tabela Categories
            modelBuilder.Entity<CategorysModel>()
                .Property(c => c.Name)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            modelBuilder.Entity<CategorysModel>()
                .Property(c => c.Description)
                .HasColumnType("TEXT");

            modelBuilder.Entity<CategorysModel>()
                .Property(c => c.PathImage)
                .HasColumnType("VARCHAR(255)");

            // Configuração para a tabela Products
            modelBuilder.Entity<ProductsModel>()
                .Property(p => p.Name)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            modelBuilder.Entity<ProductsModel>()
                .Property(p => p.Price)
                .HasColumnType("DECIMAL(18,2)");

            modelBuilder.Entity<ProductsModel>()
                .HasIndex(p => p.Name)
                .IsUnique()
                .HasDatabaseName("IX_Products_NameUnique");

            modelBuilder.Entity<ProductsModel>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração para a tabela Orders
            modelBuilder.Entity<OrdersModel>()
                .Property(o => o.Value)
                .HasColumnType("DECIMAL(18,2)");

            modelBuilder.Entity<OrdersModel>()
                .HasOne(o => o.Status)
                .WithMany()
                .HasForeignKey(o => o.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração para a tabela Status
            modelBuilder.Entity<StatusModel>()
                .Property(s => s.Name)
                .HasColumnType("VARCHAR(50)");

            modelBuilder.Entity<StatusModel>()
                .HasData(
                    new StatusModel { Id = 1, Name = "EmAndamento" },
                    new StatusModel { Id = 2, Name = "Concluido" },
                    new StatusModel { Id = 3, Name = "Cancelado" }
                );

            // Configuração para a tabela OrdersProducts
            modelBuilder.Entity<OrderProductsModel>()
                .HasOne(op => op.Product)
                .WithMany()
                .HasForeignKey(op => op.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderProductsModel>()
                .HasOne(op => op.Order)
                .WithMany()
                .HasForeignKey(op => op.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração para a tabela UsersOrders
            modelBuilder.Entity<UserOrdersModel>()
                .HasOne(uo => uo.User)
                .WithMany()
                .HasForeignKey(uo => uo.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserOrdersModel>()
                .HasOne(uo => uo.Order)
                .WithMany()
                .HasForeignKey(uo => uo.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    
    }
}