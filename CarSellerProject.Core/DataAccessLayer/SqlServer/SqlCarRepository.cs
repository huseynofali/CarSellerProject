using CarSellerProject.Core.Domain.Entities;
using CarSellerProject.Core.Domain.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSellerProject.Core.DataAccessLayer.SqlServer
{
    public class SqlCarRepository : ICarRepository
    {
        private readonly string _connectionString;

        public SqlCarRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Car car)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = "INSERT INTO Cars (Make, Model, Year, Price, Mileage, Color, GalleryID) " +
                           "VALUES (@make, @model, @year, @price, @mileage, @color, @galleryID);";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@make", car.Make);
            cmd.Parameters.AddWithValue("@model", car.Model);
            cmd.Parameters.AddWithValue("@year", car.Year);
            cmd.Parameters.AddWithValue("@price", car.Price);
            cmd.Parameters.AddWithValue("@mileage", car.Mileage);
            cmd.Parameters.AddWithValue("@color", car.Color);
            cmd.Parameters.AddWithValue("@galleryID", car.GalleryID);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = "DELETE FROM Cars WHERE CarID = @id;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
        public void Update(Car car)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = "UPDATE Cars SET Make = @make, Model = @model, Year = @year, Price = @price, Mileage = @mileage, Color = @color, GalleryID = @galleryID WHERE CarID = @carID;";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@make", car.Make);
            cmd.Parameters.AddWithValue("@model", car.Model);
            cmd.Parameters.AddWithValue("@year", car.Year);
            cmd.Parameters.AddWithValue("@price", car.Price);
            cmd.Parameters.AddWithValue("@mileage", car.Mileage);
            cmd.Parameters.AddWithValue("@color", car.Color);
            cmd.Parameters.AddWithValue("@galleryID", car.GalleryID);
            cmd.Parameters.AddWithValue("@carID", car.Id);

            cmd.ExecuteNonQuery();
        }

        public Car Get(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT * FROM Cars WHERE CarID = @id;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return Mapper.MapCar(reader);
            }
            return null;
        }

        public List<Car> Get()
        {
            List<Car> cars = new List<Car>();

            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT * FROM Cars;";
            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cars.Add(Mapper.MapCar(reader));
            }

            return cars;
        }

    }
}
