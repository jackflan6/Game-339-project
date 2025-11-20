using ConsoleApp1;
using UnityEngine;
using UnityEngine.UI;

public class UI_HP : MonoBehaviour
{
    public Image currentHealthBar;
    public Text healthText;
    public int health;
    public int maxHealth = 20;
    void Start()
    {
        ManagerManager.Resolve<Player>().HP.sub(UpdateValue);
        ManagerManager.Resolve<CurrencyManager>().maxPlayerHP.sub(UpdatedMaxHealth);
    }
    private void OnDestroy()
    {
        if (ManagerManager.Resolve<Player>() != null) {
            ManagerManager.Resolve<Player>().HP.ValueChanged -= UpdateValue;
        }
        if (ManagerManager.Resolve<CurrencyManager>() != null)
        {
            ManagerManager.Resolve<CurrencyManager>().maxPlayerHP.ValueChanged -= UpdatedMaxHealth;
        }
    }

    public void UpdateValue(int val)
    {
        //GetComponent<Text>().text = "HP: " + val.ToString();
        health = val;
        float ratio = Mathf.Min((float)val / (float)maxHealth,1);
        currentHealthBar.rectTransform.localPosition = new Vector3(currentHealthBar.rectTransform.rect.width * ratio - currentHealthBar.rectTransform.rect.width, 0, 0);
        healthText.text = health.ToString("0") + "/" + maxHealth.ToString("0");
    }
    public void UpdatedMaxHealth(int val)
    {
        maxHealth = val;
        float ratio = Mathf.Min((float)health / (float)maxHealth, 1);
        currentHealthBar.rectTransform.localPosition = new Vector3(currentHealthBar.rectTransform.rect.width * ratio - currentHealthBar.rectTransform.rect.width, 0, 0);
        healthText.text = health.ToString("0") + "/" + maxHealth.ToString("0");
    }

}
