public static class Store
{
    private static StateRoot _root;
    
    public static void Init(StateRoot root)
    {
        _root = root;
        _root.Init();
    }

    public static T GetState<T>() where T : StateBase
    {
        return _root.TypeToState[typeof(T)] as T;
    }
}
