using HGD.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGD.Framework.Orm.Forum.Model
{
    public class ForumReply: ModalBaseInt
    {
        /// <summary>
        /// 主题编号
        /// </summary>
        public int ForumThemeId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; }
        
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
    }
}
