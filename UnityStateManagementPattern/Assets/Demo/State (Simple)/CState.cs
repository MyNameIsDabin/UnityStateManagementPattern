public class CStateEntity : IDataState
{
    public double doubleValue;
}

public class CState : StateBase<CStateEntity>
{
    #region Getter
    
    public double DoubleValue => entity.doubleValue;
    
    #endregion
    
    #region Actions
    
    public void SetDoubleValue(double value)
    {
        entity.doubleValue = value;
    }
    
    #endregion
}