using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using UnityEngine.SceneManagement;

public class LocationManager : MonoBehaviour
{
    public MapPlayer mapPlayer;
    public static LocationManager Instance;
    private Dictionary<int, Location> allLocations = new Dictionary<int, Location>();
    public int StartingLocationID = 0;
    public RectTransform playerIcon;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Location location in Object.FindObjectsByType<Location>(FindObjectsSortMode.None))
        {
            if (!allLocations.ContainsKey(location.ID))
            {
                allLocations[location.ID] = location;
            }
        }
    }

    void Start()
    {
        mapPlayer = new MapPlayer(StartingLocationID, playerIcon, allLocations);
        
        foreach (Location location in allLocations.Values)
        {
            if (location.button != null)
            {
                location.button.interactable = false;
            }
        }

        if (allLocations.TryGetValue(StartingLocationID, out Location startLocation))
        {
            startLocation.button.interactable = true;
            EnableConnectedButtons(startLocation);
        }
    }

    public void ButtonClicked(Location clickedLocation)
    {
        mapPlayer.MovePlayerIcon(clickedLocation.ID);
        
        DisableAllButtons();
        
        clickedLocation.button.interactable = true;
        EnableConnectedButtons(clickedLocation);
        
        if (clickedLocation.sceneChanger != null)
            clickedLocation.sceneChanger.ChangeScene();
    }

    private void EnableConnectedButtons(Location Location)
    {
        foreach (int connectionID in Location.Connections)
        {
            if (allLocations.TryGetValue(connectionID, out Location connectedLocation))
            {
                if (connectedLocation.button != null)
                {
                    connectedLocation.button.interactable = true;
                    Debug.Log($"Enabled connected button: {connectionID}");
                }
            }
            else
            {
                Debug.LogWarning($"Connection ID {connectionID} not found for Location {Location.ID}");  
            }
        }
    }

    private void DisableAllButtons()
    {
        foreach (Location location in allLocations.Values)
        {
            Button button = location.button;
            if (button != null)
            {
                button.interactable = false;
            }
        }
    }
}
