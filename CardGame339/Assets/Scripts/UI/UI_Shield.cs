using UnityEngine;
using UnityEngine.UI;

public class UI_Shield : MonoBehaviour
{
    void Start()
    {
        ManagerManager.Resolve<Player>().currentShield.ValueChanged += UpdateValue;
        UpdateValue(ManagerManager.Resolve<Player>().currentShield.Value);
    }

    public void UpdateValue(int val)
    {
        GetComponent<Text>().text = "Shield: " + val.ToString();
    }
}
