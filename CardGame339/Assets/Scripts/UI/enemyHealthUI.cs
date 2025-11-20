using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealthUI : MonoBehaviour
{
    public Image currentHealthBar;
    public Text healthText;
    public int health;
    public int maxHealth;
    void Start()
    {
        maxHealth = GetComponentInParent<SelectableEnemy>().origionalEnemy.HP.Value;
        GetComponentInParent<SelectableEnemy>().origionalEnemy.HP.sub(UpdateValue);
    } 

    public void UpdateValue(int val)
    {
        //GetComponent<Text>().text = "HP: " + val.ToString();
        health = val;
        float ratio = (float)val / (float)maxHealth;
        //Debug.Log(ratio + " " + val + " " + maxHealth);
        currentHealthBar.rectTransform.localPosition = new Vector3(currentHealthBar.rectTransform.rect.width * ratio - currentHealthBar.rectTransform.rect.width, 0, 0);
        healthText.text = health.ToString("0") + "/" + maxHealth.ToString("0");
    }
}
