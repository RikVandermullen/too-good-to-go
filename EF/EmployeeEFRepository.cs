using Domain;
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

        public ICollection<Employee> GetAll()
        {
            return _dbContext.Employees.Include(c => c.Canteen).ToList();
        }

        public Employee AddEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();

            return GetEmployeeById(employee.Id);
        }

        public void DeleteEmployee(Employee employee)
        {
            var entityToRemove = _dbContext.Employees.FirstOrDefault(r => r.Id == employee.Id);
            if (entityToRemove != null)
            {
                _dbContext.Employees.Remove(entityToRemove);
                _dbContext.SaveChanges();
            }
        }

        public Employee GetEmployeeByEmail(string email)
        {
            return _dbContext.Employees.Include(c => c.Canteen).FirstOrDefault(e => e.EmailAddress == email);
        }

        public Employee GetEmployeeById(int id)
        {
            return _dbContext.Employees.Include(c => c.Canteen).FirstOrDefault(e => e.Id == id);
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var entityToUpdate = _dbContext.Employees.Include(c => c.Canteen).FirstOrDefault(r => r.Id == employee.Id);
            if (entityToUpdate != null)
            {
                entityToUpdate.Name = employee.Name;
                entityToUpdate.EmployeeNumber = employee.EmployeeNumber;
                entityToUpdate.CanteenId = employee.CanteenId;
                entityToUpdate.EmailAddress = employee.EmailAddress;

                _dbContext.SaveChanges();
            }
            return GetEmployeeById(entityToUpdate.Id);
        }
    }
}
