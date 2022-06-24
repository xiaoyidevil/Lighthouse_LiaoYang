using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWS_Dao.DaoIF
{
    /// <summary>
    /// 数据层抽象类
    /// </summary>
    public abstract class AbstractDao<T>
    {
        /// <summary>
        /// 创建查询Sql
        /// </summary>
        /// <param name="dicCondition">条件集合</param>
        /// <returns></returns>
        public abstract string CreateSelectDataCountSql(Dictionary<string, string> dicCondition);

        /// <summary>
        /// 创建查询Sql
        /// </summary>
        /// <param name="dicCondition">条件集合</param>
        /// <returns></returns>
        public abstract string CreateSelectSql(Dictionary<string, string> dicCondition);

        /// <summary>
        /// 创建数据库插入Sql
        /// </summary>
        /// <param name="dicCondition">条件集合</param>
        /// <returns></returns>
        public abstract string CreateInsertSql(Dictionary<string, string> dicCondition);

        /// <summary>
        /// 创建数据库更新Sql
        /// </summary>
        /// <param name="dicCondition">条件集合</param>
        /// <returns></returns>
        public abstract string CreateUpdateSql(Dictionary<string, string> dicCondition);

        /// <summary>
        /// 创建数据库删除Sql
        /// </summary>
        /// <param name="dicCondition">条件集合</param>
        /// <returns></returns>
        public abstract string CreateDeleteSql(Dictionary<string, string> dicCondition);

        /// <summary>
        /// 创建数据库查询参数
        /// </summary>
        /// <param name="dicCondition">条件集合</param>
        /// <returns></returns>
        public abstract MySqlParameter[] CreateSelectParameter(Dictionary<string, string> dicCondition);

        /// <summary>
        /// 创建数据库插入参数
        /// </summary>
        /// <param name="dicCondition">条件集合</param>
        /// <returns></returns>
        public abstract MySqlParameter[] CreateInsertParameter();

        /// <summary>
        /// 创建数据库更新参数
        /// </summary>
        /// <param name="dicCondition">条件集合</param>
        /// <returns></returns>
        public abstract MySqlParameter[] CreateUpdateParameter();

        /// <summary>
        /// 创建数据库删除参数
        /// </summary>
        /// <param name="dicCondition">条件集合</param>
        /// <returns></returns>
        public abstract MySqlParameter[] CreateDeleteParameter();

        /// <summary>
        /// 拆箱字符串转换
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string GetDBValueToString(object obj)
        {
            if (obj != null) return obj.ToString();
            else return null;
        }

        /// <summary>
        /// 拆箱数值型转换
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int? GetDBValueToInt(object obj)
        {
            if (obj != null) return Convert.ToInt32(obj.ToString());
            else return null;
        }

        /// <summary>
        /// 拆箱浮点型转换
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public double? GetDBValueToDouble(object obj)
        {
            if (obj != null) return Convert.ToDouble(obj.ToString());
            else return null;
        }

        /// <summary>
        /// 拆箱日期型转换
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public DateTime? GetDBValueToDateTime(object obj)
        {
            if (obj != null) return Convert.ToDateTime(obj.ToString());
            else return null;
        }
    }
}
