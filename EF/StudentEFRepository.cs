using Domain;

namespace TGTG_EF;

public class StudentEFRepository : IStudentRepository
{
    private readonly TGTGDbContext _dbContext;
    
    public StudentEFRepository(TGTGDbContext context)
    {
        _dbContext = context;
    }

    public Student? AddStudent(Student NewStudent)
    {
        _dbContext.Students.Add(NewStudent);
        _dbContext.SaveChanges();

        return NewStudent;
    }

    public Student? GetStudentByStudentNr(int StudentNr)
    {
        return (Student)_dbContext.Students.Where(x => x.StudentNumber == StudentNr);
    }
}

