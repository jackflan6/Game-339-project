using System.Collections;
using ConsoleApp1;
using UnityEngine;

public class UnityEffects : MonoBehaviour, IEffects
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObjectManager GameObjectManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowBurn(Enemy enemy)
    {
        StartCoroutine(FlashRedHalfSecond(enemy));
    }
    

    private IEnumerator FlashRedHalfSecond(Enemy enemy)
    {
        Color defaultColor = GameObjectManager.allCreatedEnemys[enemy].GetComponent<SpriteRenderer>().color;
        GameObjectManager.allCreatedEnemys[enemy].GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        GameObjectManager.allCreatedEnemys[enemy].GetComponent<SpriteRenderer>().color = defaultColor;
        
    }
}
