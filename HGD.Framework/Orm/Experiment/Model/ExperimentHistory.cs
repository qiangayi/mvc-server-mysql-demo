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
    public class ExperimentHistory : ModalBaseInt
    {
        /// <summary>
        /// 正确次数
        /// </summary>
        public int Correct { get; set; }

        /// <summary>
        /// 错误次数
        /// </summary>
        public int Error { get; set; }

        /// <summary>
        /// 总得分
        /// </summary>
        public double Score { get; set; }
    }
}
