using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HGD.Framework.Base;
using HGD.Framework.Orm.Attribute;

namespace HGD.Framework.Orm.SPMS.Model
{
    public class Sys_User
    {

        [Key]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string Id { set; get; }

        [DateTimeKind(DateTimeKind.Local)]
        public DateTime? CreatTime { set; get; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string Password { get; set; }
    }
}
