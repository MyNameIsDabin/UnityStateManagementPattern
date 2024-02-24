using System;
using Newtonsoft.Json;

[Serializable]
public class ProfileDataEntity : IUserDataEntity
{
    public string appVersion;
}

[Serializable]
public class UserProfileData : UserDataBase<ProfileDataEntity>, IGlobalData
{
    #region Getter
    
    [JsonIgnore]
    public string AppVersion => entity.appVersion;
    
    #endregion
    
    public override void Init(UserDataRoot root)
    {
        entity.appVersion = UnityEngine.Application.version;
    }
}
