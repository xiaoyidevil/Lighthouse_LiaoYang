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
    /// 物料数据库操模型作类
    /// </summary>
    public class MaterialDao : AbstractDao<m_material>, InterfaceDao<m_material>
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
        public List<m_material> SelectData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<m_material> lstData = null)
        {
            // 返回集合
            List<m_material> lstMaterial = new List<m_material>();

            // 连接失效返回空
            if (conn.State != System.Data.ConnectionState.Open) return lstMaterial;

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
                        lstMaterial.Add(new m_material()
                        {
                            Id = GetDBValueToInt(read["Id"]),
                            MaterialId = GetDBValueToString(read["MaterialId"]),
                            MaterialName = GetDBValueToString(read["MaterialName"]),
                            MaterialEnglishName = GetDBValueToString(read["MaterialEnglishName"]),
                            SpecificationsModel = GetDBValueToString(read["SpecificationsModel"]),
                            Material = GetDBValueToString(read["Material"]),
                            MaterialKind = GetDBValueToString(read["MaterialKind"]),
                            Unit = GetDBValueToString(read["Unit"]),
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
            return lstMaterial;
        }

        /// <summary>
        /// 数据删除
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="dicCondition">条件集合</param>
        /// <param name="lstData">数据集合</param>
        /// <returns></returns>
        public int DeleteData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<m_material> lstData = null)
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
        public int InsertData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<m_material> lstData = null)
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
                    foreach (m_material material in lstData)
                    {
                        paras = CreateInsertParameter();
                        paras[0].Value = material.MaterialId;
                        paras[1].Value = material.MaterialName;
                        paras[2].Value = material.MaterialEnglishName;
                        paras[3].Value = material.SpecificationsModel;
                        paras[4].Value = material.Material;
                        paras[5].Value = material.MaterialKind;
                        paras[6].Value = material.Unit;
                        paras[7].Value = GetDefualtDeleteFlg(material.IsDelete);
                        paras[8].Value = GetDefualtUser(material.CreateUser);
                        paras[9].Value = GetDefualtDatetime(material.CreateTime);
                        paras[10].Value = GetDefualtUser(material.UpdateUser);
                        paras[11].Value = GetDefualtDatetime(material.UpdateTime);
                        paras[12].Value = material.Remark;
                        cmd.Parameters.AddRange(paras);

                        intReturnValue += cmd.ExecuteNonQuery();                        
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
        public int UpdateData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<m_material> lstData = null)
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
                    foreach (m_material material in lstData)
                    {
                        paras = CreateUpdateParameter();
                        paras[0].Value = material.MaterialId;
                        paras[1].Value = material.MaterialName;
                        paras[2].Value = material.MaterialEnglishName;
                        paras[3].Value = material.SpecificationsModel;
                        paras[4].Value = material.Material;
                        paras[5].Value = material.MaterialKind;
                        paras[6].Value = material.Unit;
                        paras[7].Value = GetDefualtDeleteFlg(material.IsDelete);
                        paras[8].Value = GetDefualtUser(material.CreateUser);
                        paras[9].Value = GetDefualtDatetime(material.CreateTime);
                        paras[10].Value = GetDefualtUser(material.UpdateUser);
                        paras[11].Value = GetDefualtDatetime(material.UpdateTime);
                        paras[12].Value = material.Remark;
                        paras[13].Value = material.Id;
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

            sb.Append(" select count(*) from m_material Where IsDelete <> 1 ");

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

            sb.Append(" update m_material set IsDelete = 1 where IsDelete <> 1 ");
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
        /// <param name="dicCondition">条件集合</param>
        /// <param name="lstData">数据集合</param>
        /// <returns></returns>
        public override MySqlParameter[] CreateInsertParameter()
        {
            MySqlParameter[] paras = new MySqlParameter[] 
            {
                new MySqlParameter("@MaterialId",MySqlDbType.VarChar,10),
                new MySqlParameter("@MaterialName",MySqlDbType.VarChar,100),
                new MySqlParameter("@MaterialEnglishName",MySqlDbType.VarChar,100),
                new MySqlParameter("@SpecificationsModel",MySqlDbType.VarChar,100),
                new MySqlParameter("@Material",MySqlDbType.VarChar,100),
                new MySqlParameter("@MaterialKind",MySqlDbType.VarChar,100),
                new MySqlParameter("@Unit",MySqlDbType.VarChar,10),                
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

            sb.Append(" select * from m_material where IsDelete <> 1 ");

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

            sb.Append(" insert into m_material ");
            sb.Append(" ( ");
            sb.Append("         MaterialId, ");
            sb.Append("         MaterialName, ");
            sb.Append("         MaterialEnglishName, ");
            sb.Append("         SpecificationsModel, ");
            sb.Append("         Material, ");
            sb.Append("         MaterialKind, ");
            sb.Append("         Unit, ");
            sb.Append("         IsDelete, ");
            sb.Append("         CreateUser, ");
            sb.Append("         CreateTime, ");
            sb.Append("         UpdateUser, ");
            sb.Append("         UpdateTime, ");
            sb.Append("         Remark ");
            sb.Append(" ) ");
            sb.Append(" values ");
            sb.Append(" ( ");
            sb.Append("         @MaterialId, ");
            sb.Append("         @MaterialName, ");
            sb.Append("         @MaterialEnglishName, ");
            sb.Append("         @SpecificationsModel, ");
            sb.Append("         @Material, ");
            sb.Append("         @MaterialKind, ");
            sb.Append("         @Unit, ");
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
                new MySqlParameter("@MaterialId",MySqlDbType.VarChar,10),
                new MySqlParameter("@MaterialName",MySqlDbType.VarChar,100),
                new MySqlParameter("@MaterialEnglishName",MySqlDbType.VarChar,100),
                new MySqlParameter("@SpecificationsModel",MySqlDbType.VarChar,100),
                new MySqlParameter("@Material",MySqlDbType.VarChar,100),
                new MySqlParameter("@MaterialKind",MySqlDbType.VarChar,100),
                new MySqlParameter("@Unit",MySqlDbType.VarChar,10),
                new MySqlParameter("@IsDelete",MySqlDbType.Int32,0),
                new MySqlParameter("@CreateUser",MySqlDbType.VarChar,10),
                new MySqlParameter("@CreateTime",MySqlDbType.DateTime),
                new MySqlParameter("@UpdateUser",MySqlDbType.VarChar,10),
                new MySqlParameter("@UpdateTime",MySqlDbType.DateTime),
                new MySqlParameter("@Remark",MySqlDbType.VarChar,500),
                new MySqlParameter("@Id",MySqlDbType.Int32)
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

            sb.Append(" update m_material ");
            sb.Append("    set MaterialId = @MaterialId, ");
            sb.Append("        MaterialName = @MaterialName, ");
            sb.Append("        MaterialEnglishName = @MaterialEnglishName, ");
            sb.Append("        SpecificationsModel = @SpecificationsModel, ");
            sb.Append("        Material = @Material, ");
            sb.Append("        MaterialKind = @MaterialKind, ");
            sb.Append("        Unit = @Unit, ");
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
