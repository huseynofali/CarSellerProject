using CarSellerProject.Core.Domain.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSellerProject.Core.DataAccessLayer.SqlServer
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly string _connectionString;

        public SqlUnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ICarGalleryRepository CarGalleryRepository => new SqlCarGalleryRepository(_connectionString);

        public ICarRepository CarRepository => new SqlCarRepository(_connectionString);

        public IUserRepository UserRepository => new SqlUserRepository(_connectionString);

        public bool IsOnline()
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
