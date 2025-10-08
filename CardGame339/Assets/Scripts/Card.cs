using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Cards/CardData")]
public class Card : ScriptableObject
{
    public Sprite sprite;
    public string CardType;
    public string Name;
    public int ManaValue;
    
}
