
public class DemoState : StateRoot
{
    public AState aState { get; set; } = new();
    public BState bState { get; set; } = new();
    public CState cState { get; set; } = new();
}