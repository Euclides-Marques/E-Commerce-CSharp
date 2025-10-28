using Microsoft.EntityFrameworkCore;

namespace DevMarket.Context
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
    }
}
