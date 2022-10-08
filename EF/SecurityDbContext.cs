using Microsoft.EntityFrameworkCore;

namespace TGTG_EF
{
    public class SecurityDbContext : DbContext
    {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options)
        {

        }
    }
}
