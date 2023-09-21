using UnityEngine;

internal class LevelViewFactory
{
    private LevelView _prefab;
    private Transform _viewParent;
    
    public LevelViewFactory(LevelView prefab, Transform viewParent)
    {
        _prefab = prefab;
        _viewParent = viewParent;
    }

    public LevelView Create(uint levelIndex, bool isLocked)
    {
        LevelView created =  Object.Instantiate(_prefab, _viewParent);
        
        created.Construct((int)levelIndex, isLocked);
        
        return created;
    }
}