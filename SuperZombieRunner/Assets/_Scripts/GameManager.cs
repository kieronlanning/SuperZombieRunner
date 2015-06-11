using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;

    GameObject _player;
    GameObject _floor;
    Spawner _spawner;

    void Awake()
    {
        _floor = GameObject.Find("Foreground");
        _spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
    }

    void Start()
    {
        var floorHeight = _floor.transform.localScale.y;
        var pos = _floor.transform.position;

        pos.x = 0;
        pos.y = -((Screen.height/PixelPerfectCamera.pixelToUnits)/2) + (floorHeight / 2f);

        _floor.transform.position = pos;

        _spawner.active = false;

        ResetGame();
    }

    void ResetGame()
    {
        _spawner.active = true;
        _player = GameObjectUtility.Instantiate(playerPrefab, new Vector3(0, (Screen.height / PixelPerfectCamera.pixelToUnits) / 2, 0));

        var playerDestroyScript = _player.GetComponent<DestoryOffScreen>();
        playerDestroyScript.DestroyCallback += OnPlayerKilled;
    }

    void OnPlayerKilled()
    {
        _spawner.active = false;
        
        var playerDestroyScript = _player.GetComponent<DestoryOffScreen>();
        playerDestroyScript.DestroyCallback -= OnPlayerKilled;

        _player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
