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
    /// 审批数据模型操作类
    /// </summary>
    public class ApprovalBusiness : InterfaceBusiness<t_approval>
    {
        /// <summary>
        /// 数据删除
        /// </summary>
        /// <param name="dicCondition">条件集合</param>
        /// <param name="lstData">数据集合（可缺省）</param>
        /// <returns></returns>
        public int DeleteData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<t_approval> lstData = null)
        {
            int intReturnValue;
            try
            {
                // 用户模型Dao层对象
                InterfaceDao<t_approval> approvalDao = new ApprovalDao();
                intReturnValue = approvalDao.DeleteData(conn, dicCondition);
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
        public int InsertData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<t_approval> lstData = null)
        {
            int intReturnValue;
            try
            {
                // 用户模型Dao层对象
                InterfaceDao<t_approval> approvalDao = new ApprovalDao();
                intReturnValue = approvalDao.InsertData(conn, dicCondition, lstData);
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
        public List<t_approval> SelectData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<t_approval> lstData = null)
        {
            List<t_approval> rtnData = null;
            try
            {
                // 用户模型Dao层对象
                InterfaceDao<t_approval> approvalDao = new ApprovalDao();
                rtnData = approvalDao.SelectData(conn, dicCondition);
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
                InterfaceDao<t_approval> approvalDao = new ApprovalDao();
                intReturnValue = approvalDao.SelectDataCnt(conn, dicCondition);
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
        public int UpdateData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<t_approval> lstData = null)
        {
            int intReturnValue;
            try
            {
                // 用户模型Dao层对象
                InterfaceDao<t_approval> approvalDao = new ApprovalDao();
                intReturnValue = approvalDao.UpdateData(conn, dicCondition, lstData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intReturnValue;
        }
    }
}
