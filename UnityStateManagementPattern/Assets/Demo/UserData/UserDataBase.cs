using Newtonsoft.Json;

public abstract class UserDataBase
{
    [JsonIgnore] protected UserDataRoot root;

    public virtual void Init(UserDataRoot root)
    {
        this.root = root;
    }

    public virtual void Load(UserDataRoot root)
    {
        
    }
}

public abstract class UserDataBase<T> : UserDataBase where T : IUserDataEntity, new()
{
    [JsonProperty] protected T entity = new();
}

public interface IUserDataEntity
{

}