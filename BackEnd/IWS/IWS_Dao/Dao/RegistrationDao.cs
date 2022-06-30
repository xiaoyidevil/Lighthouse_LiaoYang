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
    /// 入场登记数据库操模型作类
    /// </summary>
    public class RegistrationDao : AbstractDao<t_registration>, InterfaceDao<t_registration>
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
        public List<t_registration> SelectData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<t_registration> lstData = null)
        {
            // 返回集合
            List<t_registration> lstRegistration = new List<t_registration>();

            // 连接失效返回空
            if (conn.State != System.Data.ConnectionState.Open) return lstRegistration;

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
                        lstRegistration.Add(new t_registration()
                        {
                            Id = GetDBValueToInt(read["Id"]),
                            CompanyId = GetDBValueToString(read["CompanyId"]),
                            CompanyName = GetDBValueToString(read["CompanyName"]),
                            UserId = GetDBValueToString(read["UserId"]),
                            UserName = GetDBValueToString(read["UserName"]),
                            VehicleNumber = GetDBValueToString(read["VehicleNumber"]),
                            EntranceGate = GetDBValueToString(read["EntranceGate"]),
                            EntranceDate = GetDBValueToString(read["EntranceDate"]),
                            EntranceTime = GetDBValueToString(read["EntranceTime"]),
                            Overseer = GetDBValueToString(read["Overseer"]),
                            Reason = GetDBValueToString(read["Reason"]),
                            IsDelete = GetDBValueToInt(read["IsDelete"]),
                            CreateUser = GetDBValueToString(read["CreateUser"]),
                            CreateTime = GetDBValueToDateTime(read["CreateTime"]),
                            UpdateUser = GetDBValueToString(read["UpdateUser"]),
                            UpdateTime = GetDBValueToDateTime(read["UpdateTime"]),
                            Remark = GetDBValueToString(read["Remark"])
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
            return lstRegistration;
        }

        /// <summary>
        /// 数据删除
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="dicCondition">条件集合</param>
        /// <param name="lstData">数据集合</param>
        /// <returns></returns>
        public int DeleteData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<t_registration> lstData = null)
        {
            // 返回对象
            int intReturnValue = 0;
            // 数据库事务对象
            MySqlTransaction tran = null;
            // 连接失效返回空
            if (conn.State != System.Data.ConnectionState.Open) return 0;

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
        public int InsertData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<t_registration> lstData = null)
        {
            // 返回对象
            int intReturnValue = 0;
            // 数据库事务对象
            MySqlTransaction tran = null;
            // 数据库执行参数
            MySqlParameter[] paras = null;

            // 连接失效返回空
            if (conn.State != System.Data.ConnectionState.Open) return 0;

            try
            {
                tran = conn.BeginTransaction();
                // 执行命令读取数据
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = CreateInsertSql(dicCondition);

                    // 循环执行插入语句
                    foreach (t_registration registration in lstData)
                    {
                        paras = CreateInsertParameter();
                        paras[0].Value = registration.Id;
                        paras[1].Value = registration.CompanyId;
                        paras[2].Value = registration.CompanyName;
                        paras[3].Value = registration.UserId;
                        paras[4].Value = registration.UserName;
                        paras[5].Value = registration.VehicleNumber;
                        paras[6].Value = registration.EntranceGate;
                        paras[7].Value = registration.EntranceDate;
                        paras[8].Value = registration.EntranceTime;
                        paras[9].Value = registration.Overseer;
                        paras[10].Value = registration.Reason;
                        paras[11].Value = GetDefualtDeleteFlg(registration.IsDelete);
                        paras[12].Value = GetDefualtUser(registration.CreateUser);
                        paras[13].Value = GetDefualtDatetime(registration.CreateTime);
                        paras[14].Value = GetDefualtUser(registration.UpdateUser);
                        paras[15].Value = GetDefualtDatetime(registration.UpdateTime);
                        paras[16].Value = registration.Remark;
                        cmd.Parameters.AddRange(paras);

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
        public int UpdateData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<t_registration> lstData = null)
        {
            // 返回对象
            int intReturnValue = 0;
            // 数据库事务对象
            MySqlTransaction tran = null;
            // 数据库执行参数
            MySqlParameter[] paras = null;

            // 连接失效返回空
            if (conn.State != System.Data.ConnectionState.Open) return 0;

            try
            {
                tran = conn.BeginTransaction();
                // 执行命令读取数据
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = CreateUpdateSql(dicCondition);

                    // 循环执行插入语句
                    foreach (t_registration registration in lstData)
                    {
                        paras = CreateInsertParameter();
                        paras[0].Value = registration.Id;
                        paras[1].Value = registration.CompanyId;
                        paras[2].Value = registration.CompanyName;
                        paras[3].Value = registration.UserId;
                        paras[4].Value = registration.UserName;
                        paras[5].Value = registration.VehicleNumber;
                        paras[6].Value = registration.EntranceGate;
                        paras[7].Value = registration.EntranceDate;
                        paras[8].Value = registration.EntranceTime;
                        paras[9].Value = registration.Overseer;
                        paras[10].Value = registration.Reason;
                        paras[11].Value = GetDefualtDeleteFlg(registration.IsDelete);
                        paras[12].Value = GetDefualtUser(registration.CreateUser);
                        paras[13].Value = GetDefualtDatetime(registration.CreateTime);
                        paras[14].Value = GetDefualtUser(registration.UpdateUser);
                        paras[15].Value = GetDefualtDatetime(registration.UpdateTime);
                        paras[16].Value = registration.Remark;
                        cmd.Parameters.AddRange(paras);

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

            sb.Append(" select count(*) from t_registration where 1=1 ");

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
            int counter = 0;

            sb.Append(" update t_registration set IsDelete = 1 where IsDelete <> 1 ");
            if (dicCondition != null)
            {
                foreach (string key in dicCondition.Keys)
                {
                    counter++;
                    if (key.Equals(AppConst.Dictionary_Condition + counter)) sb.Append(dicCondition[AppConst.Dictionary_Condition + counter]);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 创建数据插入参数
        /// </summary>
        /// <returns></returns>
        public override MySqlParameter[] CreateInsertParameter()
        {
            MySqlParameter[] paras = new MySqlParameter[] 
            {
                new MySqlParameter("@Id",MySqlDbType.Int32),
                new MySqlParameter("@CompanyId",MySqlDbType.VarChar,10),
                new MySqlParameter("@CompanyName",MySqlDbType.VarChar,100),
                new MySqlParameter("@UserId",MySqlDbType.VarChar,10),
                new MySqlParameter("@UserName",MySqlDbType.VarChar,40),
                new MySqlParameter("@VehicleNumber",MySqlDbType.VarChar,10),
                new MySqlParameter("@EntranceGate",MySqlDbType.VarChar,50),
                new MySqlParameter("@EntranceDate",MySqlDbType.VarChar,30),
                new MySqlParameter("@EntranceTime",MySqlDbType.VarChar,30),
                new MySqlParameter("@Overseer",MySqlDbType.VarChar,100),
                new MySqlParameter("@Reason",MySqlDbType.VarChar,500),
                new MySqlParameter("@IsDelete",MySqlDbType.Int32,0),
                new MySqlParameter("@CreateUser",MySqlDbType.VarChar,10),
                new MySqlParameter("@CreateTime",MySqlDbType.DateTime),
                new MySqlParameter("@UpdateUser",MySqlDbType.VarChar,10),
                new MySqlParameter("@UpdateTime",MySqlDbType.DateTime),
                new MySqlParameter("@Remark",MySqlDbType.VarChar,500)
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
            int counter = 0;

            sb.Append(" select * from t_registration where 1=1 ");

            if (dicCondition != null)
            {
                foreach (string key in dicCondition.Keys)
                {
                    counter++;
                    if (key.Equals(AppConst.Dictionary_Condition + counter)) sb.Append(dicCondition[AppConst.Dictionary_Condition + counter]);
                    if (key.Equals(AppConst.Dictionary_Condition_Limit)) sb.Append(dicCondition[AppConst.Dictionary_Condition_Limit]);
                }
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

            sb.Append(" insert into t_registration ");
            sb.Append(" ( ");
            sb.Append("         Id, ");
            sb.Append("         CompanyId, ");
            sb.Append("         CompanyName, ");
            sb.Append("         UserId, ");
            sb.Append("         UserName, ");
            sb.Append("         VehicleNumber, ");
            sb.Append("         EntranceGate, ");
            sb.Append("         EntranceDate, ");
            sb.Append("         EntranceTime, ");
            sb.Append("         Overseer, ");
            sb.Append("         Reason, ");
            sb.Append("         IsDelete, ");
            sb.Append("         CreateUser, ");
            sb.Append("         CreateTime, ");
            sb.Append("         UpdateUser, ");
            sb.Append("         UpdateTime, ");
            sb.Append("         Remark ");
            sb.Append(" ) ");
            sb.Append(" values ");
            sb.Append(" ( ");
            sb.Append("         @Id, ");
            sb.Append("         @CompanyId, ");
            sb.Append("         @CompanyName, ");
            sb.Append("         @UserId, ");
            sb.Append("         @UserName, ");
            sb.Append("         @VehicleNumber, ");
            sb.Append("         @EntranceGate, ");
            sb.Append("         @EntranceDate, ");
            sb.Append("         @EntranceTime, ");
            sb.Append("         @Overseer, ");
            sb.Append("         @Reason, ");
            sb.Append("         @IsDelete, ");
            sb.Append("         @CreateUser, ");
            sb.Append("         @CreateTime, ");
            sb.Append("         @UpdateUser, ");
            sb.Append("         @UpdateTime, ");
            sb.Append("         @Remark ");
            sb.Append(" ) ");

            return sb.ToString();
        }

        /// <summary>
        /// 创建查询参数
        /// </summary>
        /// <param name="dicCondition">条件集合</param>
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
                new MySqlParameter("@Id",MySqlDbType.Int32),
                new MySqlParameter("@CompanyId",MySqlDbType.VarChar,10),
                new MySqlParameter("@CompanyName",MySqlDbType.VarChar,100),
                new MySqlParameter("@UserId",MySqlDbType.VarChar,10),
                new MySqlParameter("@UserName",MySqlDbType.VarChar,40),
                new MySqlParameter("@VehicleNumber",MySqlDbType.VarChar,10),
                new MySqlParameter("@EntranceGate",MySqlDbType.VarChar,50),
                new MySqlParameter("@EntranceDate",MySqlDbType.VarChar,30),
                new MySqlParameter("@EntranceTime",MySqlDbType.VarChar,30),
                new MySqlParameter("@Overseer",MySqlDbType.VarChar,100),
                new MySqlParameter("@Reason",MySqlDbType.VarChar,500),
                new MySqlParameter("@IsDelete",MySqlDbType.Int32,0),
                new MySqlParameter("@CreateUser",MySqlDbType.VarChar,10),
                new MySqlParameter("@CreateTime",MySqlDbType.DateTime),
                new MySqlParameter("@UpdateUser",MySqlDbType.VarChar,10),
                new MySqlParameter("@UpdateTime",MySqlDbType.DateTime),
                new MySqlParameter("@Remark",MySqlDbType.VarChar,500)
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

            sb.Append(" update t_registration ");
            sb.Append("    set CompanyId = @CompanyId, ");
            sb.Append("        CompanyName = @CompanyName, ");
            sb.Append("        UserId = @UserId, ");
            sb.Append("        UserName = @UserName, ");
            sb.Append("        VehicleNumber = @VehicleNumber, ");
            sb.Append("        EntranceGate = @EntranceGate, ");
            sb.Append("        EntranceDate = @EntranceDate, ");
            sb.Append("        EntranceTime = @EntranceTime, ");
            sb.Append("        Overseer = @Overseer, ");
            sb.Append("        Reason = @Reason, ");
            sb.Append("        IsDelete = @IsDelete, ");
            sb.Append("        CreateUser = @CreateUser, ");
            sb.Append("        CreateTime = @CreateTime, ");
            sb.Append("        UpdateUser = @UpdateUser, ");
            sb.Append("        UpdateTime = @UpdateTime, ");
            sb.Append("        Remark = @Remark ");
            sb.Append(" where Id = @Id and IsDelete <> 1 ");

            return sb.ToString();
        }
        #endregion
    }
}
