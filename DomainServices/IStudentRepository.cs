namespace DomainServices
{
    public interface IStudentRepository
    {
        Student? AddStudent(Student newStudent);

        Student? GetStudentByStudentNr(int StudentNr);
    }
}