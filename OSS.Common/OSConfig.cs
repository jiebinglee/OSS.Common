﻿#region Copyright (C) 2016 Kevin (OSS开源系列) 公众号：osscoder

/***************************************************************************
*　　	文件功能描述：全局模块配置内
*
*　　	创建人： Kevin
*       创建人Email：1985088337@qq.com
*       
*****************************************************************************/

#endregion
using OSS.Common.Modules;
using OSS.Common.Modules.LogModule;

namespace OSS.Common
{
    /// <summary>
    /// 基础配置模块
    /// </summary>
    public static class OsConfig
    {
        private static ModuleBaseProvider _provider;

        /// <summary>
        /// 模块初始化提供者
        /// </summary>
        internal static ModuleBaseProvider Provider
        {
            get { return _provider ?? (_provider = new ModuleBaseProvider()); }
        }


        #region  Module初始化模块

        /// <summary>
        /// 注册缓存模块
        /// </summary>
        /// <param name="provider"></param>
        public static void RegisterModuleProvider(ModuleBaseProvider provider)
        {
            _provider = provider;
        }

        #endregion

        /// <summary>
        /// 设置日志异步模块名称
        /// </summary>
        /// <param name="asynModuleName"></param>
        public static void SetLogAsynModuleName(string asynModuleName)
        {
            LogUtil.LogAsynModuleName = asynModuleName;
        }


    }
}
