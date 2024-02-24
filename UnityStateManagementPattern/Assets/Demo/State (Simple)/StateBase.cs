using Newtonsoft.Json;

public abstract class StateBase
{
    [JsonIgnore] protected StateRoot store;

    public virtual void Init(StateRoot store)
    {
        this.store = store;
    }
}

public abstract class StateBase<T> 
    : StateBase where T : IDataState, new()
{
    [JsonProperty] protected T entity = new();
}

public interface IDataState
{
}
