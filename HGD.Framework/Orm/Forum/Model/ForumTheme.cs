using HGD.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGD.Framework.Orm.Forum.Model
{
    public class ForumTheme: ModalBaseInt
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 主题
        /// </summary>
        public string Theme { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 回复数
        /// </summary>
        public string Replics { get; set; }


        /// <summary>
        /// 图片数
        /// </summary>
        public string Pictures { get; set; }
    }
}
