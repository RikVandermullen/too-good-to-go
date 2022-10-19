namespace DomainServices
{
    public interface IStudentRepository
    {
        Student? AddStudent(Student newStudent);

        Student? GetStudentByEmail(string emailAddress);
    }
}