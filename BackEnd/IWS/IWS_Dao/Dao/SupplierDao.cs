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
    /// 需求方数据库操模型作类
    /// </summary>
    public class SupplierDao : AbstractDao<m_supplier>, InterfaceDao<m_supplier>
    {
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
        /// 数据删除
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="dicCondition">条件集合</param>
        /// <param name="lstData">数据集合</param>
        /// <returns></returns>
        public int DeleteData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<m_supplier> lstData = null)
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
        public int InsertData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<m_supplier> lstData = null)
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
                    foreach (m_supplier supplier in lstData)
                    {
                        paras = CreateInsertParameter();
                        paras[0].Value = supplier.SupplierId;
                        paras[1].Value = supplier.CompanyName;
                        paras[2].Value = supplier.CompanyAddress;
                        paras[3].Value = supplier.PostCode1;
                        paras[4].Value = supplier.PostCode2;
                        paras[5].Value = supplier.Website;
                        paras[6].Value = supplier.NatureEnterprise;
                        paras[7].Value = supplier.Tel;
                        paras[8].Value = supplier.Fax;
                        paras[9].Value = supplier.IsDelete;
                        paras[10].Value = supplier.CreateUser;
                        paras[11].Value = supplier.CreateTime;
                        paras[12].Value = supplier.UpdateUser;
                        paras[13].Value = supplier.UpdateTime;
                        paras[14].Value = supplier.Remark;

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
        /// 数据查询
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="dicCondition">条件集合</param>
        /// <param name="lstData">数据集合</param>
        /// <returns></returns>
        public List<m_supplier> SelectData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<m_supplier> lstData = null)
        {
            // 返回集合
            List<m_supplier> lstSupplier = new List<m_supplier>();

            // 连接失效返回空
            if (conn.State != System.Data.ConnectionState.Open) return lstSupplier;

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
                        lstSupplier.Add(new m_supplier()
                        {
                            SupplierId = GetDBValueToString(read["SupplierId"]),
                            CompanyName = GetDBValueToString(read["CompanyName"]),
                            CompanyAddress = GetDBValueToString(read["CompanyAddress"]),
                            PostCode1 = GetDBValueToString(read["PostCode1"]),
                            PostCode2 = GetDBValueToString(read["PostCode2"]),
                            Website = GetDBValueToString(read["Website"]),
                            NatureEnterprise = GetDBValueToString(read["NatureEnterprise"]),
                            Tel = GetDBValueToString(read["Tel"]),
                            Fax = GetDBValueToString(read["Fax"]),
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
            return lstSupplier;
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="dicCondition">条件集合</param>
        /// <param name="lstData">数据集合</param>
        /// <returns></returns>
        public int UpdateData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<m_supplier> lstData = null)
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
                    foreach (m_supplier supplier in lstData)
                    {
                        paras = CreateUpdateParameter();
                        paras[0].Value = supplier.SupplierId;
                        paras[1].Value = supplier.CompanyName;
                        paras[2].Value = supplier.CompanyAddress;
                        paras[3].Value = supplier.PostCode1;
                        paras[4].Value = supplier.PostCode2;
                        paras[5].Value = supplier.Website;
                        paras[6].Value = supplier.NatureEnterprise;
                        paras[7].Value = supplier.Tel;
                        paras[8].Value = supplier.Fax;
                        paras[9].Value = supplier.IsDelete;
                        paras[10].Value = supplier.CreateUser;
                        paras[11].Value = supplier.CreateTime;
                        paras[12].Value = supplier.UpdateUser;
                        paras[13].Value = supplier.UpdateTime;
                        paras[14].Value = supplier.Remark;

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

            sb.Append(" select count(*) from m_supplier where 1=1 ");

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

            sb.Append(" delete from m_supplier ");
            //if (dicCondition != null && dicCondition.ContainsKey(AppConst.Dictionary_ConditionCnt))
            //{
            //    // foreach value sb.Append(Condition Value)
            //}
            return sb.ToString();
        }

        /// <summary>
        /// 创建数据库更新参数
        /// </summary>
        /// <returns></returns>
        public override MySqlParameter[] CreateInsertParameter()
        {
            MySqlParameter[] paras = new MySqlParameter[]
            {
                new MySqlParameter("@JurisdictionId",MySqlDbType.VarChar,10),
                new MySqlParameter("@CompanyName",MySqlDbType.VarChar,100),
                new MySqlParameter("@CompanyAddress",MySqlDbType.VarChar,250),
                new MySqlParameter("@PostCode1",MySqlDbType.VarChar,10),
                new MySqlParameter("@PostCode2",MySqlDbType.VarChar,10),
                new MySqlParameter("@Website",MySqlDbType.VarChar,50),
                new MySqlParameter("@NatureEnterprise",MySqlDbType.VarChar,255),
                new MySqlParameter("@Tel",MySqlDbType.VarChar,12),
                new MySqlParameter("@Fax",MySqlDbType.VarChar,12),
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
        /// 创建数据库插入语句
        /// </summary>
        /// <param name="dicCondition">条件集合</param>
        /// <returns></returns>
        public override string CreateInsertSql(Dictionary<string, string> dicCondition)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" insert into m_supplier ");
            sb.Append(" ( ");
            sb.Append("         JurisdictionId, ");
            sb.Append("         CompanyName, ");
            sb.Append("         CompanyAddress, ");
            sb.Append("         PostCode1, ");
            sb.Append("         PostCode2, ");
            sb.Append("         Website, ");
            sb.Append("         NatureEnterprise, ");
            sb.Append("         Tel, ");
            sb.Append("         Fax, ");
            sb.Append("         IsDelete, ");
            sb.Append("         CreateUser, ");
            sb.Append("         CreateTime, ");
            sb.Append("         UpdateUser, ");
            sb.Append("         UpdateTime, ");
            sb.Append("         Remark ");
            sb.Append(" ) ");
            sb.Append(" values ");
            sb.Append(" ( ");
            sb.Append("         @JurisdictionId, ");
            sb.Append("         @CompanyName, ");
            sb.Append("         @CompanyAddress, ");
            sb.Append("         @PostCode1, ");
            sb.Append("         @PostCode2, ");
            sb.Append("         @Website, ");
            sb.Append("         @NatureEnterprise, ");
            sb.Append("         @Tel, ");
            sb.Append("         @Fax, ");
            sb.Append("         @IsDelete, ");
            sb.Append("         @CreateUser, ");
            sb.Append("         @CreateTime, ");
            sb.Append("         @UpdateUser, ");
            sb.Append("         @UpdateTime, ");
            sb.Append("         Remark ");
            sb.Append(" ) ");

            return sb.ToString();
        }

        public override MySqlParameter[] CreateSelectParameter(Dictionary<string, string> dicCondition)
        {
            throw new NotImplementedException();
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

            sb.Append(" select * from m_supplier where 1=1 ");

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
        /// 创建数据库更新参数
        /// </summary>
        /// <returns></returns>
        public override MySqlParameter[] CreateUpdateParameter()
        {
            MySqlParameter[] paras = new MySqlParameter[]
            {
                new MySqlParameter("@JurisdictionId",MySqlDbType.VarChar,10),
                new MySqlParameter("@CompanyName",MySqlDbType.VarChar,100),
                new MySqlParameter("@CompanyAddress",MySqlDbType.VarChar,250),
                new MySqlParameter("@PostCode1",MySqlDbType.VarChar,10),
                new MySqlParameter("@PostCode2",MySqlDbType.VarChar,10),
                new MySqlParameter("@Website",MySqlDbType.VarChar,50),
                new MySqlParameter("@NatureEnterprise",MySqlDbType.VarChar,255),
                new MySqlParameter("@Tel",MySqlDbType.VarChar,12),
                new MySqlParameter("@Fax",MySqlDbType.VarChar,12),
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

            sb.Append(" update m_supplier ");
            sb.Append("    set JurisdictionId = @JurisdictionId, ");
            sb.Append("        CompanyName = @CompanyName, ");
            sb.Append("        CompanyAddress = @CompanyAddress, ");
            sb.Append("        PostCode1 = @PostCode1, ");
            sb.Append("        PostCode2 = @PostCode2, ");
            sb.Append("        Website = @Website, ");
            sb.Append("        NatureEnterprise = @NatureEnterprise, ");
            sb.Append("        Tel = @Tel, ");
            sb.Append("        Fax = @Fax, ");
            sb.Append("        IsDelete = @IsDelete, ");
            sb.Append("        CreateUser = @CreateUser, ");
            sb.Append("        CreateTime = @CreateTime, ");
            sb.Append("        UpdateUser = @UpdateUser, ");
            sb.Append("        UpdateTime = @UpdateTime, ");
            sb.Append("        Remark = @Remark ");

            if (dicCondition != null && dicCondition.ContainsKey(AppConst.Dictionary_ConditionCnt))
            {
                // foreach value sb.Append(Condition Value)
            }
            return sb.ToString();
        }
        #endregion
    }
}
