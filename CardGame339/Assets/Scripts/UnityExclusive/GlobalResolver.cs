using ConsoleApp1;
using UnityEngine;

public class GlobalResolver : MonoBehaviour
{

    public UnityGameLogger unityLogger;
    public UnityRandom unityRandom;
    public SceneChanger sceneChanger;
    public LocationManager locationManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        ManagerManager.register(sceneChanger);
        ManagerManager.register(locationManager);
        ManagerManager.register((IGameLogger)unityLogger);
        ManagerManager.register((IRandom)unityRandom);
        ManagerManager.registerPersistentDependency(() => new Inventory());
        //ManagerManager.registerPersistentDependency();
    }

}
