namespace TGTG_GraphQL.GraphQL
{
    [ExtendObjectType("Query")]
    public class PacketQuery
    {
        private readonly IPacketRepository _packetRepository;

        public PacketQuery(IPacketRepository packetRepository)
        {
            _packetRepository = packetRepository;
        }

        public IEnumerable<Packet> Packets()
        {
            return _packetRepository.GetPackets();
        }

        public Packet GetPacket(int id)
        {
            return _packetRepository.GetPacketById(id);
        }
    }
}
