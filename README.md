# UnityStateManagementPattern
유니티에서 쉽게 상태를 관리하는 패턴에 대한 고민을 다룬 저장소 입니다.
여러 패턴을 시도해보고 가장 사용하면서 만족스러웠던 패턴을 기반으로 작성된 Demo 입니다. 
주요 장점으로는 데이터를 클래스 단위로 그룹화 하면서 서비스 로케이터 패턴으로 어디서든 쉽게 데이터를 전달받을 수 있습니다.
유저 데이터를 중개하는 부분에 대한 컨셉은 [Pinia](https://pinia.vuejs.org/core-concepts/#Destructuring-from-a-Store)에서 많은 부분 영감을 받았습니다.


```
using UnityEngine;

public class StateDemo : MonoBehaviour
{
    void Start()
    {
        Store.Init(new DemoState());

        var aState = Store.GetState<AState>();
        Debug.Log($"aState Value : {aState.stringValue}");
        
        var bState = Store.GetState<BState>();
        Debug.Log($"bState Value : {bState.intValue}");
        
        var cState = Store.GetState<CState>();
        cState.SetDoubleValue(20.34);
    }
}
```

유저 데이터 상태 관리 활용 (챕터형 게임에도 적합)
```
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
```
