using IWS_Business.BusinessIF;
using IWS_Common.Model;
using IWS_Dao.Dao;
using IWS_Dao.DaoIF;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWS_Business.Business
{
    /// <summary>
    /// 角色数据模型操作类
    /// </summary>
    public class RoleBusiness : InterfaceBusiness<m_role>
    {
        /// <summary>
        /// 数据删除
        /// </summary>
        /// <param name="dicCondition">条件集合</param>
        /// <param name="lstData">数据集合（可缺省）</param>
        /// <returns></returns>
        public int DeleteData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<m_role> lstData = null)
        {
            int intReturnValue;
            try
            {
                // 用户模型Dao层对象
                InterfaceDao<m_role> roleDao = new RoleDao();
                intReturnValue = roleDao.DeleteData(conn, dicCondition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intReturnValue;
        }

        /// <summary>
        /// 数据追加
        /// </summary>
        /// <param name="dicCondition">条件集合</param>
        /// <param name="lstData">数据集合（可缺省）</param>
        /// <returns></returns>
        public int InsertData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<m_role> lstData = null)
        {
            int intReturnValue;
            try
            {
                // 用户模型Dao层对象
                InterfaceDao<m_role> roleDao = new RoleDao();
                intReturnValue = roleDao.InsertData(conn, dicCondition, lstData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intReturnValue;
        }

        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="dicCondition">条件集合</param>
        /// <param name="lstData">数据集合（可缺省）</param>
        /// <returns></returns>
        public List<m_role> SelectData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<m_role> lstData = null)
        {
            List<m_role> rtnData = null;
            try
            {
                // 用户模型Dao层对象
                InterfaceDao<m_role> roleDao = new RoleDao();
                rtnData = roleDao.SelectData(conn, dicCondition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rtnData;
        }

        /// <summary>
        /// 查询总数据条数
        /// </summary>
        /// <param name="dicCondition">条件集合</param>
        /// <returns></returns>
        public int SelectDataCnt(MySqlConnection conn, Dictionary<string, string> dicCondition)
        {
            int intReturnValue;

            try
            {
                // 用户模型Dao层对象
                InterfaceDao<m_role> roleDao = new RoleDao();
                intReturnValue = roleDao.SelectDataCnt(conn, dicCondition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intReturnValue;
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="dicCondition">条件集合</param>
        /// <param name="lstData">数据集合（可缺省）</param>
        /// <returns></returns>
        public int UpdateData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<m_role> lstData = null)
        {
            int intReturnValue;
            try
            {
                // 用户模型Dao层对象
                InterfaceDao<m_role> roleDao = new RoleDao();
                intReturnValue = roleDao.UpdateData(conn, dicCondition, lstData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intReturnValue;
        }
    }
}
