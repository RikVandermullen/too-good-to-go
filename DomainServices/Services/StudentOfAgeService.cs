namespace DomainServices.Services
{
    public class StudentOfAgeService
    {
        private Student student;

        public StudentOfAgeService(Student student)
        {
            this.student = student;
        }

        public bool IsStudentOfAge(Student student, DateTime? dateTime)
        {
            if (student == null) return false;

            if (dateTime.Value.Year - student.BirthDate.Value.Year >= 18) return true;

            return false;
        }
    }
}
