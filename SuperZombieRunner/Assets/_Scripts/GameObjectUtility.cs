using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameObjectUtility
{
    static Dictionary<RecycleGameObject, ObjectPool> _pools = new Dictionary<RecycleGameObject, ObjectPool>();

    static public GameObject Instantiate(GameObject prefab, Vector3 position)
    {
        var recycledScript = prefab.GetComponent<RecycleGameObject>();
        if (recycledScript != null)
        {
            var pool = GetObjectPool(recycledScript);
            return pool.NextObject(position).gameObject;
        }

        var instance = GameObject.Instantiate(prefab);
        instance.transform.position = position;

        return instance;
    }

    static public void Destroy(GameObject instance)
    {
        var recycleScript = instance.GetComponent<RecycleGameObject>();
        if (recycleScript != null)
            recycleScript.Shutdown();
        else
            GameObject.Destroy(instance);
    }

    static ObjectPool GetObjectPool(RecycleGameObject instance)
    {
        if (_pools.ContainsKey(instance))
            return _pools[instance];
        else
        {
            var poolContainer = new GameObject(instance.gameObject.name + "ObjectPool");
            var pool = poolContainer.AddComponent<ObjectPool>();

            pool.prefab = instance;

            _pools.Add(instance, pool);

            return pool;
        }
    }
}