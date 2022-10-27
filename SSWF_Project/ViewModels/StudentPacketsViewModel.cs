using Domain;
using DomainServices.Services;

namespace TGTG_Portal.ViewModels
{
    public class StudentPacketsViewModel
    {
        public Student Student { get; set; } = null!;

        public IEnumerable<Packet> Packets { get; set; } = Enumerable.Empty<Packet>();

        public FormatterService fs = new FormatterService();

        public StudentPacketsViewModel(Student student, IEnumerable<Packet> packets)
        {
            Student = student;
            Packets = packets;
        }
    }
}
