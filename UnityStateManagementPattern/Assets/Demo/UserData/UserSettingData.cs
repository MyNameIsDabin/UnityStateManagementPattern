using System;
using Newtonsoft.Json;

[Serializable]
public class SettingDataEntity : IUserDataEntity
{
    public bool IsOnBgm = true;
    public bool IsOnSfx = true;
}

[Serializable]
public class UserSettingData : UserDataBase<SettingDataEntity>, IGlobalData
{
    [JsonIgnore]
    public bool IsOnBgm => entity.IsOnBgm;
    
    [JsonIgnore]
    public bool IsOnSfx => entity.IsOnSfx;
}
