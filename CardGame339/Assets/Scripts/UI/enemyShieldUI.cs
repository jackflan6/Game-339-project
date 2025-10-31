using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class enemyShieldUI : MonoBehaviour
{
    void Start()
    {
        GetComponentInParent<SelectableEnemy>().origionalEnemy.currentShield.sub(changeVal);
    } 

    public void changeVal(int shield)
    {
        GetComponent<TextMeshPro>().text = "Shield: " + shield;
    }
}
