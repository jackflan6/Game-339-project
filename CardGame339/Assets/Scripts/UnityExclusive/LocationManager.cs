using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using UnityEngine.SceneManagement;

public class LocationManager : MonoBehaviour
{
    public static LocationManager Instance;

    public MapPlayer mapPlayer;
    public RectTransform playerIcon;
    public int StartingLocationID = 0;

    private Dictionary<int, Location> allLocations = new Dictionary<int, Location>();
    private List<int> completedBattles = new List<int>();
    
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
        
        RebuildLocations();
        
        if (MapPlayer.Instance == null)
        {
            GameObject playerObj = new GameObject("MapPlayer");
            mapPlayer = playerObj.AddComponent<MapPlayer>();
            mapPlayer.Initialize(StartingLocationID, playerIcon, allLocations);
        }
        else
        {
            mapPlayer = MapPlayer.Instance;
            mapPlayer.SetPlayerIcon(playerIcon);
        }

        RefreshButtons();
    }

    private void Start()
    {
        if (mapPlayer == null)
        {
            if (MapPlayer.Instance == null)
            {
                GameObject playerObj = new GameObject("MapPlayer");
                mapPlayer = playerObj.AddComponent<MapPlayer>();
                mapPlayer.Initialize(StartingLocationID, playerIcon, allLocations);
            }
            else
            {
                mapPlayer = MapPlayer.Instance;
                mapPlayer.SetPlayerIcon(playerIcon);
            }
        }
        
        RefreshButtons();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Map")
        {
            SetupMapScene();
        }
    }
    
    public void ButtonClicked(Location clickedLocation)
    {
        mapPlayer.MovePlayerIcon(clickedLocation.ID);

        DisableAllButtons();

        clickedLocation.button.interactable = true;
        EnableConnectedButtons(clickedLocation);

        if (!completedBattles.Contains(clickedLocation.ID))
        {
            completedBattles.Add(clickedLocation.ID);
            
            if (clickedLocation.sceneChanger != null)
                clickedLocation.sceneChanger.ChangeSceneToSpecificScene(clickedLocation.sceneToLoad);
        }
    }

    public void SetupMapScene()
    {
        RebuildLocations();
        
        playerIcon = GameObject.Find("PlayerIcon")?.GetComponent<RectTransform>();
        if (playerIcon != null && mapPlayer != null)
        {
            mapPlayer.SetPlayerIcon(playerIcon);
            mapPlayer.MovePlayerIcon(mapPlayer.currentLocationID);
        }
        
        RefreshButtons();
        
    }

    public void RefreshMap()
    {
        SetupMapScene();
    }
    
    private void RebuildLocations()
    {
        allLocations.Clear();
        foreach (Location location in Object.FindObjectsByType<Location>(FindObjectsSortMode.None))
        {
            allLocations[location.ID] = location;
            location.button = location.GetComponent<Button>();
        }
    }

    private void RefreshButtons()
    {
        DisableAllButtons();

        if (mapPlayer != null && allLocations.TryGetValue(mapPlayer.currentLocationID, out Location currentLocation))
        {
            if (currentLocation.button != null)
                currentLocation.button.interactable = true;

            EnableConnectedButtons(currentLocation);
        }
    }

    private void EnableConnectedButtons(Location location)
    {
        foreach (int connectionID in location.Connections)
        {
            if (allLocations.TryGetValue(connectionID, out Location connectedLocation))
            {
                if (connectedLocation.button != null)
                {
                    connectedLocation.button.interactable = true;
                    ManagerManager.Resolve<IGameLogger>().print($"Enabled connected button: {connectionID}");
                }
            }
            else
            {
                ManagerManager.Resolve<IGameLogger>().Warning($"Connection ID {connectionID} not found for Location {location.ID}");
            }
        }
    }

    private void DisableAllButtons()
    {
        foreach (Location location in allLocations.Values)
        {
            if (location.button != null)
                location.button.interactable = false;
        }
    }

    public void ResetLocation()
    {
        completedBattles.Clear();
    }
}
