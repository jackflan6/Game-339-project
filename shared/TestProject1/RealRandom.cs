namespace TestProject1;

public class RealRandom : IRandom
{
    public int RandomNumber(int upperBound)
    {
        int rand = new Random().Next(upperBound);
        return rand;
    }
}