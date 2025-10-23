using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class Location : MonoBehaviour
    {
        public int ID;
        public List<int> Connections;
        public List<Item> ItemsAtLocation;
        public Button button;
        public SceneChanger sceneChanger;
        public string sceneToLoad;

        private void Awake()
        {
            button = GetComponent<Button>();
        }
        
        public void OnButtonPressed()
        {
            if (LocationManager.Instance != null)
            {
                LocationManager.Instance.ButtonClicked(this);
            }
        }

        public void RemoveItem(Item item)
        {
            if (ItemsAtLocation.Contains(item))
                ItemsAtLocation.Remove(item);
        }
    }