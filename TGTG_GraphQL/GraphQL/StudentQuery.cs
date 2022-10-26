using DomainServices;
using Domain;

namespace TGTG_GraphQL.GraphQL
{
    [ExtendObjectType("Query")]
    public class StudentQuery
    {
        private readonly IStudentRepository _studentRepository;

        public StudentQuery(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IEnumerable<Student> Students()
        {
            return _studentRepository.GetAll();
        }

        public Student GetStudent(int id)
        {
            return _studentRepository.GetStudentById(id);
        }
    }
}
