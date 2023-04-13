using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopStoreVG.DB;

namespace ShopStoreVG.ClassHelper
{
    public class UserDataClass
    {
        public static User User { get; set; }

        public static Employee Employee { get; set; }

        public static Client Client { get; set; }
    }
}