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
                    if (!string.IsNullOrEmpty(model.Id)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and Id in (" + model.Id + ") "); }
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
                    if (!string.IsNullOrEmpty(model.Id)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and Id in (" + model.Id + ") "); }
                    break;
            }            
            return rtnCondition;
        }

        /// <summary>
        /// 编辑供应商条件集合
        /// </summary>
        /// <param name="model">条件模型</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetDemanderCondition(DemanderConditionModel model)
        {
            Dictionary<string, string> rtnCondition = new Dictionary<string, string>();
            int conditionCnt = 0;

            // 条件编辑
            switch (model.OprationKind)
            {
                case AppConst.Operation_Query:
                    if (!string.IsNullOrEmpty(model.DemanderId)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and DemanderId = '" + model.DemanderId + "' "); }
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
                    if (!string.IsNullOrEmpty(model.Id)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and Id in (" + model.Id + ") "); }
                    break;
            }
            return rtnCondition;
        }

        /// <summary>
        /// 编辑角色条件集合
        /// </summary>
        /// <param name="model">条件模型</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetRoleCondition(RoleConditionModel model)
        {
            Dictionary<string, string> rtnCondition = new Dictionary<string, string>();
            int conditionCnt = 0;

            // 条件编辑
            switch(model.OprationKind)
            {
                case AppConst.Operation_Query:
                    if (!string.IsNullOrEmpty(model.RoleId)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and roleId = " + model.RoleId + " "); }
                    if (!string.IsNullOrEmpty(model.RoleName)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and roleName like '%" + model.RoleName + "%' "); }
                    if (!string.IsNullOrEmpty(model.RoleDesc)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and RoleDesc like '%" + model.RoleDesc + "%' "); }
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
        /// <param name="model">条件模型</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetRegistrationCondition(RegistrationConditionModel model)
        {
            Dictionary<string, string> rtnCondition = new Dictionary<string, string>();
            int conditionCnt = 0;

            // 条件编辑
            switch (model.OprationKind)
            {
                case AppConst.Operation_Query:
                    if (!string.IsNullOrEmpty(model.CompanyId)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and CompanyId = '" + model.CompanyId + "' "); }
                    if (!string.IsNullOrEmpty(model.CompanyName)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and CompanyName like '%" + model.CompanyName + "%' "); }
                    if (!string.IsNullOrEmpty(model.UserId)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and UserId = '" + model.UserId + "' "); }
                    if (!string.IsNullOrEmpty(model.UserName)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and UserName like '%" + model.UserName + "%' "); }
                    if (!string.IsNullOrEmpty(model.VehicleNumber)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and VehicleNumber like '%" + model.VehicleNumber + "%' "); }
                    if (!string.IsNullOrEmpty(model.EntranceGate)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and EntranceGate like '%" + model.EntranceGate + "%' "); }
                    if (!string.IsNullOrEmpty(model.Overseer)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and Overseer like '%" + model.Overseer + "%' "); }
                    if (!string.IsNullOrEmpty(model.Reason)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and Reason like '%" + model.Reason + "%' "); }
                    rtnCondition.Add(AppConst.Dictionary_Condition_Limit, " limit " + model.StartIndex + ", " + model.PageCnt);
                    break;
                case AppConst.Operation_Insert:
                    break;
                case AppConst.Operation_Update:
                    break;
                case AppConst.Operation_Delete:
                    if (!string.IsNullOrEmpty(model.Id)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and Id in (" + model.Id + ") "); }
                    break;
            }
            return rtnCondition;
        }

        /// <summary>
        /// 入场审批条件集合
        /// </summary>
        /// <param name="model">条件模型</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetApprovalCondition(ApprovalConditionModel model)
        {
            Dictionary<string, string> rtnCondition = new Dictionary<string, string>();
            int conditionCnt = 0;

            // 条件编辑
            switch (model.OprationKind)
            {
                case AppConst.Operation_Query:
                    if (!string.IsNullOrEmpty(model.AdmisionType)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and AdmisionType = '" + model.AdmisionType + "' "); }
                    if (!string.IsNullOrEmpty(model.CompanyName)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and CompanyName like '%" + model.CompanyName + "%' "); }
                    if (!string.IsNullOrEmpty(model.UserName)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and UserName like '%" + model.UserName + "%' "); }
                    if (!string.IsNullOrEmpty(model.VehicleNumber)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and VehicleNumber like '%" + model.VehicleNumber + "%' "); }
                    if (!string.IsNullOrEmpty(model.EntranceGate)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and EntranceGate like '%" + model.EntranceGate + "%' "); }
                    if (!string.IsNullOrEmpty(model.Accption)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and Accption like '%" + model.Accption + "%' "); }
                    if (!string.IsNullOrEmpty(model.ApprovalState)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and ApprovalState like '%" + model.ApprovalState + "%' "); }
                    rtnCondition.Add(AppConst.Dictionary_Condition_Limit, " limit " + model.StartIndex + ", " + model.PageCnt);
                    break;
                case AppConst.Operation_Insert:
                    break;
                case AppConst.Operation_Update:
                    break;
                case AppConst.Operation_Delete:
                    if (!string.IsNullOrEmpty(model.Id)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and Id in (" + model.Id + ") "); }
                    break;
            }

            return rtnCondition;
        }

        /// <summary>
        /// 编辑物料条件集合
        /// </summary>
        /// <param name="model">条件模型</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetMaterialCondition(MaterialConditionModel model)
        {
            Dictionary<string, string> rtnCondition = new Dictionary<string, string>();
            int conditionCnt = 0;

            // 条件编辑
            switch (model.OprationKind)
            {
                case AppConst.Operation_Query:
                    if (!string.IsNullOrEmpty(model.MaterialId)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and MaterialId = '" + model.MaterialId + "' "); }
                    if (!string.IsNullOrEmpty(model.MaterialName)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and MaterialName like '%" + model.MaterialName + "%' "); }
                    if (!string.IsNullOrEmpty(model.MaterialEnglishName)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and MaterialEnglishName like '%" + model.MaterialEnglishName + "%' "); }
                    if (!string.IsNullOrEmpty(model.SpecificationsModel)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and specificationsModel like '%" + model.SpecificationsModel + "%' "); }
                    if (!string.IsNullOrEmpty(model.Material)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and Material like '%" + model.Material + "%' "); }
                    if (!string.IsNullOrEmpty(model.MaterialKind)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and MaterialKind like '%" + model.MaterialKind + "%' "); }
                    rtnCondition.Add(AppConst.Dictionary_Condition_Limit, " limit " + model.StartIndex + ", " + model.PageCnt);
                    break;
                case AppConst.Operation_Insert:
                    break;
                case AppConst.Operation_Update:
                    break;
                case AppConst.Operation_Delete:
                    if (!string.IsNullOrEmpty(model.Id)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and Id in (" + model.Id + ") "); }
                    break;
            }

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
