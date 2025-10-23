using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class Location : MonoBehaviour
    {
        public int ID;
        public List<int> Connections;
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
    }