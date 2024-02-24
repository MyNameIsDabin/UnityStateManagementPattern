using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public static class UserData
{
    private static readonly string SaveFilePath = Application.persistentDataPath + "/UserData.json";
    
    private static UserGlobalData _global = new();
    public static UserGlobalData Global => _global;
    
    public static void SaveData()
    {
        File.WriteAllText(SaveFilePath, JsonConvert.SerializeObject(_global));
    }

    public static void LoadData()
    {
        if (File.Exists(SaveFilePath))
            _global = JsonConvert.DeserializeObject<UserGlobalData>(File.ReadAllText(SaveFilePath));
        _global.Init();
        SaveData();
    }

    public static T GetFromGlobal<T>() where T : UserDataBase, IGlobalData
        => _global.TypeToUserData[typeof(T)] as T;
    
    public static (T1, T2) GetFromGlobal<T1, T2>()
        where T1 : UserDataBase, IGlobalData
        where T2 : UserDataBase, IGlobalData
        => (GetFromGlobal<T1>(), GetFromGlobal<T2>());

    public static T GetFromCurrentChapter<T>() where T : UserDataBase, IChapterData
        => _global.CurrentChapter.TypeToUserData[typeof(T)] as T;
    
    public static (T1, T2) GetFromCurrentChapter<T1, T2>()
        where T1 : UserDataBase, IChapterData
        where T2 : UserDataBase, IChapterData
        => (GetFromCurrentChapter<T1>(), GetFromCurrentChapter<T2>());
}
