using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecycleGameObject : MonoBehaviour
{
    List<IRecycle> _recycleComponents = new List<IRecycle>();

    void Awake()
    {
        var components = GetComponents<MonoBehaviour>();
        foreach (var component in components)
        {
            if (component is IRecycle)
                _recycleComponents.Add((IRecycle)component);
        }
    }

    public void Restart()
    {
        foreach(var component in _recycleComponents)
            component.Restart();
    }

    public void Shutdown()
    {
        foreach (var component in _recycleComponents)
            component.Shutdown();
    }
}
