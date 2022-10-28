namespace DomainServices.Services
{
    public class ReservePacketService
    {
        private StudentOfAgeService studentOfAgeService;

        public ReservePacketService(StudentOfAgeService studentOfAgeService)
        {
            this.studentOfAgeService = studentOfAgeService;
        }

        public bool DoesProductsInPacketContainAlcohol(Packet packet)
        {
            foreach (var p in packet.Products)
            {
                if (p.HasAlcohol)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CanStudentReservePacket(Packet packet, Student student)
        {
            if (student == null && packet == null || student == null && packet != null || student != null && packet == null) return false;

            if (DoesProductsInPacketContainAlcohol(packet))
            {
                if (studentOfAgeService.IsStudentOfAge(student, packet.PickUpTime)) return true;
                return false;
            }
            return true;
        }
    }
}
