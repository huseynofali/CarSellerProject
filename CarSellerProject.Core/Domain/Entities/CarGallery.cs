using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarSellerProject.Core.Domain.Entities
{
    public class CarGallery
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Location{ get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public List<Car> Cars { get; set; }
    }
}
