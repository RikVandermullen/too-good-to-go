using Domain;
using DomainServices;
using Microsoft.AspNetCore.Mvc;
using TGTG_GraphQL.Models;

namespace TGTG_GraphQL.GraphQL
{
    [ExtendObjectType("Mutation")]
    public class StudentMutation
    {
        private readonly IStudentRepository _studentRepository;

        public StudentMutation(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public bool DeleteStudent(int id)
        {
            var Student = _studentRepository.GetStudentById(id);

            if (Student != null)
            {
                _studentRepository.DeleteStudent(Student);
                return true;
            }
            return false; 
        }

        public Student CreateStudent(NewStudentDTO student) => _studentRepository.AddStudent(new Student { Name = student.Name, EmailAddress = student.EmailAddress, PhoneNumber = student.PhoneNumber, City = student.City, BirthDate = student.BirthDate, StudentNumber = student.StudentNumber, noShows = student.noShows});
               
        public Student UpdateStudent(Student student) => _studentRepository.UpdateStudent(student);
    }
}
