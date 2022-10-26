using Domain;

namespace TGTG_GraphQL.GraphQL
{
    [ExtendObjectType("Mutation")]
    public class PacketMutation
    {
        private readonly IPacketRepository _packetRepository;
        private readonly IStudentRepository _studentRepository;

        public PacketMutation(IPacketRepository packetRepository, IStudentRepository studentRepository)
        {
            _packetRepository = packetRepository;
            _studentRepository = studentRepository;
        }

        public Packet CreatePacket(NewPacketDTO packet)
        {
            List<Product> products = new List<Product>();
            foreach (var p in packet.Products)
            {
                products.Add(new Product { Id = p.Id, Name = p.Name, HasAlcohol = p.HasAlcohol, Image = p.Image });
            }

            var Packet = _packetRepository.AddPacket(new Packet
                {
                    Name = packet.Name,
                    Price = packet.Price,
                    PickUpTime = packet.PickUpTime,
                    LastestPickUpTime = packet.LastestPickUpTime,
                    City = packet.City,
                    MealType = packet.MealType,
                    CanteenId = packet.CanteenId,
                    ContainsAlcohol = packet.ContainsAlcohol,
                    Products = products
                }
            );
            return Packet;
        }

        public async Task<Packet> UpdatePacket(NewPacketDTO2 packet)
        {
            List<Product> products = new List<Product>();
            foreach (var p in packet.Products)
            {
                products.Add(new Product { Id = p.Id, Name = p.Name, HasAlcohol = p.HasAlcohol, Image = p.Image });
            }

            var Packet = new Packet
            {
                Id = packet.Id,
                Name = packet.Name,
                Price = packet.Price,
                PickUpTime = packet.PickUpTime,
                LastestPickUpTime = packet.LastestPickUpTime,
                City = packet.City,
                MealType = packet.MealType,
                ReservedBy = packet.ReservedBy,
                CanteenId = packet.CanteenId,
                ContainsAlcohol = packet.ContainsAlcohol,
                Products = products
            };

            return await _packetRepository.UpdatePacket(Packet);
        }

        public bool DeletePacket(int id)
        {
            var Packet = _packetRepository.GetPacketById(id);

            if (Packet != null)
            {
                _packetRepository.DeletePacket(id);
                return true;
            }
            return false;
        }

        public Packet AddReservation(int id, int studentid)
        {
            var Packet = _packetRepository.GetPacketById(id);
            var Student = _studentRepository.GetStudentById(studentid);

            if (Packet != null && Student != null)
            {
                return _packetRepository.ReservePacket(id, Student);
            }

            return Packet;
        }
    }
}
