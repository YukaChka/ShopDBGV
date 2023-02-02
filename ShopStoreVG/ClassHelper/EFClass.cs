using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopStoreVG.DB;

namespace ShopStoreVG.ClassHelper
{
    internal class EFClass
    {
        public static ShopStoreVGEntities1 Context { get; } = new ShopStoreVGEntities1();
    }
}
