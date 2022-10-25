namespace DomainServices
{
    public interface IStudentRepository
    {
        Student? AddStudent(Student newStudent);

        Student? GetStudentByEmail(string emailAddress);

        Student? GetStudentById(int id);

        ICollection<Student> GetAll();

        void DeleteStudent(Student student);

        Student UpdateStudent(Student student);
    }
}