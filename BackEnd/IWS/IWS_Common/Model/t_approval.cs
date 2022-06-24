using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWS_Common.Model
{
    /// <summary>
    /// 入场审批表数据模型
    /// </summary>
    public class t_approval
    {
        /// <summary>
        /// 审批序号
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 入场类型
        /// </summary>
        public string AdmisionType { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 入场人员
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string VehicleNumber { get; set; }

        /// <summary>
        /// 入场大门
        /// </summary>
        public string EntranceGate { get; set; }

        /// <summary>
        /// 接受单位
        /// </summary>
        public string Accption { get; set; }

        /// <summary>
        /// 审批状态
        /// </summary>
        public string ApprovalState { get; set; }

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
