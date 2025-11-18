using ConsoleApp1;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalResolver : MonoBehaviour
{
    public bool loaded;
    public UnityGameLogger unityLogger;
    public UnityRandom unityRandom;
    public SceneChanger sceneChanger;
    public LocationManager locationManager;

    public bool hasShownShopDialogue=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("GlobalResolver").Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        ManagerManager.registerPersistent(sceneChanger);
        ManagerManager.registerPersistent(locationManager);
        ManagerManager.registerPersistent((IGameLogger)unityLogger);
        ManagerManager.registerPersistent((IRandom)unityRandom);
        ManagerManager.registerPersistentDependency(() => new Inventory());
        ManagerManager.registerPersistentDependency(()=> new CurrencyManager());
        ManagerManager.registerPersistentDependency(() => new GachaManager());
    }
    private void Start()
    {
        loaded = true;
    }

}
