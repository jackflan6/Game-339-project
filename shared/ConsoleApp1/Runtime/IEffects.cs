namespace ConsoleApp1
{
    public interface IEffects
    {
        void ShowBurn(Enemy enemy);

        void ShowDamage(Enemy enemy);

        void DisplayBurnIcon(Enemy enemy);
    }
}