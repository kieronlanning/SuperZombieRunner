using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public RecycleGameObject prefab;

    List<RecycleGameObject> _poolInstances = new List<RecycleGameObject>();

    RecycleGameObject CreateInstance(Vector3 position)
    {
        var clone = GameObject.Instantiate(prefab);
        clone.transform.position = position;
        clone.transform.parent = transform;

        _poolInstances.Add(clone);

        return clone;
    }

    public RecycleGameObject NextObject(Vector3 position)
    {
        RecycleGameObject instance = null;
        foreach (var go in _poolInstances)
        {
            if (!go.gameObject.activeSelf)
            {
                instance = go;
                instance.transform.position = position;
                break;
            }
        }

        if (instance == null)
            instance = CreateInstance(position);
        
        instance.Restart();

        return instance;
    }
}
