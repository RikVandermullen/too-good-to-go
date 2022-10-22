using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGTG_EF
{
    public class CanteenEFRepository : ICanteenRepository
    {
        private readonly TGTGDbContext _dbContext;

        public CanteenEFRepository(TGTGDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Canteen> GetAllCanteens()
        {
            return _dbContext.Canteens.ToList();
        }

        public Canteen GetCanteenById(int id)
        {
            return _dbContext.Canteens.FirstOrDefault(c => c.Id == id);
        }
    }
}
