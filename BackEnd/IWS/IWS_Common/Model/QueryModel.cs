using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWS_Common.Model
{
    /// <summary>
    /// 查询用数据模型
    /// </summary>
    public class QueryModel
    {
        /// <summary>
        /// 业务数据
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPageCnt { get; set; }

        /// <summary>
        /// 查询后数据总条数
        /// </summary>
        public int TotalDataCount { get; set; }

        /// <summary>
        /// 执行状态
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 执行信息
        /// </summary>
        public string Msg { get; set; }
    }
}
