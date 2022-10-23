using Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net.Sockets;
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

        public Packet AddPacket(Packet packet)
        {
            var Packet = new Packet() { Name = packet.Name, Price = packet.Price, City = packet.City, MealType = packet.MealType, CanteenId = packet.CanteenId, ContainsAlcohol = packet.ContainsAlcohol, PickUpTime = packet.PickUpTime, LastestPickUpTime = packet.LastestPickUpTime, ReservedBy = null };
            _dbContext.Packets.Add(Packet);
            _dbContext.SaveChanges();

            foreach (var p in packet.Products)
            {
                _dbContext.PacketProduct.Add(new PacketProduct { PacketId = Packet.Id, ProductId = p.Id });
            }
            _dbContext.SaveChanges();

            return packet;
        }

        public Packet? DeletePacket(int id)
        {
            var entityToRemove = _dbContext.Packets.Include(p => p.Products).FirstOrDefault(r => r.Id == id);
            if (entityToRemove != null)
            {
                List<PacketProduct> list = _dbContext.PacketProduct.Where(p => p.PacketId == id).ToList();
                foreach (var pp in list)
                {
                    _dbContext.PacketProduct.Attach(pp);
                    _dbContext.PacketProduct.Remove(pp);
                    _dbContext.SaveChanges();
                }

                _dbContext.Packets.Remove(entityToRemove);
                _dbContext.SaveChanges();
            }

            return entityToRemove;
        }

        public Packet? GetPacketById(int id)
        {
            return _dbContext.Packets.Include(p => p.Products).Include(c => c.Canteen).FirstOrDefault(p => p.Id.Equals(id));
        }

        public IEnumerable<Packet>? GetPacketsByStudentId(Student student)
        {
            return _dbContext.Packets.Where(p => p.ReservedBy.Equals(student)).Include(p => p.Products).ToList();
        }

        public IEnumerable<Packet>? GetPackets()
        {
            return _dbContext.Packets.Include(p => p.Products).Include(c => c.Canteen).OrderBy(p => p.PickUpTime).ToList();
        }

        public async Task<Packet> UpdatePacket(Packet packet)
        {
            var entityToUpdate = _dbContext.Packets.Include(p => p.Products).FirstOrDefault(r => r.Id == packet.Id);
            if (entityToUpdate != null)
            {
                entityToUpdate.Name = packet.Name;
                entityToUpdate.Price = packet.Price;
                entityToUpdate.PickUpTime = packet.PickUpTime;
                entityToUpdate.LastestPickUpTime = packet.LastestPickUpTime;
                entityToUpdate.ReservedBy = packet.ReservedBy;
                entityToUpdate.City = packet.City;
                entityToUpdate.CanteenId = packet.CanteenId;
                entityToUpdate.MealType = packet.MealType;
                entityToUpdate.ContainsAlcohol = packet.ContainsAlcohol;

                _dbContext.SaveChanges();

                List<PacketProduct> list = _dbContext.PacketProduct.Where(p => p.PacketId == packet.Id).ToList();
                foreach (var pp in list)
                {
                    _dbContext.PacketProduct.Attach(pp);
                    _dbContext.PacketProduct.Remove(pp);
                    await _dbContext.SaveChangesAsync();
                }

                foreach (var p in packet.Products)
                {
                    _dbContext.PacketProduct.Add(new PacketProduct { PacketId = packet.Id, ProductId = p.Id });
                }
                await _dbContext.SaveChangesAsync();

            }
            return entityToUpdate;

        }
    }
}
