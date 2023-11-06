using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSellerProject.Misc.Abstract
{
    public interface IExporter<T>
    {
        void Export(IEnumerable<T> objects);
    }
}
