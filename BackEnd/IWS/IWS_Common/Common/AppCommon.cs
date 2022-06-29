using IWS_Common.Const;
using IWS_Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWS_Common.Common
{
    /// <summary>
    /// 共通处理类
    /// </summary>
    public static class AppCommon
    {
        #region 条件编辑函数

        /// <summary>
        /// 编辑用户条件集合
        /// </summary>
        /// <param name="model">条件模型</param>
        /// <returns></returns>
        public static Dictionary<string,string> GetUserCondition(UserConditionModel model)
        {
            Dictionary<string, string> rtnCondition = new Dictionary<string, string>();
            int conditionCnt = 0;

            // 条件编辑
            switch(model.OprationKind)
            {
                case AppConst.Operation_Query:
                    if (!string.IsNullOrEmpty(model.UserId)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and UserId = '" + model.UserId + "' "); }
                    if (!string.IsNullOrEmpty(model.UserName)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and UserName like '%" + model.UserName + "%' "); }
                    if (!string.IsNullOrEmpty(model.Telephone)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and Telephone = '" + model.Telephone + "' "); }
                    if (!string.IsNullOrEmpty(model.IdCard)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and IdCard = '" + model.IdCard + "' "); }
                    if (!string.IsNullOrEmpty(model.Age)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and Age = '" + model.Age + "' "); }
                    if (!string.IsNullOrEmpty(model.Sex)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and Sex = '" + model.Sex + "' "); }
                    rtnCondition.Add(AppConst.Dictionary_Condition_Limit, " limit " + model.StartIndex + ", " + model.PageCnt);
                    break;
                case AppConst.Operation_Insert:
                    break;
                case AppConst.Operation_Update:
                    if (!string.IsNullOrEmpty(model.Id)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and Id = " + model.Id); }
                    break;
                case AppConst.Operation_Delete:
                    if (!string.IsNullOrEmpty(model.Id)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and Id in (" + model.Id + ") "); }
                    break;
            }

            return rtnCondition;
        }

        /// <summary>
        /// 编辑车辆条件集合
        /// </summary>
        /// <param name="model">条件模型</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetVehicleCondition(VehicleConditionModel model)
        {
            Dictionary<string, string> rtnCondition = new Dictionary<string, string>();
            int conditionCnt = 0;

            // 条件编辑
            switch(model.OprationKind)
            {
                case AppConst.Operation_Query:
                    if (!string.IsNullOrEmpty(model.VehicleNumber)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and VehicleNumber like '%" + model.VehicleNumber + "%' "); }
                    if (!string.IsNullOrEmpty(model.CompanyName)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and companyName like '%" + model.CompanyName + "%' "); }
                    if (!string.IsNullOrEmpty(model.BrandModel)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and brandModel like '%" + model.BrandModel + "%' "); }
                    if (!string.IsNullOrEmpty(model.Color)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and color = '" + model.Color + "' "); }
                    rtnCondition.Add(AppConst.Dictionary_Condition_Limit, " limit " + model.StartIndex + ", " + model.PageCnt);
                    break;
                case AppConst.Operation_Insert:
                    break;
                case AppConst.Operation_Update:
                    break;
                case AppConst.Operation_Delete:
                    if (!string.IsNullOrEmpty(model.VehicleId)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and VehicleId in (" + model.VehicleId + ") "); }
                    break;
            }
            return rtnCondition;
        }

        /// <summary>
        /// 编辑供应商条件集合
        /// </summary>
        /// <param name="model">条件模型</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetSupplierCondition(SupplierConditionModel model)
        {
            Dictionary<string, string> rtnCondition = new Dictionary<string, string>();
            int conditionCnt = 0;

            // 条件编辑
            switch(model.OprationKind)
            {
                case AppConst.Operation_Query:
                    if (!string.IsNullOrEmpty(model.SupplierId)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and SupplierId = '" + model.SupplierId + "' "); }
                    if (!string.IsNullOrEmpty(model.CompanyName)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and companyName like '%" + model.CompanyName + "%' "); }
                    if (!string.IsNullOrEmpty(model.CompanyAddress)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and companyAddress like '%" + model.CompanyAddress + "%' "); }
                    if (!string.IsNullOrEmpty(model.PostCode1)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and postCode1 = '" + model.PostCode1 + "' "); }
                    if (!string.IsNullOrEmpty(model.PostCode2)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and postCode2 = '" + model.PostCode2 + "' "); }
                    if (!string.IsNullOrEmpty(model.Website)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and website like '%" + model.Website + "%' "); }
                    if (!string.IsNullOrEmpty(model.NatureEnterprise)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and natureEnterprise = '" + model.NatureEnterprise + "' "); }
                    if (!string.IsNullOrEmpty(model.Tel)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and tel = '" + model.Tel + "' "); }
                    if (!string.IsNullOrEmpty(model.Fax)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and fax = '" + model.Fax + "' "); }
                    rtnCondition.Add(AppConst.Dictionary_Condition_Limit, " limit " + model.StartIndex + ", " + model.PageCnt);
                    break;
                case AppConst.Operation_Insert:
                    break;
                case AppConst.Operation_Update:
                    break;
                case AppConst.Operation_Delete:
                    if (!string.IsNullOrEmpty(model.SupplierId)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and SupplierId in (" + model.SupplierId + ") "); }
                    break;
            }
            

            return rtnCondition;
        }

        /// <summary>
        /// 编辑角色条件集合
        /// </summary>
        /// <param name="startIndex">开始位置</param>
        /// <param name="pageCnt">每页显示条数</param>
        /// <param name="roleId">角色</param>
        /// <param name="roleName">角色名称</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetRoleCondition(RoleConditionModel model)
        {
            Dictionary<string, string> rtnCondition = new Dictionary<string, string>();
            int conditionCnt = 0;

            // 条件编辑
            switch(model.OprationKind)
            {
                case AppConst.Operation_Query:
                    if (!string.IsNullOrEmpty(model.RoleId)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and roleId = '" + model.RoleId + "' "); }
                    if (!string.IsNullOrEmpty(model.RoleName)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and roleName like '%" + model.RoleName + "%' "); }
                    rtnCondition.Add(AppConst.Dictionary_Condition_Limit, " limit " + model.StartIndex + ", " + model.PageCnt);
                    break;
                case AppConst.Operation_Insert:
                    break;
                case AppConst.Operation_Update:
                    break;
                case AppConst.Operation_Delete:
                    if (!string.IsNullOrEmpty(model.RoleId)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and RoleId in (" + model.RoleId + ") "); }
                    break;
            }            

            return rtnCondition;
        }

        /// <summary>
        /// 编辑入场登记条件集合
        /// </summary>
        /// <param name="startIndex">开始位置</param>
        /// <param name="pageCnt">每页显示条数</param>
        /// <param name="companyId">公司ID</param>
        /// <param name="companyName">公司名称</param>
        /// <param name="userId">人员ID</param>
        /// <param name="userName">人员名称</param>
        /// <param name="vehicleNumber">车牌号</param>
        /// <param name="entranceGate">入场大门</param>
        /// <param name="entranceDateTimeFrom">入场时间From</param>
        /// <param name="entranceDateTimeTo">入场时间To</param>
        /// <param name="overseer">监工单位</param>
        /// <param name="reason">原因</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetRegistrationCondition(int startIndex, int pageCnt, string companyId, string companyName, string userId, string userName, string vehicleNumber, string entranceGate, string entranceDateTimeFrom, string entranceDateTimeTo, string overseer, string reason)
        {
            Dictionary<string, string> rtnCondition = new Dictionary<string, string>();
            int conditionCnt = 0;

            // 条件编辑
            if (!string.IsNullOrEmpty(companyId)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and companyId = '" + companyId + "' "); }
            if (!string.IsNullOrEmpty(companyName)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and companyName like '%" + companyName + "%' "); }
            if (!string.IsNullOrEmpty(userId)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and userId = '" + userId + "' "); }
            if (!string.IsNullOrEmpty(userName)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and userName like '%" + userName + "%' "); }
            if (!string.IsNullOrEmpty(vehicleNumber)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and vehicleNumber = '" + vehicleNumber + "' "); }
            if (!string.IsNullOrEmpty(entranceGate)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and entranceGate like '%" + entranceGate + "%' "); }
            if (!string.IsNullOrEmpty(overseer)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and overseer like '%" + overseer + "%' "); }
            if (!string.IsNullOrEmpty(reason)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and reason like '%" + reason + "%' "); }
            rtnCondition.Add(AppConst.Dictionary_Condition_Limit, " limit " + startIndex + ", " + pageCnt);

            return rtnCondition;
        }

        /// <summary>
        /// 编辑物料条件集合
        /// </summary>
        /// <param name="startIndex">开始位置</param>
        /// <param name="pageCnt">每页显示条数</param>
        /// <param name="materialId">物料编号</param>
        /// <param name="materialName">物料名称</param>
        /// <param name="materialEnglishName">物料英文名称</param>
        /// <param name="specificationsModel">规格型号</param>
        /// <param name="material">材质</param>
        /// <param name="materialKind">物料类别</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetMaterialCondition(int startIndex, int pageCnt, string materialId, string materialName, string materialEnglishName, string specificationsModel, string material, string materialKind)
        {
            Dictionary<string, string> rtnCondition = new Dictionary<string, string>();
            int conditionCnt = 0;

            // 条件编辑
            if (!string.IsNullOrEmpty(materialId)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and materialId = '" + materialId + "' "); }
            if (!string.IsNullOrEmpty(materialName)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and materialName like '%" + materialName + "%' "); }
            if (!string.IsNullOrEmpty(materialEnglishName)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and materialEnglishName like '%" + materialEnglishName + "%' "); }
            if (!string.IsNullOrEmpty(specificationsModel)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and specificationsModel like '%" + specificationsModel + "%' "); }
            if (!string.IsNullOrEmpty(material)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and material like '%" + material + "%' "); }
            if (!string.IsNullOrEmpty(materialKind)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and materialKind like '%" + materialKind + "%' "); }
            rtnCondition.Add(AppConst.Dictionary_Condition_Limit, " limit " + startIndex + ", " + pageCnt);

            return rtnCondition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startIndex">开始位置</param>
        /// <param name="pageCnt">每页显示条数</param>
        /// <param name="jurisdictionId">权限ID</param>
        /// <param name="jurisdictionLevel">权限层级</param>
        /// <param name="jurisdictionName">权限名称</param>
        /// <param name="jurisdictionPath">权限路径</param>
        /// <returns></returns>
        //public static Dictionary<string, string> GetJurisdictionCondition(int startIndex, int pageCnt, string jurisdictionId, string jurisdictionLevel, string jurisdictionName, string jurisdictionPath)
        public static Dictionary<string, string> GetJurisdictionCondition(int roleId)
        {
            Dictionary<string, string> rtnCondition = new Dictionary<string, string>();
            int conditionCnt = 0;

            // 条件编辑
            //if (!string.IsNullOrEmpty(jurisdictionId)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and jurisdictionId = '" + jurisdictionId + "' "); }
            //if (!string.IsNullOrEmpty(jurisdictionLevel)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and jurisdictionLevel = '" + jurisdictionLevel + "' "); }
            //if (!string.IsNullOrEmpty(jurisdictionName)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and jurisdictionName like '%" + jurisdictionName + "%' "); }
            //if (!string.IsNullOrEmpty(jurisdictionPath)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and jurisdictionPath = '" + jurisdictionPath + "' "); }            
            //if (!string.IsNullOrEmpty(jurisdictionPath)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and jurisdictionPath = '" + jurisdictionPath + "' "); }            
            //rtnCondition.Add(AppConst.Dictionary_Condition_Limit, " limit " + startIndex + ", " + pageCnt);
            if (roleId != 0) { conditionCnt++; rtnCondition.Add("roleid", " and r.RoleId = " + roleId ); }
            return rtnCondition;
        }
        #endregion

        #region 共通函数

        /// <summary>
        /// 计算获取总页数
        /// </summary>
        /// <param name="pageCnt">每页显示条数</param>
        /// <param name="totalDataCnt">查询后数据总条数</param>
        /// <returns></returns>
        public static int GetTotalPageCnt(int pageCnt, int totalDataCnt)
        {
            if (totalDataCnt <= 0)
            {
                return 0;
            }
            else
            {
                if (totalDataCnt % pageCnt > 0)
                {
                    return totalDataCnt / pageCnt + 1;
                }
                else
                {
                    return totalDataCnt / pageCnt;
                }
            }
        }

        #endregion
    }
}
