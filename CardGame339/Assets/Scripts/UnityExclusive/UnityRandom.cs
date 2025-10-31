using UnityEngine;

public class UnityRandom : MonoBehaviour, IRandom
{

    // Update is called once per frame
    void Update()
    {
        
    }

    public int RandomNumber(int upperBound)
    {
        return Random.Range(0,upperBound);
    }
}
