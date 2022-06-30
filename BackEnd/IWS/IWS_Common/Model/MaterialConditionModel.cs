using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWS_Common.Model
{
    /// <summary>
    /// 物料条件模型
    /// </summary>
    public class MaterialConditionModel
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
        /// 物料ID
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
        /// 操作类型
        /// </summary>
        public string OprationKind { get; set; }
    }
}
