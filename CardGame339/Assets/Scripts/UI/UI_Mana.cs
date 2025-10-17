using UnityEngine;
using UnityEngine.UI;

public class UI_Mana : MonoBehaviour
{
    void Start()
    {
        ManagerManager.Resolve<TurnSystem>().currentMana.ValueChanged += UpdateValue;
        UpdateValue(ManagerManager.Resolve<TurnSystem>().currentMana.Value);
    }

    public void UpdateValue(int val)
    {
        GetComponent<Text>().text = "Mana: " + val.ToString();
    }
}
