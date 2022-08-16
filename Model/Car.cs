using Microsoft.Web.Administration;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
namespace WebApplicationApi.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public short Year { get;  set; }
        public short Manufacturing { get;  set; }
        public string Color { get; private set; }
        public string Fuel { get;  set; }
        public bool Automatic { get; set; }
        public decimal Value { get; set; }
        public bool Active { get;  set; }

        public Car(int id, string brand, string model, short year, short manufacturing, string color, string fuel, bool automatic, decimal value, bool active)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Year = year;
            Manufacturing = manufacturing;
            Color = color;
            Fuel = fuel;
            Automatic = automatic;
            Value = value;
            Active = active;
        }
    }       

    }

