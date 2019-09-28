using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HGD.Framework.Base;

namespace HGD.Framework.Orm.Auth.Model
{
    [Table("AppSession")]
    public class AppSession : ModalBaseLong
    {
        [StringLength(2000)]
        [Column(TypeName = "nvarchar")]
        public string Value { set; get; }
    }
}
