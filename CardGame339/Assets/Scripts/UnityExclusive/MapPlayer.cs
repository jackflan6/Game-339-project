using System.Collections.Generic;
using UnityEngine;

public class MapPlayer : MonoBehaviour
{
    public int currentLocationID;
    public List<Item> collectedItems = new List<Item>();
    private RectTransform playerIcon;
    private Dictionary<int, Location> allLocations;

    public MapPlayer(int startingLocationID, RectTransform icon, Dictionary<int, Location> locations)
    {
        currentLocationID = startingLocationID;
        playerIcon = icon;
        allLocations = locations;
        
        MovePlayerIcon(currentLocationID);
    }
    
    public void MovePlayerIcon(int locationID)
    {
        if (allLocations.TryGetValue(locationID, out Location location))
        {
            if (location.button != null)
            {
                playerIcon.position = location.button.transform.position;
                Debug.Log($"Moved PlayerIcon to Location ID {location.ID}");
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
}
