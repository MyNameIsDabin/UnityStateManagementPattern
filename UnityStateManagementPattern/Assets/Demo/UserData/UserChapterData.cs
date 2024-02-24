using System;
using Newtonsoft.Json;

[Serializable]
public class UserChapterData : UserDataRoot, IGlobalData
{
    [JsonProperty] 
    private UserScoreData userScoreData = new();
}
