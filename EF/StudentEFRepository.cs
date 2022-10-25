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

    public ICollection<Student> GetAll()
    {
        return _dbContext.Students.ToList();
    }

    public Student? GetStudentByEmail(string emailAddress)
    {
        return _dbContext.Students.FirstOrDefault(x => x.EmailAddress == emailAddress);
    }

    public Student? GetStudentById(int id)
    {
        return _dbContext.Students.FirstOrDefault(x => x.Id == id);
    }

    public void DeleteStudent(Student student)
    {
        var entityToRemove = _dbContext.Students.FirstOrDefault(r => r.Id == student.Id);
        if (entityToRemove != null)
        {
            _dbContext.Students.Remove(entityToRemove);
            _dbContext.SaveChanges();
        }
    }

    public Student UpdateStudent(Student student)
    {
        var entityToUpdate = _dbContext.Students.FirstOrDefault(r => r.Id == student.Id);
        if (entityToUpdate != null)
        {
            entityToUpdate.Name = student.Name;
            entityToUpdate.StudentNumber = student.StudentNumber;
            entityToUpdate.PhoneNumber = student.PhoneNumber;
            entityToUpdate.BirthDate = student.BirthDate;
            entityToUpdate.EmailAddress = student.EmailAddress;
            entityToUpdate.noShows = student.noShows;

            _dbContext.SaveChanges();
        }
        return entityToUpdate;
    }
}

