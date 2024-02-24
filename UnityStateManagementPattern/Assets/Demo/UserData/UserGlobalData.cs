using System;
using System.Collections.Generic;
using Newtonsoft.Json;

[Serializable]
public class UserGlobalData : UserDataRoot
{
    [JsonProperty]
    private UserProfileData userProfileData = new();
    
    [JsonProperty]
    private UserSettingData userSettingData = new();

    [JsonProperty]
    private UserScoreData userScoreData = new();

    [JsonProperty] 
    private int currenctChapterId = 0;

    [JsonProperty] 
    private Dictionary<int, UserChapterData> chapterDataById = new()
    {
        [0] = new UserChapterData(),
        [1] = new UserChapterData(),
        [2] = new UserChapterData(),
    };

    #region Getter

    [JsonIgnore] 
    public UserChapterData CurrentChapter => chapterDataById[currenctChapterId];

    #endregion
}
