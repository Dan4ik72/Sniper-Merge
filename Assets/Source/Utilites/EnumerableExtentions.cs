using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnumerableExtentions
{
    public static void Foreach<TSource>(this List<TSource> source, Action<TSource> action)
    {
        foreach (var element in source) 
            action?.Invoke(element);
    }
}
