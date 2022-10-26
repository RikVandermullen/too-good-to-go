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
        private readonly IStudentRepository _studentRepository;

        public PacketsController(IPacketRepository packetRepository, IStudentRepository studentRepository)
        {
            _packetRepository = packetRepository;
            _studentRepository = studentRepository;
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
                        PickUpTime = (DateTime)packet.PickUpTime,
                        LastestPickUpTime = (DateTime)packet.LastestPickUpTime,
                        City = packet.City,
                        MealType = packet.MealType,
                        ReservedBy = packet.ReservedBy,
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
                PickUpTime = (DateTime)Packet.PickUpTime,
                LastestPickUpTime = (DateTime)Packet.LastestPickUpTime,
                City = Packet.City,
                MealType = Packet.MealType,
                ReservedBy = Packet.ReservedBy,
                CanteenId = Packet.CanteenId,
                ContainsAlcohol = Packet.ContainsAlcohol,
                Products = products
            });
        }

        [HttpPost]
        public ActionResult<NewPacketDTO> AddPacket(NewPacketDTOWithoutStudent packet)
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
                PickUpTime = (DateTime)newPacket.PickUpTime,
                LastestPickUpTime = (DateTime)newPacket.LastestPickUpTime,
                City = newPacket.City,
                MealType = newPacket.MealType,
                ReservedBy = newPacket.ReservedBy,
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
        public async Task<ActionResult<NewPacketDTOWithoutStudent>> Update(int id, [FromBody] NewPacketDTOWithoutStudent packet)
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

        [HttpPut("{id}/students/{studentid}")]
        public async Task<ActionResult<NewPacketDTO>> UpdateReservation(int id, int studentid, [FromBody] newReservePacketDTO reservation)
        {
            if (id == null || studentid == null || id != reservation.PacketId || studentid != reservation.StudentId)
            {
                return BadRequest();
            }

            var Student = _studentRepository.GetStudentById(studentid);
            var Packet = _packetRepository.GetPacketById(id);
            
            if (Student == null)
            {
                return BadRequest();
            }

            Packet.ReservedBy = Student;

            var UpdatedPacket = await _packetRepository.UpdatePacket(Packet);

            List<NewProductDTO> newProducts = new List<NewProductDTO>();
            foreach (var p in UpdatedPacket.Products)
            {
                newProducts.Add(new NewProductDTO { Id = p.Id, Name = p.Name, HasAlcohol = p.HasAlcohol, Image = p.Image });
            }

            return Ok(new NewPacketDTO
            {
                Id = UpdatedPacket.Id,
                Name = UpdatedPacket.Name,
                Price = UpdatedPacket.Price,
                PickUpTime = (DateTime)UpdatedPacket.PickUpTime,
                LastestPickUpTime = (DateTime)UpdatedPacket.LastestPickUpTime,
                City = UpdatedPacket.City,
                MealType = UpdatedPacket.MealType,
                ReservedBy = UpdatedPacket.ReservedBy,
                CanteenId = UpdatedPacket.CanteenId,
                ContainsAlcohol = UpdatedPacket.ContainsAlcohol,
                Products = newProducts
            });

        }
    }
}
