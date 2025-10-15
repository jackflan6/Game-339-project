using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    public Dictionary<Type,GameObject> CardToPrefab;
    //[SerializeRefeance]
    [SerializeReference]
    private ICard f;
    private List<ICard> prefabAndNameList;

    private void Awake()
    {
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


