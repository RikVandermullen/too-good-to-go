using Microsoft.EntityFrameworkCore;

namespace TGTG_EF
{
    public class EmployeeEFRepository : IEmployeeRepository
    {
        private readonly TGTGDbContext _dbContext;

        public EmployeeEFRepository(TGTGDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Employee GetEmployeeByEmail(string email)
        {
            return _dbContext.Employees.Include(c => c.Canteen).FirstOrDefault(e => e.EmailAddress == email);
        }
    }
}
