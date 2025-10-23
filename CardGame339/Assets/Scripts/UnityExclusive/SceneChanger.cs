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
}
