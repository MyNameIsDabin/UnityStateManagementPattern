using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

public abstract class UserDataRoot : UserDataBase
{
    [JsonIgnore] private bool _isDirty;
    
    [JsonIgnore] public bool IsDirty => _isDirty;
    
    [JsonIgnore] private Dictionary<Type, UserDataBase> _typeToUserData = new();
    [JsonIgnore] public Dictionary<Type, UserDataBase> TypeToUserData => _typeToUserData;
    
    public override void Init(UserDataRoot root = null)
    {
        base.Init(root);
        
        var userDataMembers = GetAllUserDataMembers();
        
        foreach (var userDataMember in userDataMembers)
            _typeToUserData.TryAdd(userDataMember.GetType(), userDataMember);
        
        // Init
        userDataMembers.ForEach(x => x?.Init(this));
        
        // Load
        userDataMembers.ForEach(x => x?.Load(this));
    }

    private List<UserDataBase> GetAllUserDataMembers()
    {
        var fieldInfos = GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
            .Where(x => x.IsPublic || x.GetCustomAttribute<JsonPropertyAttribute>(true) is not null);
        
        var userDataList = new List<UserDataBase>();

        foreach (var fieldInfo in fieldInfos)
        {
            var fieldType = fieldInfo.FieldType;

            if (fieldType.IsSubclassOf(typeof(UserDataBase)))
            {
                userDataList.Add(fieldInfo.GetValue(this) as UserDataBase);
            }
            else if (fieldType.IsGenericType)
            {
                var genericDefinition = fieldType.GetGenericTypeDefinition();

                if (genericDefinition.IsAssignableFrom(typeof(List<>)))
                {
                    if (fieldInfo.GetValue(this) is IList<UserDataBase> list)
                        userDataList.AddRange(list);
                }
                else if (genericDefinition.IsAssignableFrom(typeof(Dictionary<,>)))
                {
                    var genericArguments = fieldType.GetGenericArguments();
                    
                    if (genericArguments[1].IsSubclassOf(typeof(UserDataBase))
                        && fieldInfo.GetValue(this) is IDictionary dictionary)
                    {
                        userDataList.AddRange(dictionary.Values.OfType<UserDataBase>());   
                    }
                }
            }
        }
        return userDataList;
    }

    public void SetDirty(bool isDirty)
    {
        _isDirty = isDirty;
    }
}
