namespace DomainServices
{
    public interface IPacketRepository
    {
        IEnumerable<Packet>? GetPackets();

        Packet? GetPacketById(int id);

        IEnumerable<Packet>? GetPacketsByStudentId(Student student);

        Packet? AddPacket(Packet newPacket);

        Packet? DeletePacket(int id);

        Task<Packet> UpdatePacket(Packet packet);

        Packet ReservePacket(int id, Student student);
    }
}
