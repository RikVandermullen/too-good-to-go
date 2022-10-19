namespace DomainServices
{
    public interface IPacketRepository
    {
        IEnumerable<Packet>? GetPackets();

        Packet? GetPacketById(int id);

        IEnumerable<Packet>? GetPacketsByStudentId(Student student);

        Packet? AddPacket(Packet newPacket);

        Packet? DeletePacket(Packet packet);

        Packet? UpdatePacket(Packet packet);
    }
}
