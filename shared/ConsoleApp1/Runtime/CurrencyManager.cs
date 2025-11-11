namespace ConsoleApp1
{
    public class CurrencyManager
    {
        public IGameLogger logger { get; }
        public ValueHolder<int> currencyAmount =new ValueHolder<int>();
#if !NOT_UNITY
        public CurrencyManager()
        {
            logger = ManagerManager.Resolve<IGameLogger>();
        }
#endif

        public CurrencyManager(IGameLogger log)
        {
            logger = log;
        }
    }
}