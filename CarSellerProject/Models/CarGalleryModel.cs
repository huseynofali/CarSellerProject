using CarSellerProject.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSellerProject.Models
{
    public class CarGalleryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        //public List<Car> Cars { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
