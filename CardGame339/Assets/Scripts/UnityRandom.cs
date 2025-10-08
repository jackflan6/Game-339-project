using UnityEngine;

public class UnityRandom : MonoBehaviour, IRandom
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int RandomNumber(int upperBound)
    {
        return Random.Range(0,upperBound);
    }
}
