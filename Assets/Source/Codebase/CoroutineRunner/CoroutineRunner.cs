using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineRunner : MonoBehaviour
{
    private static CoroutineRunner _objectInstance;

    private static CoroutineRunner _instance
    {
        get
        {
            if (_objectInstance == null)
            {
                var gameObject = new GameObject("[COROUTINE INVOKER]");
                _objectInstance = gameObject.AddComponent<CoroutineRunner>();
                DontDestroyOnLoad(_objectInstance.gameObject);
            }

            return _objectInstance;
        }
    }

    public static Coroutine StartRoutine(IEnumerator routine)
    {
        return _instance.StartCoroutine(routine);
    }

    public static void StopRoutine(Coroutine routine)
    {
        _instance.StopCoroutine(routine);
    }
}
