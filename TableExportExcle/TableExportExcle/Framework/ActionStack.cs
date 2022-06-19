using System;
using System.Collections.Generic;

namespace TableExportExcle.Framework
{
    public class ActionStack
    {
        private static Dictionary<string, Func<object, bool>> actions = new Dictionary<string, Func<object, bool>>();
        public static void Register(string key, Func<object, bool> action)
        {
            // 把所有注册的标识和动作加到字典中。
            actions.Add(key, action);
        }

        public static bool Execute(string key, object obj)
        {
            // 通过key去请求action委托执行（取出字典中的标识，然后执行动作）
            return actions[key].Invoke(obj);
        }
    }
}
