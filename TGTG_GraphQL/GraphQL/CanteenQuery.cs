using DomainServices;
using Domain;

namespace TGTG_GraphQL.GraphQL
{
    [ExtendObjectType("Query")]
    public class CanteenQuery
    {
        private readonly ICanteenRepository _canteenRepository;

        public CanteenQuery(ICanteenRepository canteenRepository)
        {
            _canteenRepository = canteenRepository;
        }

        public IEnumerable<Canteen> Canteens()
        {
            return _canteenRepository.GetAllCanteens();
        }

        public Canteen GetCanteen(int id)
        {
            return _canteenRepository.GetCanteenById(id);
        }
    }
}
