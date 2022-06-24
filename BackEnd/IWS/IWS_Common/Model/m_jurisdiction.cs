using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWS_Common.Model
{
    /// <summary>
    /// 权限数据模型
    /// </summary>
    public class m_jurisdiction
    {
        /// <summary>
        /// 权限ID
        /// </summary>
        public int? JurisdictionId { get; set; }

        /// <summary>
        /// 权限层级
        /// </summary>
        public int? JurisdictionLevel { get; set; }

        /// <summary>
        /// 父级权限ID
        /// </summary>
        public int? ParentID { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string JurisdictionName { get; set; }

        /// <summary>
        /// 权限路径
        /// </summary>
        public string JurisdictionPath { get; set; }        

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
    }
}
