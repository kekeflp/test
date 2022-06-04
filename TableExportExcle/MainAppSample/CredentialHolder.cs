namespace MainAppSample
{
    internal class CredentialHolder
    {
        #region 单例模式
        private CredentialHolder() { /*禁止在外部被实例化*/ }
        public static CredentialHolder Singleton = new CredentialHolder();
        public static CredentialHolder GetSingleton() => Singleton ?? new CredentialHolder();
        public static void Clear() => Singleton = new CredentialHolder(); /* 销毁原有单例（重新生成一个实例） */
        #endregion 

        internal bool IsAuthenticated { get; set; }
    }
}
