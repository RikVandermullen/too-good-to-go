using Domain;

namespace TGTG_EF
{
    public class CanteenEFRepository : ICanteenRepository
    {
        private readonly TGTGDbContext _dbContext;

        public CanteenEFRepository(TGTGDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Canteen AddCanteen(Canteen canteen)
        {
            _dbContext.Canteens.Add(canteen);
            _dbContext.SaveChanges();

            return canteen;

        }

        public void DeleteCanteen(Canteen canteen)
        {
            var entityToRemove = _dbContext.Canteens.FirstOrDefault(r => r.Id == canteen.Id);
            if (entityToRemove != null)
            {
                _dbContext.Canteens.Remove(entityToRemove);
                _dbContext.SaveChanges();
            }
        }

        public List<Canteen> GetAllCanteens()
        {
            return _dbContext.Canteens.ToList();
        }

        public Canteen GetCanteenById(int id)
        {
            return _dbContext.Canteens.FirstOrDefault(c => c.Id == id);
        }

        public Canteen UpdateCanteen(Canteen canteen)
        {
            var entityToUpdate = _dbContext.Canteens.FirstOrDefault(r => r.Id == canteen.Id);
            if (entityToUpdate != null)
            {
                entityToUpdate.Location = canteen.Location;
                entityToUpdate.City = canteen.City;
                entityToUpdate.WarmMeals = canteen.WarmMeals;

                _dbContext.SaveChanges();
            }
            return entityToUpdate;
        }
    }
}
