using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public abstract class StateRoot : StateBase
{
    private Dictionary<Type, StateBase> _typeToState;
    public Dictionary<Type, StateBase> TypeToState => _typeToState;
    
    public override void Init(StateRoot store = null)
    {
        base.Init(store);
        
        var stateMembers = GetAllStateMembers<StateBase>();
        
        _typeToState = stateMembers
            .Where(x => x != null)
            .ToDictionary(x => x.GetType(), x => x);
        
        // Init
        stateMembers.ForEach(x => x?.Init(this));
    }

    private List<T> GetAllStateMembers<T>()
    {
        var fieldInfos = GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        
        var stateList = new List<T>();

        foreach (var fieldInfo in fieldInfos)
        {
            var fieldType = fieldInfo.FieldType;

            if (fieldType.IsSubclassOf(typeof(T)))
            {
                stateList.Add((T)fieldInfo.GetValue(this));
            }
            else if (fieldType.IsGenericType)
            {
                var genericDefinition = fieldType.GetGenericTypeDefinition();

                if (genericDefinition.IsAssignableFrom(typeof(List<>)))
                {
                    if (fieldInfo.GetValue(this) is IList<T> list)
                        stateList.AddRange(list);
                }
                else if (genericDefinition.IsAssignableFrom(typeof(Dictionary<,>)))
                {
                    var genericArguments = fieldType.GetGenericArguments();
                    
                    if (genericArguments[1].IsSubclassOf(typeof(T))
                        && fieldInfo.GetValue(this) is IDictionary dictionary)
                    {
                        stateList.AddRange(dictionary.Values.OfType<T>());   
                    }
                }
            }
        }
        return stateList;
    }
}
