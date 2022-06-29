using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWS_Common.Model
{
    /// <summary>
    /// 车辆条件模型
    /// </summary>
    public class VehicleConditionModel
    {
        public string VehicleId { get; set; }

        /// <summary>
        /// 开始位置索引
        /// </summary>
        public int StartIndex { get; set; }

        /// <summary>
        /// 每页显示条数
        /// </summary>
        public int PageCnt { get; set; }

        /// <summary>
        /// 车牌号码
        /// </summary>
        public string VehicleNumber { get; set; }

        /// <summary>
        /// 所属公司
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 车辆型号
        /// </summary>
        public string BrandModel { get; set; }

        /// <summary>
        /// 车身颜色
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public string OprationKind { get; set; }
    }
}
