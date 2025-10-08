using UnityEngine;

public class FakeRandom : MonoBehaviour, IRandom
{
    public int RandomNumber(int upperBound)
    {
        return 0;
    }
}

public class FakeRandom2 : IRandom
{
    public int RandomNumber(int upperBound)
    {
        return 1;
    }
}