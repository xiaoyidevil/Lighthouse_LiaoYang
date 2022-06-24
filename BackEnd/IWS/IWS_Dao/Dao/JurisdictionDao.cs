using IWS_Common.Const;
using IWS_Common.Model;
using IWS_Dao.DaoIF;
using MySql.Data.MySqlClient;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWS_Dao.Dao
{
    /// <summary>
    /// 权限数据库操模型作类
    /// </summary>
    public class JurisdictionDao : AbstractDao<m_jurisdiction>, InterfaceDao<m_jurisdiction>
    {
        #region 属性

        #endregion

        #region 接口函数

        /// <summary>
        /// 查询数据总条数
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="dicCondition">条件集合</param>
        /// <returns></returns>
        public int SelectDataCnt(MySqlConnection conn, Dictionary<string, string> dicCondition)
        {
            // 返回对象
            int intReturnValue = 0;

            // 连接失效返回空
            if (conn.State != System.Data.ConnectionState.Open) return 0;

            try
            {
                // 执行命令读取数据
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = CreateSelectDataCountSql(dicCondition);
                    MySqlDataReader read = cmd.ExecuteReader();

                    while (read.Read()) intReturnValue = Convert.ToInt32(read[0]);
                }
                return intReturnValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="dicCondition">条件集合</param>
        /// <param name="lstData">数据集合</param>
        /// <returns></returns>
        public List<m_jurisdiction> SelectData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<m_jurisdiction> lstData = null)
        {
            // 返回集合
            List<m_jurisdiction> lstJurisdiction = new List<m_jurisdiction>();

            // 连接失效返回空
            if (conn.State != System.Data.ConnectionState.Open) return lstJurisdiction;

            try
            {
                // 执行命令读取数据
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = CreateSelectSql(dicCondition);
                    MySqlDataReader read = cmd.ExecuteReader();

                    while (read.Read())
                    {
                        lstJurisdiction.Add(new m_jurisdiction()
                        {
                            JurisdictionId = GetDBValueToInt(read["JurisdictionId"]),
                            JurisdictionLevel = GetDBValueToInt(read["JurisdictionLevel"]),
                            ParentID = GetDBValueToInt(read["ParentID"]),
                            JurisdictionName = GetDBValueToString(read["JurisdictionName"]),
                            JurisdictionPath = GetDBValueToString(read["JurisdictionPath"]),
                            IsDelete = GetDBValueToInt(read["IsDelete"]),
                            CreateUser = GetDBValueToString(read["CreateUser"]),
                            CreateTime = GetDBValueToDateTime(read["CreateTime"]),
                            UpdateUser = GetDBValueToString(read["UpdateUser"]),
                            UpdateTime = GetDBValueToDateTime(read["UpdateTime"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return lstJurisdiction;
        }

        /// <summary>
        /// 数据删除
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="dicCondition">条件集合</param>
        /// <param name="lstData">数据集合</param>
        /// <returns></returns>
        public int DeleteData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<m_jurisdiction> lstData = null)
        {
            // 返回对象
            int intReturnValue = 0;
            // 数据库事务对象
            MySqlTransaction tran = null;
            // 连接失效返回空
            if (conn.State == System.Data.ConnectionState.Open) return 0;

            try
            {
                tran = conn.BeginTransaction();
                // 执行命令读取数据
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = CreateDeleteSql(dicCondition);
                    intReturnValue = cmd.ExecuteNonQuery();
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return intReturnValue;
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="conn">数据库连接</param>
        /// <param name="dicCondition">条件集合</param>
        /// <param name="lstData">数据集合</param>
        /// <returns></returns>
        public int InsertData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<m_jurisdiction> lstData = null)
        {
            // 返回对象
            int intReturnValue = 0;
            // 数据库事务对象
            MySqlTransaction tran = null;
            // 数据库执行参数
            MySqlParameter[] paras = null;

            // 连接失效返回空
            if (conn.State == System.Data.ConnectionState.Open) return 0;

            try
            {
                tran = conn.BeginTransaction();
                // 执行命令读取数据
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = CreateInsertSql(dicCondition);

                    // 循环执行插入语句
                    foreach (m_jurisdiction jurisdiction in lstData)
                    {
                        paras = CreateInsertParameter();
                        paras[0].Value = jurisdiction.JurisdictionId;
                        paras[1].Value = jurisdiction.JurisdictionLevel;
                        paras[2].Value = jurisdiction.ParentID;
                        paras[3].Value = jurisdiction.JurisdictionName;
                        paras[4].Value = jurisdiction.JurisdictionPath;
                        paras[5].Value = jurisdiction.IsDelete;
                        paras[6].Value = jurisdiction.CreateUser;
                        paras[7].Value = jurisdiction.CreateTime;
                        paras[8].Value = jurisdiction.UpdateUser;
                        paras[9].Value = jurisdiction.UpdateTime;

                        intReturnValue = cmd.ExecuteNonQuery();                        
                    }
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return intReturnValue;
        }        

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="dicCondition">条件集合</param>
        /// <param name="lstData">数据集合</param>
        /// <returns></returns>
        public int UpdateData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<m_jurisdiction> lstData = null)
        {
            // 返回对象
            int intReturnValue = 0;
            // 数据库事务对象
            MySqlTransaction tran = null;
            // 数据库执行参数
            MySqlParameter[] paras = null;

            // 连接失效返回空
            if (conn.State == System.Data.ConnectionState.Open) return 0;

            try
            {
                tran = conn.BeginTransaction();
                // 执行命令读取数据
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = CreateUpdateSql(dicCondition);

                    // 循环执行插入语句
                    foreach (m_jurisdiction jurisdiction in lstData)
                    {
                        paras = CreateUpdateParameter();
                        paras[0].Value = jurisdiction.JurisdictionId;
                        paras[1].Value = jurisdiction.JurisdictionLevel;
                        paras[2].Value = jurisdiction.ParentID;
                        paras[3].Value = jurisdiction.JurisdictionName;
                        paras[4].Value = jurisdiction.JurisdictionPath;
                        paras[5].Value = jurisdiction.IsDelete;
                        paras[6].Value = jurisdiction.CreateUser;
                        paras[7].Value = jurisdiction.CreateTime;
                        paras[8].Value = jurisdiction.UpdateUser;
                        paras[9].Value = jurisdiction.UpdateTime;

                        intReturnValue = cmd.ExecuteNonQuery();
                    }
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return intReturnValue;
        }
        #endregion

        #region 抽象函数

        /// <summary>
        /// 创建查询Sql语句
        /// </summary>
        /// <param name="dicCondition">条件集合</param>
        /// <returns></returns>
        public override string CreateSelectDataCountSql(Dictionary<string, string> dicCondition)
        {
            StringBuilder sb = new StringBuilder();
            int counter = 0;

            sb.Append(" select count(*) from m_jurisdiction where 1=1 ");

            if (dicCondition != null)
            {
                foreach (string key in dicCondition.Keys)
                {
                    counter++;
                    if (key.Equals(AppConst.Dictionary_Condition + counter))
                        sb.Append(dicCondition[AppConst.Dictionary_Condition + counter]);
                }
            }
            return sb.ToString();
        }

        public override MySqlParameter[] CreateDeleteParameter()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 创建数据库插入语句
        /// </summary>
        /// <param name="dicCondition">条件集合</param>
        /// <returns></returns>
        public override string CreateDeleteSql(Dictionary<string, string> dicCondition)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" delete from m_jurisdiction ");
            if (dicCondition != null && dicCondition.ContainsKey(AppConst.Dictionary_ConditionCnt))
            {
                // foreach value sb.Append(Condition Value)
            }
            return sb.ToString();
        }

        /// <summary>
        /// 创建数据插入参数
        /// </summary>
        /// <param name="dicCondition">条件集合</param>
        /// <param name="lstData">数据集合</param>
        /// <returns></returns>
        public override MySqlParameter[] CreateInsertParameter()
        {
            MySqlParameter[] paras = new MySqlParameter[] 
            {
                new MySqlParameter("@JurisdictionId",MySqlDbType.Int32),
                new MySqlParameter("@JurisdictionLevel",MySqlDbType.Int32),
                new MySqlParameter("@ParentID",MySqlDbType.Int32),
                new MySqlParameter("@JurisdictionName",MySqlDbType.VarChar,40),
                new MySqlParameter("@JurisdictionPath",MySqlDbType.VarChar,500),                
                new MySqlParameter("@IsDelete",MySqlDbType.Int32,0),
                new MySqlParameter("@CreateUser",MySqlDbType.VarChar,10),
                new MySqlParameter("@CreateTime",MySqlDbType.DateTime),
                new MySqlParameter("@UpdateUser",MySqlDbType.VarChar,10),
                new MySqlParameter("@UpdateTime",MySqlDbType.DateTime)
            };
            return paras;
        }

        /// <summary>
        /// 创建查询Sql语句
        /// </summary>
        /// <param name="dicCondition">条件集合</param>
        /// <returns></returns>
        public override string CreateSelectSql(Dictionary<string, string> dicCondition)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" select * from m_jurisdiction ");

            if (dicCondition != null && dicCondition.ContainsKey(AppConst.Dictionary_ConditionCnt))
            {
                // foreach value sb.Append(Condition Value)
            }
            return sb.ToString();
        }
        
        /// <summary>
        /// 创建数据库插入语句
        /// </summary>
        /// <param name="dicCondition">条件集合</param>
        /// <returns></returns>
        public override string CreateInsertSql(Dictionary<string, string> dicCondition)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" insert into m_jurisdiction ");
            sb.Append(" ( ");
            sb.Append("         JurisdictionId, ");
            sb.Append("         JurisdictionLevel, ");
            sb.Append("         ParentID, ");
            sb.Append("         JurisdictionName, ");
            sb.Append("         JurisdictionPath, ");
            sb.Append("         IsDelete, ");
            sb.Append("         CreateUser, ");
            sb.Append("         CreateTime, ");
            sb.Append("         UpdateUser, ");
            sb.Append("         UpdateTime ");
            sb.Append(" ) ");
            sb.Append(" values ");
            sb.Append(" ( ");
            sb.Append("         @JurisdictionId, ");
            sb.Append("         @JurisdictionLevel, ");
            sb.Append("         @ParentID, ");
            sb.Append("         @JurisdictionName, ");
            sb.Append("         @JurisdictionPath, ");
            sb.Append("         @IsDelete, ");
            sb.Append("         @CreateUser, ");
            sb.Append("         @CreateTime, ");
            sb.Append("         @UpdateUser, ");
            sb.Append("         @UpdateTime ");
            sb.Append(" ) ");

            return sb.ToString();
        }

        /// <summary>
        /// 创建查询参数
        /// </summary>
        /// <param name="dicCondition">条件集合</param>
        /// <param name="lstData">数据集合</param>
        /// <returns></returns>
        public override MySqlParameter[] CreateSelectParameter(Dictionary<string, string> dicCondition)
        {
            throw new NotImplementedException();
        }        

        /// <summary>
        /// 创建数据库更新参数
        /// </summary>
        /// <returns></returns>
        public override MySqlParameter[] CreateUpdateParameter()
        {
            MySqlParameter[] paras = new MySqlParameter[]
            {
                new MySqlParameter("@JurisdictionId",MySqlDbType.Int32),
                new MySqlParameter("@JurisdictionLevel",MySqlDbType.Int32),
                new MySqlParameter("@ParentID",MySqlDbType.Int32),
                new MySqlParameter("@JurisdictionName",MySqlDbType.VarChar,40),
                new MySqlParameter("@JurisdictionPath",MySqlDbType.VarChar,500),
                new MySqlParameter("@IsDelete",MySqlDbType.Int32,0),
                new MySqlParameter("@CreateUser",MySqlDbType.VarChar,10),
                new MySqlParameter("@CreateTime",MySqlDbType.DateTime),
                new MySqlParameter("@UpdateUser",MySqlDbType.VarChar,10),
                new MySqlParameter("@UpdateTime",MySqlDbType.DateTime)
            };
            return paras;
        }

        /// <summary>
        /// 创建数据更新语句
        /// </summary>
        /// <param name="dicCondition">条件集合</param>
        /// <returns></returns>
        public override string CreateUpdateSql(Dictionary<string, string> dicCondition)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" update m_jurisdiction ");
            sb.Append("    set JurisdictionId = @JurisdictionId, ");
            sb.Append("        JurisdictionLevel = @JurisdictionLevel, ");
            sb.Append("        JurisdictionName = @JurisdictionName, ");
            sb.Append("        JurisdictionPath = @JurisdictionPath, ");
            sb.Append("        IsDelete = @IsDelete, ");
            sb.Append("        CreateUser = @CreateUser, ");
            sb.Append("        CreateTime = @CreateTime, ");
            sb.Append("        UpdateUser = @UpdateUser, ");
            sb.Append("        UpdateTime = @UpdateTime ");

            if (dicCondition != null && dicCondition.ContainsKey(AppConst.Dictionary_ConditionCnt))
            {
                // foreach value sb.Append(Condition Value)
            }
            return sb.ToString();
        }
        #endregion
    }
}
