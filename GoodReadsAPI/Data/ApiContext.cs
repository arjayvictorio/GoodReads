using DatabaseService.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodReadsAPI.Data
{
    public class ApiContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {

        }
    }
}
