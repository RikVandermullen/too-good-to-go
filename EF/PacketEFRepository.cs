using Domain;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace TGTG_EF
{
    public class PacketEFRepository : IPacketRepository
    {
        private readonly TGTGDbContext _dbContext;

        public PacketEFRepository(TGTGDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Packet? AddPacket(Packet newPacket)
        {
            _dbContext.Packets.Add(newPacket);
            _dbContext.SaveChanges();

            return newPacket;
        }

        public Packet? DeletePacket(Packet packet)
        {
            var entityToRemove = _dbContext.Packets.FirstOrDefault(r => r.Id == packet.Id);
            if (entityToRemove != null)
            {
                _dbContext.Packets.Remove(entityToRemove);
                _dbContext.SaveChanges();
            }

            return entityToRemove;
        }

        public Packet? GetPacketById(int id)
        {
            return _dbContext.Packets.FirstOrDefault(p => p.Id.Equals(id));
        }

        public IEnumerable<Packet>? GetPackets()
        {
            return _dbContext.Packets.Include(p => p.Products).ToList();          
        }

        public Packet? UpdatePacket(Packet packet)
        {
            var entityToUpdate = _dbContext.Packets.FirstOrDefault(r => r.Id == packet.Id);
            if (entityToUpdate != null)
            {
                entityToUpdate.Name = packet.Name;
                entityToUpdate.Price = packet.Price;
                entityToUpdate.PickUpTime = packet.PickUpTime;
                entityToUpdate.LastestPickUpTime = packet.LastestPickUpTime;
                entityToUpdate.ReservedBy = packet.ReservedBy;
                entityToUpdate.City = packet.City;
                entityToUpdate.Canteen = packet.Canteen;
                entityToUpdate.MealType = packet.MealType;

                _dbContext.SaveChanges();
            }

            return entityToUpdate;
        }
    }
}
