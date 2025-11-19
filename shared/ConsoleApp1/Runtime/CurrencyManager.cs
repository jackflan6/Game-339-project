namespace ConsoleApp1
{
    public class CurrencyManager
    {
        public IGameLogger logger { get; }
        public ValueHolder<int> currencyAmount =new ValueHolder<int>();
        public ValueHolder<int> bossCurrencyAmount = new ValueHolder<int>();
        public ValueHolder<int> maxPlayerHP = new ValueHolder<int>();
#if !NOT_UNITY
        public CurrencyManager()
        {
            logger = ManagerManager.Resolve<IGameLogger>();
            maxPlayerHP.Value = 20;
        }
#endif

        public CurrencyManager(IGameLogger log)
        {
            logger = log;
            maxPlayerHP.Value = 20;
        }
    }
}