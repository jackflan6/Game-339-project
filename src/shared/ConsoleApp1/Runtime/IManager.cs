
public interface IManager
{
    public IGameLogger logger { get; }
    public void Start();
    public void Awake();
    public void Update();
}
