using Microsoft.EntityFrameworkCore;
using TaskManagmentAPI.Models;

namespace TaskManagmentAPI.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
            
        }

        public DbSet<TaskItem> taskItems { get; set; }
    }
}
