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
    /// 用户数据模型操作类
    /// </summary>
    public class VehicleBusiness : InterfaceBusiness<m_vehicle>
    {
        /// <summary>
        /// 数据删除
        /// </summary>
        /// <param name="dicCondition">条件集合</param>
        /// <param name="lstData">数据集合（可缺省）</param>
        /// <returns></returns>
        public int DeleteData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<m_vehicle> lstData = null)
        {
            int intReturnValue;
            try
            {
                // 用户模型Dao层对象
                InterfaceDao<m_vehicle> vehicleDao = new VehicleDao();
                intReturnValue = vehicleDao.DeleteData(conn, dicCondition);
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
        public int InsertData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<m_vehicle> lstData = null)
        {
            int intReturnValue;
            try
            {
                // 用户模型Dao层对象
                InterfaceDao<m_vehicle> vehicleDao = new VehicleDao();
                intReturnValue = vehicleDao.InsertData(conn, dicCondition, lstData);
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
        /// <param name="lstData">数据集合（可缺省）</param>
        /// <returns></returns>
        public int InsertData(MySqlConnection conn, ref List<m_vehicle> lstData )
        {
            int intReturnValue;
            try
            {
                // 用户模型Dao层对象
                InterfaceDao<m_vehicle> vehicleDao = new VehicleDao();
                intReturnValue = vehicleDao.InsertData(conn, ref lstData);
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
        public List<m_vehicle> SelectData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<m_vehicle> lstData = null)
        {
            List<m_vehicle> rtnData = null;
            try
            {
                // 用户模型Dao层对象
                InterfaceDao<m_vehicle> vehicleDao = new VehicleDao();
                rtnData = vehicleDao.SelectData(conn, dicCondition);
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
                InterfaceDao<m_vehicle> vehicleDao = new VehicleDao();
                intReturnValue = vehicleDao.SelectDataCnt(conn, dicCondition);
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
        public int UpdateData(MySqlConnection conn, Dictionary<string, string> dicCondition, List<m_vehicle> lstData = null)
        {
            int intReturnValue;
            try
            {
                // 用户模型Dao层对象
                InterfaceDao<m_vehicle> vehicleDao = new VehicleDao();
                intReturnValue = vehicleDao.UpdateData(conn, dicCondition, lstData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intReturnValue;
        }
    }
}
