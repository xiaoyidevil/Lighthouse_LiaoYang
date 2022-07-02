﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWS_Common.Const
{
    /// <summary>
    /// 静态常量类
    /// </summary>
    public static class AppConst
    {
        #region 平台区分
        public const string Platform_Webapi = "webapi";                         // 网络应用接口
        public const string Platform_Application = "application";               // 系统应用程序
        #endregion

        #region 条件字典区分
        public const string Dictionary_ConditionCnt = "ConditionCnt";           // 条件个数
        public const string Dictionary_Condition = "Condition";                 // 条件标记
        public const string Dictionary_Condition_Limit = "Limit";               // 条件标记_Limit
        #endregion

        #region 条件区分
        public const string Operation_Query = "Query";                          // 查询
        public const string Operation_Insert = "Insert";                        // 插入
        public const string Operation_Update = "Update";                        // 更新
        public const string Operation_Delete = "Delete";                        // 删除
        #endregion

        #region 消息信息
        public const string Excute_Success = "执行成功";                        // 执行成功信息
        public const string Excute_NoData = "没有数据被执行";                   // 没有数据被执行
        public const string Login_Success = "登录成功";                        // 登录成功信息
        #endregion
    }
}
