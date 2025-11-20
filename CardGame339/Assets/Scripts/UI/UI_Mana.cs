using UnityEngine;
using UnityEngine.UI;

public class UI_Mana : MonoBehaviour
{
    public Image currentManaGlobe;
    public Text ManaText;
    public int mana;
    public int maxMana = 10;
    void Start()
    {
        ManagerManager.Resolve<TurnSystem>().currentMana.ValueChanged += UpdateValue;
        UpdateValue(ManagerManager.Resolve<TurnSystem>().currentMana.Value);
        maxMana = ManagerManager.Resolve<TurnSystem>().MaxMana;
    }

    public void UpdateValue(int val)
    {
        mana = val;
        float ratio = (float)val / (float)maxMana;
        currentManaGlobe.rectTransform.localPosition = new Vector3(0, currentManaGlobe.rectTransform.rect.height * ratio - currentManaGlobe.rectTransform.rect.height, 0);
        ManaText.text = mana.ToString("0") + "/" + maxMana.ToString("0");
    }
}
