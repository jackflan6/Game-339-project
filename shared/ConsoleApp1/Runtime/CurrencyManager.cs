namespace ConsoleApp1
{
    public static class CurrencyManager
    {
        public static IGameLogger logger { get; }
        public static ValueHolder<int> currencyAmount =new ValueHolder<int>();
    }
}