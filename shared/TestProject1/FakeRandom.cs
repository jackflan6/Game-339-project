namespace TestProject1;

public class FakeRandom : IRandom
{
    public int RandomNumber(int upperBound)
    {
        return 1;
    }
}