using IWS_Common.Const;
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
        /// <param name="startIndex">开始位置</param>
        /// <param name="pageCnt">每页显示条数</param>
        /// <param name="userId">用户ID</param>
        /// <param name="userName">用户名称</param>
        /// <param name="telephone">电话</param>
        /// <param name="idCard">身份证</param>
        /// <param name="age">年龄</param>
        /// <param name="sex">性别</param>
        /// <returns></returns>
        public static Dictionary<string,string> GetUserCondition(int startIndex, int pageCnt, string userId, string userName, string telephone, string idCard, string age, string sex)
        {
            Dictionary<string, string> rtnCondition = new Dictionary<string, string>();
            int conditionCnt = 0;

            // 条件编辑
            if (!string.IsNullOrEmpty(userId)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and UserId = '" + userId + "' "); }
            if (!string.IsNullOrEmpty(userName)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and UserName like '%" + userName + "%' "); }
            if (!string.IsNullOrEmpty(telephone)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and Telephone = '" + telephone + "' "); }
            if (!string.IsNullOrEmpty(idCard)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and IdCard = '" + idCard + "' "); }
            if (!string.IsNullOrEmpty(age)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and Age = '" + age + "' "); }
            if (!string.IsNullOrEmpty(sex)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and Sex = '" + sex + "' "); }
            rtnCondition.Add(AppConst.Dictionary_Condition_Limit, " limit " + startIndex + ", " + pageCnt);

            return rtnCondition;
        }

        /// <summary>
        /// 编辑车辆条件集合
        /// </summary>
        /// <param name="startIndex">开始位置</param>
        /// <param name="pageCnt">每页显示条数</param>
        /// <param name="vehicleNumber">车牌号</param>
        /// <param name="companyName">所属公司名称</param>
        /// <param name="brandModel">品牌型号</param>
        /// <param name="color">车身颜色</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetVehicleCondition(int startIndex, int pageCnt, string vehicleNumber, string companyName, string brandModel, string color)
        {
            Dictionary<string, string> rtnCondition = new Dictionary<string, string>();
            int conditionCnt = 0;

            // 条件编辑
            if (!string.IsNullOrEmpty(vehicleNumber)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and VehicleNumber like '%" + vehicleNumber + "%' "); }
            if (!string.IsNullOrEmpty(companyName)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and companyName like '%" + companyName + "%' "); }
            if (!string.IsNullOrEmpty(brandModel)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and brandModel like '%" + brandModel + "%' "); }
            if (!string.IsNullOrEmpty(color)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and color = '" + color + "' "); }
            rtnCondition.Add(AppConst.Dictionary_Condition_Limit, " limit " + startIndex + ", " + pageCnt);

            return rtnCondition;
        }

        /// <summary>
        /// 编辑供应商条件集合
        /// </summary>
        /// <param name="startIndex">开始位置</param>
        /// <param name="pageCnt">每页显示条数</param>
        /// <param name="supplierId">供应商ID</param>
        /// <param name="companyName">公司名称</param>
        /// <param name="companyAddress">公司地址</param>
        /// <param name="postCode1">邮编1</param>
        /// <param name="postCode2">邮编2</param>
        /// <param name="website">网站</param>
        /// <param name="natureEnterprise">公司性质</param>
        /// <param name="tel">电话</param>
        /// <param name="fax">传真</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetSupplierCondition(int startIndex, int pageCnt, string supplierId, string companyName, string companyAddress, string postCode1, string postCode2, string website, string natureEnterprise, string tel, string fax)
        {
            Dictionary<string, string> rtnCondition = new Dictionary<string, string>();
            int conditionCnt = 0;

            // 条件编辑
            if (!string.IsNullOrEmpty(supplierId)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and SupplierId = '" + supplierId + "' "); }
            if (!string.IsNullOrEmpty(companyName)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and companyName like '%" + companyName + "%' "); }
            if (!string.IsNullOrEmpty(companyAddress)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and companyAddress like '%" + companyAddress + "%' "); }
            if (!string.IsNullOrEmpty(postCode1)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and postCode1 = '" + postCode1 + "' "); }
            if (!string.IsNullOrEmpty(postCode2)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and postCode2 = '" + postCode2 + "' "); }
            if (!string.IsNullOrEmpty(website)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and website like '%" + website + "%' "); }
            if (!string.IsNullOrEmpty(natureEnterprise)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and natureEnterprise = '" + natureEnterprise + "' "); }
            if (!string.IsNullOrEmpty(tel)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and tel = '" + tel + "' "); }
            if (!string.IsNullOrEmpty(fax)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and fax = '" + fax + "' "); }
            rtnCondition.Add(AppConst.Dictionary_Condition_Limit, " limit " + startIndex + ", " + pageCnt);

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
        public static Dictionary<string, string> GetRoleCondition(int startIndex, int pageCnt, string roleId, string roleName)
        {
            Dictionary<string, string> rtnCondition = new Dictionary<string, string>();
            int conditionCnt = 0;

            // 条件编辑
            if (!string.IsNullOrEmpty(roleId)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and roleId = '" + roleId + "' "); }
            if (!string.IsNullOrEmpty(roleName)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and roleName like '%" + roleName + "%' "); }            
            rtnCondition.Add(AppConst.Dictionary_Condition_Limit, " limit " + startIndex + ", " + pageCnt);

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
        public static Dictionary<string, string> GetJurisdictionCondition(int startIndex, int pageCnt, string jurisdictionId, string jurisdictionLevel, string jurisdictionName, string jurisdictionPath)
        {
            Dictionary<string, string> rtnCondition = new Dictionary<string, string>();
            int conditionCnt = 0;

            // 条件编辑
            if (!string.IsNullOrEmpty(jurisdictionId)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and jurisdictionId = '" + jurisdictionId + "' "); }
            if (!string.IsNullOrEmpty(jurisdictionLevel)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and jurisdictionLevel = '" + jurisdictionLevel + "' "); }
            if (!string.IsNullOrEmpty(jurisdictionName)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and jurisdictionName like '%" + jurisdictionName + "%' "); }
            if (!string.IsNullOrEmpty(jurisdictionPath)) { conditionCnt++; rtnCondition.Add(AppConst.Dictionary_Condition + conditionCnt, " and jurisdictionPath = '" + jurisdictionPath + "' "); }            
            rtnCondition.Add(AppConst.Dictionary_Condition_Limit, " limit " + startIndex + ", " + pageCnt);

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
