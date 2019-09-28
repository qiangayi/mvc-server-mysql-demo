using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HGD.Framework.Base;

namespace HGD.Framework.Orm.Auth
{
    [Table("AppInfo")]
    public class AppInfo : ModalBaseLong
    {
        [StringLength(100)]
        [Column(TypeName = "varchar")]
        public string Secret { set; get; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar")]
        public string Name { set; get; }
    }
}
