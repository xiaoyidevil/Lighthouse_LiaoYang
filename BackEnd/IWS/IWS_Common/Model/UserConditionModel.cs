using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWS_Common.Model
{
    /// <summary>
    /// 用户条件模型
    /// </summary>
    public class UserConditionModel
    {
        /// <summary>
        /// 开始位置索引
        /// </summary>
        public int StartIndex { get; set; }

        /// <summary>
        /// 每页显示条数
        /// </summary>
        public int PageCnt { get; set; }

        public string Id { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        public string IdCard { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public string OprationKind { get; set; }
    }
}
