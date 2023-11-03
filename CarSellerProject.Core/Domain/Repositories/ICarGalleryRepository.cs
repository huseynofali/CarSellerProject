using CarSellerProject.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSellerProject.Core.Domain.Repositories
{
    public interface ICarGalleryRepository
    {
        void Add(CarGallery carGallery);
        void Update(CarGallery carGallery);
        void Delete(int id);
        CarGallery Get(int id); 
        List<CarGallery> Get();  
    }
}
