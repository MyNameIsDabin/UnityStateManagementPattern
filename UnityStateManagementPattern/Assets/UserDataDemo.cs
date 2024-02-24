using UnityEngine;

public class UserDataDemo : MonoBehaviour
{
    void Start()
    {
        UserData.LoadData();

        var profileData = UserData.GetFromGlobal<UserProfileData>();
        var globalScore = UserData.GetFromGlobal<UserScoreData>();
        globalScore.AddScore(2);
        
        Debug.Log($"App Version : {profileData.AppVersion}");
        Debug.Log($"Global Score : {globalScore.Score}");
        
        var chapterData = UserData.GetFromCurrentChapter<UserScoreData>();
        chapterData.AddScore(10);
        
        Debug.Log($"Chapter Score : {chapterData.Score}");
        
        UserData.SaveData();
    }
}
