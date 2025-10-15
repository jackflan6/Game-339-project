using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    //[SerializeRefeance]
    [SerializeReference]
    private static List<GameObject> CardPrefabList;
    

    public Lazy<Dictionary<Type, GameObject>> CardToPrefab = new Lazy<Dictionary<Type, GameObject>>(() => { 
        Dictionary < Type, GameObject > dic = new Dictionary<Type, GameObject>();
        Dictionary<int, Type> idToTypes = ManagerManager.Resolve<CardManager>().GetAllCardIDs.Value;
        foreach (GameObject obj in CardPrefabList)
        {
            dic.TryAdd(idToTypes[obj.GetComponent<SelectableCard>().cardId], obj);
        }
        return dic;
    });

    private void Awake()
    {
        ManagerManager.Resolve<CardManager>().CardDraw += createCard;
    }
    public void createCard(Card card)
    {
        
    }


    [Serializable]
    private class PrefabAndName
    {
        public Card card;
        public GameObject prefab;
    }

}


