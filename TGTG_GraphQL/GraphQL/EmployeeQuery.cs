namespace TGTG_GraphQL.GraphQL
{
    [ExtendObjectType("Query")]
    public class EmployeeQuery
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeQuery(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> Employees()
        {
            return _employeeRepository.GetAll();
        }

        public Employee GetEmployee(int id)
        {
            return _employeeRepository.GetEmployeeById(id);
        }
    }
}
