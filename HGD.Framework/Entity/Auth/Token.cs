using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGD.Framework.Entity.Auth
{
    public class Token
    {
        public string UserID { set; get; }
        public DateTime ExpireTime { set; get; }
    }
}
