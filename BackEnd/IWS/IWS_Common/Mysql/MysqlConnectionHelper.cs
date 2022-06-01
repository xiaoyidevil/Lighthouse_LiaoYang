using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IWS_Common.Const;
using MySql.Data.MySqlClient;
using static IWS_Common.Const.AppConst;

namespace IWS_Common.Mysql
{
    /// <summary>
    /// 数据库连接类
    /// </summary>
    public class MysqlConnectionHelper
    {
        #region 属性

        // Mysql连接套接字构造对象
        private MySqlConnectionStringBuilder _connectionString;
        // Mysql数据库连接对象
        private MySqlConnection _conn;

        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public MysqlConnectionHelper(string platForm)
        {
            _connectionString = new MySqlConnectionStringBuilder();
            _connectionString.UserID = "root";
            _connectionString.Password = "root";
            _connectionString.Server = "127.0.0.1";
            _connectionString.Database = "iws_db";
            switch (platForm)
            {
                case AppConst.Platform_Application:
                    _connectionString.MaximumPoolSize = 100;
                    _connectionString.MinimumPoolSize = 100;
                    break;
                case AppConst.Platform_Webapi:
                    _connectionString.MaximumPoolSize = 1;
                    _connectionString.MinimumPoolSize = 1;
                    break;
            }            
        }
        #endregion

        #region 函数

        /// <summary>
        /// 第一次创建数据库连接池
        /// </summary>
        public void FirstCreateMysqlConnection()
        {            
            _conn = new MySqlConnection(_connectionString.ConnectionString);
            _conn.Open();
            _conn.Close();
        }

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns></returns>
        public MySqlConnection GetMysqlConnection()
        {
            _conn.Open();
            return _conn;
        }
        #endregion 
    }
}
