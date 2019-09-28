using HGD.Framework.Base;
using HGD.Framework.Orm.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGD.Framework.Orm.Experiment.Model
{
    public class ExperimentHistoryDetail: ModalBaseInt
    {
        /// <summary>
        /// 实验编号
        /// </summary>
        public int ExperimentId { get; set; }
        /// <summary>
        /// 题目
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 正确答案
        /// </summary>
        public string CorrectAnswer { get; set; }

        /// <summary>
        /// 结果：0：错误，1：正确
        /// </summary>
        public int Result { get; set; }

        /// <summary>
        /// 考生答案
        /// </summary>
        public string Answer { get; set; }
    }
}
