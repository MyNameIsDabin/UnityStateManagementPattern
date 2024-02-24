using UnityEngine;

public class StateDemo : MonoBehaviour
{
    void Start()
    {
        Store.Init(new DemoState());

        var aState = Store.GetState<AState>();
        Debug.Log($"aState Value : {aState.stringValue}");
        
        var bState = Store.GetState<BState>();
        Debug.Log($"bState Value : {bState.intValue}");
        
        var cState = Store.GetState<CState>();
        cState.SetDoubleValue(20.34);
    }
}
