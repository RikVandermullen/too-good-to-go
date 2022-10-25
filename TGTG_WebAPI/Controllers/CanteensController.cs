using Domain;
using DomainServices;
using Microsoft.AspNetCore.Mvc;

namespace TGTG_WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CanteensController : ControllerBase
    {
        private readonly ICanteenRepository _canteenRepository;

        public CanteensController(ICanteenRepository canteenRepository)
        {
            _canteenRepository = canteenRepository;
        }

        [HttpGet]
        public ActionResult<List<Canteen>> Get()
        {
            return Ok(_canteenRepository.GetAllCanteens());
        }

        [HttpGet("{id}")]
        public ActionResult<Canteen> GetById(int id)
        {
            return Ok(_canteenRepository.GetCanteenById(id));
        }

        [HttpPost]
        public ActionResult<Canteen> AddCanteen(Canteen canteen)
        {
            return _canteenRepository.AddCanteen(canteen);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCanteen(int id)
        {
            var canteen = _canteenRepository.GetCanteenById(id);
            _canteenRepository.DeleteCanteen(canteen);

            return new NoContentResult();
        }

        [HttpPut("{id}")]
        public ActionResult<Canteen> Update(int id, [FromBody] Canteen canteen)
        {
            var Canteen = _canteenRepository.GetCanteenById(id);

            if (canteen == null || id != canteen.Id)
            {
                return BadRequest();
            }
            return _canteenRepository.UpdateCanteen(canteen);
        }
    }
}
