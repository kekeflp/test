using System;
using System.Collections.Generic;

namespace TableExportExcle.Framework
{
    public class ActionStack
    {
        private static Dictionary<string, Action> actions = new Dictionary<string, Action>();
        public static void Register(string key, Action action)
        {
            // 把所有注册的标识和动作加到字典中。
            actions.Add(key, action);
        }

        public static void Execute(string key)
        {
            // 通过key去请求action委托执行（取出字典中的标识，然后执行动作）
            actions[key].Invoke();
        }
    }
}
