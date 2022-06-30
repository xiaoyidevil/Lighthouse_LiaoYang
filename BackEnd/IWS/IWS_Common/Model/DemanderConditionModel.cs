using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWS_Common.Model
{
    /// <summary>
    /// 需求方条件模型
    /// </summary>
    public class DemanderConditionModel
    {
        public string Id { get; set; }

        /// <summary>
        /// 开始位置索引
        /// </summary>
        public int StartIndex { get; set; }

        /// <summary>
        /// 每页显示条数
        /// </summary>
        public int PageCnt { get; set; }

        /// <summary>
        /// 需求方ID
        /// </summary>
        public string DemanderId;

        /// <summary>
        /// 需求方企业名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 需求方企业地址
        /// </summary>
        public string CompanyAddress { get; set; }

        /// <summary>
        /// 邮政编号1
        /// </summary>
        public string PostCode1 { get; set; }

        /// <summary>
        /// 邮政编号2
        /// </summary>
        public string PostCode2 { get; set; }

        /// <summary>
        /// 企业网址
        /// </summary>
        public string Website { get; set; }

        /// <summary>
        /// 企业性质
        /// </summary>
        public string NatureEnterprise { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public string OprationKind { get; set; }
    }
}
