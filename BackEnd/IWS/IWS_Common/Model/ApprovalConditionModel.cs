using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWS_Common.Model
{
    /// <summary>
    /// 入场审批条件模型
    /// </summary>
    public class ApprovalConditionModel
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
        /// 操作类型
        /// </summary>
        public string OprationKind { get; set; }
    }
}
