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

    public void ShowDamage(Enemy enemy)
    {
        StartCoroutine(ShakeEnemy(enemy));
    }

    public void DisplayBurnIcon(Enemy enemy)
    {
        if(GameObjectManager.allCreatedEnemys.ContainsKey(enemy))
        {
            if (enemy != null && enemy.currentBurnDamage > 0)
            {
                GameObjectManager.allCreatedEnemys[enemy].transform.GetChild(0).GetComponent<SpriteRenderer>().enabled =
                    true;
                print("enemy is burning");
            }

            else if (enemy != null && enemy.currentBurnDamage <= 0)
            {
                GameObjectManager.allCreatedEnemys[enemy].transform.GetChild(0).GetComponent<SpriteRenderer>().enabled =
                    false;
                print("enemy is not burning");
            }
        }
    }


    private IEnumerator FlashRedHalfSecond(Enemy enemy)
    {
        if(GameObjectManager.allCreatedEnemys.ContainsKey(enemy))
        {
            Color defaultColor = GameObjectManager.allCreatedEnemys[enemy].GetComponent<SpriteRenderer>().color;
            GameObjectManager.allCreatedEnemys[enemy].GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.5f);
            GameObjectManager.allCreatedEnemys[enemy].GetComponent<SpriteRenderer>().color = defaultColor;
        }
        
    }
    private IEnumerator ShakeEnemy(Enemy enemy)
    {
        Vector3 currentPos = GameObjectManager.allCreatedEnemys[enemy].gameObject.transform.position;
        for ( int i = 0; i < 5; i++)
        {
            GameObjectManager.allCreatedEnemys[enemy].gameObject.transform.localPosition += new Vector3(0.1f, 0, 0);
            yield return new WaitForSeconds(0.03f);
            GameObjectManager.allCreatedEnemys[enemy].gameObject.transform.localPosition -= new Vector3(0.1f, 0, 0);
            yield return new WaitForSeconds(0.03f);
        }

        GameObjectManager.allCreatedEnemys[enemy].gameObject.transform.position = currentPos;

    }
}
