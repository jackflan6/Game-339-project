using UnityEngine;

public abstract class IManager
{
    public IGameLogger logger = ManagerManager.Resolve<IGameLogger>();
    public virtual void Start() { }
    public virtual void Awake() { }
    public virtual void Update() { }
}
