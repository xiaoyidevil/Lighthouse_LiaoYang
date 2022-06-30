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
    /// 入场登记数据模型操作类
    /// </summary>
    public class RegistrationBusiness : InterfaceBusiness<t_registration>
    {
        /// <summary>
        /// 数据删除
        /// </summary>
        /// <param name="dicCondition">条件集合</param>
        /// <param name="lstData">数据集合（可缺省）</param>
        /// <returns></returns>
        public int DeleteData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<t_registration> lstData = null)
        {
            int intReturnValue;
            try
            {
                // 用户模型Dao层对象
                InterfaceDao<t_registration> registrationDao = new RegistrationDao();
                intReturnValue = registrationDao.DeleteData(conn, dicCondition);
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
        public int InsertData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<t_registration> lstData = null)
        {
            int intReturnValue;
            try
            {
                // 用户模型Dao层对象
                InterfaceDao<t_registration> registrationDao = new RegistrationDao();
                intReturnValue = registrationDao.InsertData(conn, dicCondition, lstData);
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
        public List<t_registration> SelectData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<t_registration> lstData = null)
        {
            List<t_registration> rtnData = null;
            try
            {
                // 用户模型Dao层对象
                InterfaceDao<t_registration> registrationDao = new RegistrationDao();
                rtnData = registrationDao.SelectData(conn, dicCondition);
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
                InterfaceDao<t_registration> registrationDao = new RegistrationDao();
                intReturnValue = registrationDao.SelectDataCnt(conn, dicCondition);
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
        public int UpdateData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<t_registration> lstData = null)
        {
            int intReturnValue;
            try
            {
                // 用户模型Dao层对象
                InterfaceDao<t_registration> registrationDao = new RegistrationDao();
                intReturnValue = registrationDao.UpdateData(conn, dicCondition, lstData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intReturnValue;
        }
    }
}
