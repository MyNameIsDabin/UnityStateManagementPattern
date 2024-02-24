using System;
using Newtonsoft.Json;

[Serializable]
public class CurrencyDataEntity : IUserDataEntity
{
    public long score;
}

[Serializable]
public class UserScoreData : UserDataBase<CurrencyDataEntity>, IGlobalData, IChapterData
{
    #region Getter
    
    [JsonIgnore]
    public long Score => entity.score;
    
    #endregion

    #region Actions
    
    public void AddScore(long amount)
    {
        entity.score += amount;
    }
    
    #endregion
}