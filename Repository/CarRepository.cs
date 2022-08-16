
using WebApplicationApi.Model;
using Dapper;
using System.Data;
using WebApplicationApi.Factory;

namespace WebApplicationApi.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly IDbConnection _connection;

        public CarRepository()
        {
            _connection = new SqlFactory().SqlConnection();
        }

        public IEnumerable<Car> GetCars()
        {
            var cars = new List<Car>();
            var query = "SELECT * FROM [car].[dbo].[cars]";

            using (_connection)
            {
                cars = _connection.Query<Car>(query).ToList();
            }

            return cars;

        }

        public bool InsertCar(Car car)
        {
            var query = "INSERT INTO [car].[dbo].[cars] " +
                "VALUES " +
                "(" +
                "@Brand, @Model, @Year, @Manufacturing, @Color, " +
                "@Fuel, @Automatic, @Value, @Active " +
                ")";

            var parameters = new
            {
                
                brand = car.Brand,
                model = car.Model,
                year = car.Year,
                manufacturing = car.Manufacturing,
                color = car.Color,
                fuel = car.Fuel,
                automatic = car.Automatic,
                value = car.Value,
                active = car.Active
            };

            int result = 0;

            using (_connection)
            {
                result = _connection.Execute(query, parameters);
            }
            return (result != 0 ? true : false);
        }


        public bool UpdateCarColor(int Id, string Color)
        {
            var query = "UPDATE [car].[dbo].[cars]" +
                 "SET" +
                 "[color] = @Color" +
                 " WHERE [id] = @Id";

            var parameters = new
            {
                id = Id,
                color = Color
            };

            int result = 0;

            using (_connection)
            {
                result = _connection.Execute(query, parameters);
            }
            return (result != 0 ? true : false);


        }

        public bool DeleteCar(int Id)
        {
            var query = "DELETE [car].[dbo].[cars] where [id] = @Id";
            var parameters = new { id = Id };

            int result = 0;
            using (_connection)
            {
                result = _connection.Execute(query, parameters);

            }

            return (result != 0 ? true : false);

        }

    }
}
