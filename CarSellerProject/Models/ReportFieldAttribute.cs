using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSellerProject.Models
{
    public class ReportFieldAttribute : Attribute
    {
        public string DisplayName { get; set; }
        public int Order { get; set; }
    }
}
