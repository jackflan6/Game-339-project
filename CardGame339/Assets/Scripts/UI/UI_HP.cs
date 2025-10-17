using UnityEngine;
using UnityEngine.UI;

public class UI_HP : MonoBehaviour
{
    void Start()
    {
        ManagerManager.Resolve<Player>().HP.ValueChanged += UpdateValue;
        UpdateValue(ManagerManager.Resolve<Player>().HP.Value);
    }

    public void UpdateValue(int val)
    {
        GetComponent<Text>().text = "HP: " + val.ToString();
    }

}
