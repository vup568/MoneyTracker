using Microsoft.EntityFrameworkCore;
using PersonalLifeOS.Domain.Finance;

namespace PersonalLifeOS.Infrastructure.Persistence
{
    public class FinanceDbContext : DbContext
    {
        //khởi tạo đối tượng FinanceDbContext DB kế thừa từ class DbContext 
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options): base(options) { }
        //trong program.cs khi khởi tạo Db thì, DI sẽ tạo ra và truyền một đối tượng có kiểu là FinanceDbContext tương ứng cho options ( chứa SQL server provider, connection string, cấu hình EF core )

        //base(options) là chuyển cấu hình options cho DbContext cha xử lý 

        //EF Core hãy tạo bảng Categories
        public DbSet<Category> Categories { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            //EF core có sẵn DbContext có hàm virtual OnModelCreating -> chúng ta sẽ gọi lại hàm đó của lớp cha nên phải thêm override 
        {
            base.OnModelCreating(modelBuilder);
            // chạy cấu hình mặc định của EF core trước xong mới chạy tới cấu hình bên dưới của tôi 
            //Thực ra có thể bỏ đi vẫn chạy được nhưng mà sau này còn có nhiều các cấu hình khác được Microsoft thêm trong DbContext cha. Chúng ta không muốn bỏ qua các cấu hình đó 
            // Ví dụ như JWT, Identity 

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Category>()
                .Property(c => c.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Title)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Category)
                .WithMany(t => t.Transactions)
                .HasForeignKey(t => t.CategoryId);

        }

    }
}
