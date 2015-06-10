using UnityEngine;
using System.Collections;

public class GameObjectUtility
{
    static public GameObject Instantiate(GameObject prefab, Vector3 position)
    {
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
}