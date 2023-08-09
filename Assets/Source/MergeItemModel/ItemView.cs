using UnityEngine;

public class ItemView : MonoBehaviour
{
    //temporary code
    public MergeItem MergeItem { get; private set; }

    public void Init(MergeItem mergeItem) => MergeItem = mergeItem;
}