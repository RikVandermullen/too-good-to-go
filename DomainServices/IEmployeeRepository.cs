namespace DomainServices
{
    public interface IEmployeeRepository
    {
        public ICollection<Employee> GetAll();

        public Employee GetEmployeeByEmail(string email);

        public Employee GetEmployeeById(int employeeId);

        public Employee AddEmployee(Employee employee);

        public Employee UpdateEmployee(Employee employee);

        public void DeleteEmployee(Employee employee);
    }
}
