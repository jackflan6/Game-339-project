using System.Collections.Generic;
using UnityEngine;

public class MapPlayer : MonoBehaviour
{
    public static MapPlayer Instance;
    
    public int currentLocationID;
    public List<Item> collectedItems = new List<Item>();
    private RectTransform playerIcon;
    private Dictionary<int, Location> allLocations;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void Initialize(int startingLocationID, RectTransform icon, Dictionary<int, Location> locations)
    {
        currentLocationID = startingLocationID;
        playerIcon = icon;
        allLocations = locations;
        
        MovePlayerIcon(currentLocationID);
    }

    public void SetPlayerIcon(RectTransform icon)
    {
        playerIcon = icon;
        MovePlayerIcon(currentLocationID);
    }
    
    public void MovePlayerIcon(int locationID)
    {
        if (allLocations.TryGetValue(locationID, out Location location))
        {
            if (location.button != null)
            {
                playerIcon.position = location.button.transform.position;
                currentLocationID = locationID;
                ManagerManager.Resolve<IGameLogger>().print($"Moved PlayerIcon to Location ID {location.ID}");
            }
        }
    }

    public void CollectItems(List<Item> itemsAtLocation)
    {
        foreach (var item in itemsAtLocation)
        {
            if (item != null)
            {
                collectedItems.Add(item);
            }

            itemsAtLocation.Clear();
        }
    }

    public void ResetPlayer()
    {
        currentLocationID = 0;
        collectedItems.Clear();
    }
}
