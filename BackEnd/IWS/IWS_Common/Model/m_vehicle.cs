using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWS_Common.Model
{
    /// <summary>
    /// 车辆信息表数据模型
    /// </summary>
    public class m_vehicle
    {
        /// <summary>
        /// 车辆ID，自增
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 车牌号码
        /// </summary>
        public string VehicleNumber { get; set; }

        /// <summary>
        /// 经营企业名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 品牌型号
        /// </summary>
        public string BrandModel { get; set; }

        /// <summary>
        /// 车身颜色
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// 车身重量（公斤）
        /// </summary>
        public double? Weight { get; set; }

        /// <summary>
        /// 满载重量（公斤）
        /// </summary>
        public double? FullLoadWeight { get; set; }

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
