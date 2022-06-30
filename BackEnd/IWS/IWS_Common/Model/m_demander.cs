using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWS_Common.Model
{
    /// <summary>
    /// 需求方数据模型
    /// </summary>
    public class m_demander
    {
        public int? Id { get; set; }

        /// <summary>
        /// 需求方编号
        /// </summary>
        public string DemanderId { get; set; }

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
        /// 联系电话
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public int? IsDelete { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新者
        /// </summary>
        public string UpdateUser { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
