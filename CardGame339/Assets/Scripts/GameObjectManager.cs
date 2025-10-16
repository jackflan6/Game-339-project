using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    //[SerializeRefeance]
    [SerializeField]
    public List<GameObject> CardPrefabList;
    public static List<GameObject> staticCardPrefabList = new List<GameObject>(); 
    private static List<GameObject> allCreatedCards = new List<GameObject>();

    public Lazy<Dictionary<Type, GameObject>> CardToPrefab = new Lazy<Dictionary<Type, GameObject>>(() => { 

        Dictionary < Type, GameObject > dic = new Dictionary<Type, GameObject>();

        Dictionary<int, Type> idToTypes = ManagerManager.Resolve<CardManager>().GetAllCardIDs.Value;

        foreach (GameObject obj in staticCardPrefabList)
        {
            dic.TryAdd(idToTypes[obj.GetComponent<SelectableCard>().cardID], obj);
        }
        return dic;
    });

    public void UpdateCardPos()
    {
       int i = 0;
       foreach (GameObject card in allCreatedCards)
        {
            i++;
            card.GetComponent<SelectableCard>().cardPosition = new Vector2(2.5f - 2.5f * i, -2.5f);
        }
    }

    private void Start()
    {
        staticCardPrefabList = CardPrefabList;

        ManagerManager.Resolve<CardManager>().CardDraw += createCard;
        ManagerManager.Resolve<CardManager>().CardPlayed += DestroyCard;
        GameObject.FindGameObjectWithTag("ServiceResolver").GetComponent<ServiceResolver>().gameObjectManager = this;

    }
    public void createCard(Card card)
    {
        Debug.Log("created card");
        GameObject c = Instantiate(CardToPrefab.Value[card.GetType()]);
        allCreatedCards.Add(c);
        c.GetComponent<SelectableCard>().origionalCard = card;
        UpdateCardPos();
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

    [Serializable]
    private class PrefabAndName
    {
        public Card card;
        public GameObject prefab;
    }

}


