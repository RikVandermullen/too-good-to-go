namespace TGTG_GraphQL.GraphQL
{
    [ExtendObjectType("Mutation")]
    public class EmployeeMutation
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeMutation(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee CreateEmployee(NewEmployeeDTO employee) => _employeeRepository.AddEmployee(new Employee { Name = employee.Name, EmailAddress = employee.EmailAddress, EmployeeNumber = employee.EmployeeNumber, CanteenId = employee.CanteenId });

        public Employee UpdateEmployee(NewEmployeeDTO2 employee) => _employeeRepository.UpdateEmployee(new Employee { Id = employee.Id, Name = employee.Name, EmailAddress = employee.EmailAddress, EmployeeNumber = employee.EmployeeNumber, CanteenId = employee.CanteenId });

        public bool DeleteEmployee(int id)
        {
            var Employee = _employeeRepository.GetEmployeeById(id);

            if (Employee != null) {
                _employeeRepository.DeleteEmployee(Employee);
                return true;
            }
            return false;
        }
    }
}
