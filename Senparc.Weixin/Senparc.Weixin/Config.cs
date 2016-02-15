/*----------------------------------------------------------------
    Copyright (C) 2015 Senparc
    
    文件名：Config.cs
    文件功能描述：全局设置
    
    
    创建标识：Senparc - 20150211
    
    修改标识：Senparc - 20150303
    修改描述：整理接口
----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Senparc.Weixin
{
    /// <summary>
    /// 全局设置
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// 请求超时设置（以毫秒为单位），默认为10秒。
        /// 说明：此处常量专为提供给方法的参数的默认值，不是方法内所有请求的默认超时时间。
        /// </summary>
        public const int TIME_OUT = 10000;

        private static bool _isDebug = false;

        /// <summary>
        /// 指定是否是Debug状态，如果是，系统会自动输出日志
        /// </summary>
        public static bool IsDebug
        {
            get
            {
                return _isDebug;
            }
            set
            {
                _isDebug = value;

                //if (_isDebug)
                //{
                //    WeixinTrace.Open();
                //}
                //else
                //{
                //    WeixinTrace.Close();
                //}
            }
        }

        private static bool? _retryIfFaild = null;
        public static bool? RetryIfFaild
        {
            get
            {
                if (!_retryIfFaild.HasValue)
                {
                    _retryIfFaild = GetConfig<bool>("Senparc.Weixin:RetryIfFaild");
                }
                return _retryIfFaild;
            }
        }

        public static T? GetConfig<T>(string name) where T : struct
        {
            T? result = null;
            string config = GetConfig(name);
            if (config != null)
            {
                MethodInfo m = typeof(T).GetMethod("Parse", new Type[] { typeof(string) });

                if (m != null)
                {
                    result =
                        (T) m.Invoke(null, new object[] { config });
                }
                else
                {
                    result =
                        (T)
                            Convert.ChangeType(config, typeof (T),
                                CultureInfo.InvariantCulture);
                }
            }
            return result;
        }

        public static string GetConfig(string name)
        {
            string result = null;
            if (System.Configuration.ConfigurationManager.AppSettings.AllKeys.Contains(name))
            {
                result = System.Configuration.ConfigurationManager.AppSettings[name];
            }
            return result;
        }
    }
}
