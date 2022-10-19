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

    public Student? GetStudentByEmail(string emailAddress)
    {
        return _dbContext.Students.FirstOrDefault(x => x.EmailAddress == emailAddress);
    }
}

