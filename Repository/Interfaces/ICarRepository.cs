using WebApplicationApi.Model;

namespace WebApplicationApi.Repository
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetCars();

        bool InsertCar(Car car);

        bool UpdateCarColor(int id,string color);

        bool DeleteCar(int id);
    }
}
