using Domain;
using DomainServices;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using TGTG_WebAPI.Models;

namespace TGTG_WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PacketsController : ControllerBase
    {
        private readonly IPacketRepository _packetRepository;

        public PacketsController(IPacketRepository packetRepository)
        {
            _packetRepository = packetRepository;
        }

        [HttpGet]
        public ActionResult<List<NewPacketDTO>> Get()
        {
            List<NewPacketDTO> newPacketDTOs = new List<NewPacketDTO>();
            List<Packet> packets = _packetRepository.GetPackets().ToList();
            foreach(var packet in packets)
            {
                List<NewProductDTO> products = new List<NewProductDTO>();
                foreach (var p in packet.Products)
                {
                    products.Add(new NewProductDTO { Id = p.Id, Name = p.Name, HasAlcohol = p.HasAlcohol, Image = p.Image });
                }
                newPacketDTOs.Add(
                    new NewPacketDTO
                    {
                        Id = packet.Id,
                        Name = packet.Name,
                        Price = packet.Price,
                        PickUpTime = packet.PickUpTime,
                        LastestPickUpTime = packet.LastestPickUpTime,
                        City = packet.City,
                        MealType = packet.MealType,
                        CanteenId = packet.CanteenId,
                        ContainsAlcohol = packet.ContainsAlcohol,
                        Products = products
                    });
            }
            return Ok(newPacketDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<NewPacketDTO> Get(int id)
        {
            var Packet = _packetRepository.GetPacketById(id);
            List<NewProductDTO> products = new List<NewProductDTO>();
            foreach (var p in Packet.Products)
            {
                products.Add(new NewProductDTO { Id = p.Id, Name = p.Name, HasAlcohol = p.HasAlcohol, Image = p.Image });
            }

            return Ok(new NewPacketDTO
            {
                Id = Packet.Id,
                Name = Packet.Name,
                Price = Packet.Price,
                PickUpTime = Packet.PickUpTime,
                LastestPickUpTime = Packet.LastestPickUpTime,
                City = Packet.City,
                MealType = Packet.MealType,
                CanteenId = Packet.CanteenId,
                ContainsAlcohol = Packet.ContainsAlcohol,
                Products = products
            });
        }

        [HttpPost]
        public ActionResult<NewPacketDTO> AddPacket(NewPacketDTO packet)
        {
            List<Product> products = new List<Product>();
            foreach(var p in packet.Products)
            {
                products.Add(new Product { Id = p.Id, Name = p.Name, HasAlcohol = p.HasAlcohol, Image = p.Image });
            }

            var Packet = new Packet
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
            };
            var newPacket = _packetRepository.AddPacket(Packet);
            List<NewProductDTO> newProducts = new List<NewProductDTO>();
            foreach (var p in newPacket.Products)
            {
                newProducts.Add(new NewProductDTO { Id = p.Id, Name = p.Name, HasAlcohol = p.HasAlcohol, Image = p.Image });
            }

            return Ok(new NewPacketDTO
            {
                Id = newPacket.Id,
                Name = newPacket.Name,
                Price = newPacket.Price,
                PickUpTime = newPacket.PickUpTime,
                LastestPickUpTime = newPacket.LastestPickUpTime,
                City = newPacket.City,
                MealType = newPacket.MealType,
                CanteenId = newPacket.CanteenId,
                ContainsAlcohol = newPacket.ContainsAlcohol,
                Products = newProducts
            });
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var Packet = _packetRepository.GetPacketById(id);
            if (Packet != null)
            {
                _packetRepository.DeletePacket(id);
            }

            return new NoContentResult();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<NewPacketDTO>> Update(int id, [FromBody] NewPacketDTO packet)
        {
            var Packet = _packetRepository.GetPacketById(id);

            if (Packet == null || id != packet.Id)
            {
                return BadRequest();
            }

            List<Product> products = new List<Product>();
            foreach (var p in packet.Products)
            {
                products.Add(new Product { Id = p.Id, Name = p.Name, HasAlcohol = p.HasAlcohol, Image = p.Image });
            }

            var UpdatedPacket = new Packet
            {
                Id = packet.Id,
                Name = packet.Name,
                Price = packet.Price,
                PickUpTime = packet.PickUpTime,
                LastestPickUpTime = packet.LastestPickUpTime,
                City = packet.City,
                MealType = packet.MealType,
                CanteenId = packet.CanteenId,
                ContainsAlcohol = packet.ContainsAlcohol,
                Products = products
            };
            await _packetRepository.UpdatePacket(UpdatedPacket);
            return packet;
        }
    }
}
