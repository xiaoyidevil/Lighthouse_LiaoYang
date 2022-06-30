using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWS_Common.Model
{
    /// <summary>
    /// 物料表数据模型
    /// </summary>
    public class m_material
    {
        public int? Id { get; set; }

        /// <summary>
        /// 物料编号
        /// </summary>
        public string MaterialId { get; set; }

        /// <summary>
        /// 物料名称
        /// </summary>
        public string MaterialName { get; set; }

        /// <summary>
        /// 物料英文名称
        /// </summary>
        public string MaterialEnglishName { get; set; }

        /// <summary>
        /// 规格型号
        /// </summary>
        public string SpecificationsModel { get; set; }

        /// <summary>
        /// 材质
        /// </summary>
        public string Material { get; set; }

        /// <summary>
        /// 物料类别
        /// </summary>
        public string MaterialKind { get; set; }

        /// <summary>
        /// 计量单位
        /// </summary>
        public string Unit { get; set; }        

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
