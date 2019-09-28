using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HGD.Framework.Orm.Attribute;
using HGD.Framework.Util;

namespace HGD.Framework.Base
{
    public class ModalBaseLong
    {
        public ModalBaseLong()
        {
            this.Id = LeafSnowflake.getID();
            this.CreatTime = DateTime.Now;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { set; get; }

        public string IdStr { get { return Id.ToString(); } }

        [DateTimeKind(DateTimeKind.Local)]
        public DateTime? CreatTime { set; get; }
    }
}
