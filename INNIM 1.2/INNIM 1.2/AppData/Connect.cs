using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INNIM_1._2.AppData
{
    internal class Connect
    {
        public static DBEntities1 c;
        public static DBEntities1 context
        {
            get 
            {
                if (c == null)
                    c = new DBEntities1();
                return c;
            }
        }
    }
}
