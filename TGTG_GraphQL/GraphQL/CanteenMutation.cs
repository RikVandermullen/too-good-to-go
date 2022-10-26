using DomainServices;
using Domain;

namespace TGTG_GraphQL.GraphQL
{
    [ExtendObjectType("Mutation")]
    public class CanteenMutation
    {
        private readonly ICanteenRepository _canteenRepository;

        public CanteenMutation(ICanteenRepository canteenRepository)
        {
            _canteenRepository = canteenRepository;
        }

        public Canteen CreateCanteen(NewCanteenDTO canteen) => _canteenRepository.AddCanteen(new Canteen { City = canteen.City, Location = canteen.Location, WarmMeals = canteen.WarmMeals });

        public Canteen UpdateCanteen(Canteen canteen) => _canteenRepository.UpdateCanteen(canteen);

        public bool DeleteCanteen(int id)
        {
            var Canteen = _canteenRepository.GetCanteenById(id);

            if (Canteen != null)
            {
                _canteenRepository.DeleteCanteen(Canteen);
                return true;
            }
            return false;
        }
    }
}
