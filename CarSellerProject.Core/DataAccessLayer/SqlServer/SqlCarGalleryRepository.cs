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
    public class SqlCarGalleryRepository : ICarGalleryRepository
    {
        private readonly string _connectionString;

        public SqlCarGalleryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(CarGallery carGallery)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "INSERT INTO CarGalleries (Name, Location, ContactEmail, ContactPhone) VALUES (@name, @location, @contactEmail, @contactPhone);";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("name", carGallery.Name);
            cmd.Parameters.AddWithValue("location", carGallery.Location);
            cmd.Parameters.AddWithValue("contactEmail", carGallery.ContactEmail);
            cmd.Parameters.AddWithValue("contactPhone", carGallery.ContactPhone);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "DELETE FROM CarGalleries WHERE GalleryID = @id;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();

        }
        public void Update(CarGallery carGallery)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "UPDATE CarGalleries SET Name = @name, Location = @location, ContactEmail = @contactEmail, ContactPhone = @contactPhone WHERE GalleryID = @id;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", carGallery.GalleryID);
            cmd.Parameters.AddWithValue("name", carGallery.Name);
            cmd.Parameters.AddWithValue("location", carGallery.Location);
            cmd.Parameters.AddWithValue("contactEmail", carGallery.ContactEmail);
            cmd.Parameters.AddWithValue("contactPhone", carGallery.ContactPhone);

            cmd.ExecuteNonQuery();
        }

        public CarGallery Get(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();

            const string query = "SELECT * FROM CarGalleries WHERE GalleryID = @id;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return Mapper.MapCarGallery(reader);
            }
            return null;

        }

        public List<CarGallery> Get()
        {
            List<CarGallery> galleries = new List<CarGallery>();

            using SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();

            const string query = "SELECT * FROM CarGalleries;";
            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                CarGallery gallery = Mapper.MapCarGallery(reader);
                galleries.Add(gallery);
            }
            return galleries;
            
        }

    }
}
