using HGD.Framework.Orm.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGD.Framework.Base
{
    public class ModalBaseInt
    {
        /// <summary>
        /// int主键,自增
        /// </summary>
        [Key]
        public int Id { get; set; }

        [DateTimeKind(DateTimeKind.Local)]
        public DateTime? CreatTime { set; get; }
    }
}
