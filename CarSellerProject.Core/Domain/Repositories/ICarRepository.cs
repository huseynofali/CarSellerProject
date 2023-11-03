using CarSellerProject.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSellerProject.Core.Domain.Repositories
{
    public interface ICarRepository
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(int id);
        Car Get(int id);
        List<Car> GetAll();

    }
}
