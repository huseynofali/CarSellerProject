using CarSellerProject.Core.Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSellerProject.Core.DataAccessLayer
{
    public static class Mapper
    {
        public static CarGallery MapCarGallery(IDataReader reader)
        {
            return new CarGallery
            {
                Name = Convert.ToString(reader["Name"]),
                Id = Convert.ToInt32(reader["GalleryID"]),
                ContactEmail = Convert.ToString(reader["ContactEmail"]),
                ContactPhone = Convert.ToString(reader["ContactPhone"])
            };
        }
        public static Car MapCar(IDataReader reader)
        {
            Car car = new Car
            {
                Id = Convert.ToInt32(reader["CarID"]),
                Make = Convert.ToString(reader["Make"]),
                Model = Convert.ToString(reader["Model"]),
                Year = Convert.ToInt32(reader["Year"]),
                Price = Convert.ToDecimal(reader["Price"]),
                Mileage = Convert.ToInt32(reader["Mileage"]),
                Color = Convert.ToString(reader["Color"]),
                GalleryID = Convert.ToInt32(reader["GalleryID"])
            };

            return car;
        }

        public static User MapUser(IDataReader reader)
        {
            return new User
            {
                Username = (string)reader["username"],
                Email = (string)reader["email"],
                PasswordHash = (string)reader["passwordhash"]
            };
        }

    }
}
