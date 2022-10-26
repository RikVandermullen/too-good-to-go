namespace DomainServices
{
    public interface ICanteenRepository
    {
        List<Canteen> GetAllCanteens();

        Canteen GetCanteenById(int id);

        Canteen AddCanteen(Canteen canteen);

        Canteen UpdateCanteen(Canteen canteen);

        void DeleteCanteen(Canteen canteen);
    }
}
