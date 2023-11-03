using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSellerProject.Core.Domain.Repositories
{
    public interface IUnitOfWork
    {
        public ICarGalleryRepository CarGalleryRepository { get; }
        public ICarRepository CarRepository { get; }
        public IUserRepository UserRepository { get; }

        bool IsOnline();
    }
}
