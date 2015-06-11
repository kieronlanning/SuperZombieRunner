using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, IRecycle
{
    public void Restart()
    {
        gameObject.SetActive(true);
    }

    public void Shutdown()
    {
        gameObject.SetActive(false);
    }
}