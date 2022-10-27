namespace DomainServices
{
    public interface IPacketRepository
    {
        IEnumerable<Packet>? GetPackets();

        public IEnumerable<Packet>? GetPacketsWithoutReservations();

        Packet? GetPacketById(int id);

        IEnumerable<Packet>? GetPacketsByStudentId(Student student);

        public IEnumerable<Packet>? GetPacketsByCanteenId(int id);

        Packet? AddPacket(Packet newPacket);

        Packet? DeletePacket(int id);

        Task<Packet> UpdatePacket(Packet packet);

        Packet ReservePacket(int id, Student student);
    }
}
