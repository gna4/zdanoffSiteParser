using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitesParser.BL.Services
{
    class ShopFoundEventArgs
    {
        public ShopFoundEventArgs(int count, string shop)
        {
            Count = count;
            Shop = shop;
        }

        public int Count { get; private set; }
        public string Shop { get; private set; }
    }
}
