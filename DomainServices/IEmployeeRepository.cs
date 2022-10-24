namespace DomainServices
{
    public interface IEmployeeRepository
    {
        public Employee GetEmployeeByEmail(string email);
    }
}
