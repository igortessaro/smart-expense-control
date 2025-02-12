// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;
//
// namespace SmartExpenseControl.Infrastructure.Data;
//
// public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
// {
//     public ApplicationDbContext CreateDbContext(string[] args)
//     {
//         var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
//         optionsBuilder.UseMySql("Server=localhost;Database=smart_expense_control;User=user;Password=password;",
//             new MySqlServerVersion(new Version(8, 0, 21)));
//
//         return new ApplicationDbContext(optionsBuilder.Options);
//     }
// }
