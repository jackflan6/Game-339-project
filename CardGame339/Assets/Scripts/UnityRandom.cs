using UnityEngine;

public class UnityRandom : MonoBehaviour, IRandom
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        GameObject.FindGameObjectWithTag("ServiceResolver").GetComponent<ServiceResolver>().random = this;
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
