using CarSellerProject.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSellerProject.Core.DataAccessLayer
{
    public class EmptyUnitOfWork : IUnitOfWork
    {

        public IUserRepository UserRepository => throw new NotImplementedException();

        public ICarGalleryRepository CarGalleryRepository => throw new NotImplementedException();

        public ICarRepository CarRepository => throw new NotImplementedException();

        public bool IsOnline()
        {
            return false;
        }
    }
}
