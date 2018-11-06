using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitesParser.BL.Interfaces
{
    public interface IDataService
    {
        bool SaveShops(List<string> shops);
    }
}
