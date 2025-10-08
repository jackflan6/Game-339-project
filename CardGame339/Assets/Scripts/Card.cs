using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Cards/CardData")]
public class Card2 : ScriptableObject
{
    public Sprite sprite;
    public string CardType;
    public string Name;
    public int ManaValue;
    
}
public class Card : MonoBehaviour
{
    public string Element;
    public int Damage;
    public int ShieldValue;
    public int BurnDamage;
    public int Heal;
    public bool DrawCard;
    public int ManaCost;

    public Card(string element, int damage, int shieldValue, int burnDamage, int heal, int manaCost=1, bool drawCard=false)
    {
        Element = element;
        Damage = damage;
        ShieldValue = shieldValue;
        BurnDamage = burnDamage;
        Heal = heal;
        DrawCard = drawCard;
        ManaCost = manaCost;
    }

}
