using ConsoleApp1;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName;

    public void ChangeScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
            ManagerManager.Resolve<IGameLogger>().Error("no scene to load.");
    }
    
    public void ChangeSceneToSpecificScene(string sceneToChangeTo)
    {
        if (!string.IsNullOrEmpty(sceneToChangeTo))
        {
            SceneManager.LoadScene(sceneToChangeTo);
        }
        else
            ManagerManager.Resolve<IGameLogger>().Error("no scene to load.");
    }

    public void TryAgain()
    {
        MapPlayer.Instance?.ResetPlayer();
        LocationManager.Instance?.ResetLocation();
        
        ChangeSceneToSpecificScene("Map");
    }
    
    public void TryAgainAfterVictory()
    {
        MapPlayer.Instance?.ResetPlayer();
        LocationManager.Instance?.ResetLocation();
        ManagerManager.Resolve<CurrencyManager>().maxPlayerHP = 20;
        ManagerManager.Resolve<CurrencyManager>().currencyAmount = 0;
        ManagerManager.Resolve<Inventory>().RemoveAllCardsInInventory();
        ManagerManager.Resolve<Inventory>().createInitialCards();
        
        ChangeSceneToSpecificScene("TitleScreen");
    }
    
    public void QuitGameButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    public void Restart()
    {
        GameObject[] everything = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject go in everything)
        {
            if (go != gameObject)
            {
                Destroy(go);
            }
        }
        sceneName = "Map";
        ChangeScene();
    }
}
