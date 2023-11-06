using CarSellerProject.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSellerProject.Models
{
    public class ConfigurationModel
    {
        public string DbHost { get; set; }
        public int DbPort { get; set; }
        public DbType DbType { get; set; }
        public string DbName { get; set; }
        public bool WindowsAuthentication { get; set; }
        public string Username { get; set; }
    }
}
