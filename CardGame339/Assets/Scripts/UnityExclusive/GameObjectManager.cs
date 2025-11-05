using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> CardPrefabList;
    public static List<GameObject> staticCardPrefabList = new List<GameObject>(); 
    private static List<GameObject> allCreatedCards = new List<GameObject>();

    [SerializeReference]
    public List<GameObject> EnemyPrefabList;
    private static List<GameObject> staticEnemyPrefabList;
    public static Dictionary<Enemy,GameObject> allCreatedEnemys = new Dictionary<Enemy,GameObject>();

    public Canvas canvas;


    public void OnDestroy()
    {
        allCreatedEnemys = new Dictionary<Enemy, GameObject>(); 
        allCreatedCards = new List<GameObject>();
    }
    public void UpdateCardPos()
    {
       int i = 0;
       foreach (GameObject card in allCreatedCards)
       {
           i++;
           card.GetComponent<SelectableCard>().cardPosition = new Vector2(5f - 2.5f * i, -2.5f);
       }

    }

    private void Start()
    {
        staticCardPrefabList = CardPrefabList;
        staticEnemyPrefabList = EnemyPrefabList;

        ManagerManager.Resolve<CardManager>().CardDraw += createCard;
        ManagerManager.Resolve<CardManager>().CardPlayed += DestroyCard;
        ManagerManager.Resolve<EnemyManager>().enemyAdded += createEnemy;
        ManagerManager.Resolve<EnemyManager>().enemyRemoved += DestroyEnemy;
    }


    public void createCard(Card card)
    {
        Debug.Log("created card");
        GameObject c = Instantiate(CardToPrefab.Value[card.GetType()]);
        //c.transform.SetParent(canvas.transform, true);
        allCreatedCards.Add(c);
        c.GetComponent<SelectableCard>().origionalCard = card;
        UpdateCardPos();
    }
    public void UpdateEnemyPos()
    {
        int i = 0;
        foreach (GameObject enemy in allCreatedEnemys.Values)
        {
            i++;
            enemy.GetComponent<SelectableEnemy>().EnemyPosition = new Vector2(6f - 4f * i, 2f);
        }

    }

    public void DestroyCard(Card card)
    {

        foreach (GameObject obj in allCreatedCards)
        {
            if (obj.GetComponent<SelectableCard>().origionalCard == card)
            {
                allCreatedCards.Remove(obj);
                Destroy(obj);
                UpdateCardPos();
                return;
            }
        }
    }

    public void createEnemy(Enemy enemy)
    {
        Debug.Log("created enemy");
        GameObject c = Instantiate(EnemyToPrefab.Value[enemy.GetType()]);
        allCreatedEnemys.Add(enemy,c);
        c.GetComponent<SelectableEnemy>().origionalEnemy = enemy;
        UpdateEnemyPos();
    }

    public void DestroyEnemy(Enemy enemy)
    {
        Destroy(allCreatedEnemys[enemy]);
        allCreatedEnemys.Remove(enemy);
    }
    [Serializable]
    private class PrefabAndName
    {
        public Card card;
        public GameObject prefab;
    }

    public Lazy<Dictionary<Type, GameObject>> CardToPrefab = new Lazy<Dictionary<Type, GameObject>>(() => {
        Dictionary<Type, GameObject> dic = new Dictionary<Type, GameObject>();

        Dictionary<int, Type> idToTypes = ManagerManager.Resolve<CardManager>().GetAllCardIDs.Value;

        foreach (GameObject obj in staticCardPrefabList)
        {
            dic.TryAdd(idToTypes[obj.GetComponent<SelectableCard>().cardID], obj);
        }
        return dic;
    });
    public Lazy<Dictionary<Type, GameObject>> EnemyToPrefab = new Lazy<Dictionary<Type, GameObject>>(() => {
        Dictionary<Type, GameObject> dic = new Dictionary<Type, GameObject>();

        Dictionary<int, Type> idToTypes = ManagerManager.Resolve<EnemyManager>().GetAllEnemyIDs.Value;

        foreach (GameObject obj in staticEnemyPrefabList)
        {
            if (!dic.TryAdd(idToTypes[obj.GetComponent<SelectableEnemy>().enemyID], obj))
            {
                Debug.Log("failed to find id for " + obj.name);
            }
        }
        return dic;
    });
}


