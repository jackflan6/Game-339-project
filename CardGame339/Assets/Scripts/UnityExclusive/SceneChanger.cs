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
            print("no scene to load.");
    }
    
    public void ChangeSceneToSpecificScene(string sceneToChangeTo)
    {
        if (!string.IsNullOrEmpty(sceneToChangeTo))
        {
            SceneManager.LoadScene(sceneToChangeTo);
        }
        else
            print("no scene to load.");
    }

    public void TryAgain()
    {
        MapPlayer.Instance?.ResetPlayer();
        LocationManager.Instance?.ResetLocation();
        
        ChangeSceneToSpecificScene("Map");
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
