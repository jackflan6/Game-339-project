using UnityEngine;

public class UnityRandom : MonoBehaviour, IRandom
{
    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("GlobalResolver").GetComponent<GlobalResolver>().loaded)
        {
            Destroy(gameObject);
        }
    }

    public int RandomNumber(int upperBound)
    {
        return Random.Range(0,upperBound);
    }
}
