using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealthUI : MonoBehaviour
{
    void Start()
    {
        GetComponentInParent<SelectableEnemy>().origionalEnemy.HP.sub(changeVal);
    } 

    public void changeVal(int health)
    {
        GetComponent<TextMeshPro>().text = "HP: " + health;
    }
}
