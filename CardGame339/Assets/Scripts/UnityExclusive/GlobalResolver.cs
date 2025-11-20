using ConsoleApp1;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalResolver : MonoBehaviour
{
    public bool loaded;
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
        ManagerManager.registerPersistent((IRandom)new UnityRandom());
        ManagerManager.registerPersistent((IGameLogger)(new UnityGameLogger()));
        ManagerManager.registerPersistentDependency(() => new Inventory());
        ManagerManager.registerPersistentDependency(()=> new CurrencyManager());
        ManagerManager.registerPersistentDependency(() => new GachaManager());
    }
    private void Start()
    {
        loaded = true;
    }

}
