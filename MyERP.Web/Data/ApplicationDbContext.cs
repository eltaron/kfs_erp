using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyERP.Web.Data
{
    // بنورث من IdentityDbContext عشان ينزل جداول المستخدمين (Users, Roles, Logins)
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // هنا بنعرف الجداول الخاصة بينا مستقبلاً
        // public DbSet<Employee> Employees { get; set; }
    }
}