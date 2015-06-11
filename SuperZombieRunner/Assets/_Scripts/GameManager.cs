using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;

    bool _gameStarted;
    TimeManager _timeManager;
    GameObject _player;
    GameObject _floor;
    Spawner _spawner;

    void Awake()
    {
        _floor = GameObject.Find("Foreground");
        _spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        _timeManager = GetComponent<TimeManager>();
    }

    void Start()
    {
        var floorHeight = _floor.transform.localScale.y;
        var pos = _floor.transform.position;

        pos.x = 0;
        pos.y = -((Screen.height/PixelPerfectCamera.pixelToUnits)/2) + (floorHeight / 2f);

        _floor.transform.position = pos;

        _spawner.active = false;

        Time.timeScale = 0f;
    }

    void Update()
    {
        if (!_gameStarted && Time.timeScale == 0f)
        {
            if (Input.anyKeyDown)
            {
                _timeManager.ManipulateTime(1f, 1f);
                ResetGame();
            }
        }
    }

    void ResetGame()
    {
        _spawner.active = true;
        _player = GameObjectUtility.Instantiate(playerPrefab, new Vector3(0, ((Screen.height / PixelPerfectCamera.pixelToUnits) / 2) + 100, 0));

        var playerDestroyScript = _player.GetComponent<DestoryOffScreen>();
        playerDestroyScript.DestroyCallback += OnPlayerKilled;

        _gameStarted = true;
    }

    void OnPlayerKilled()
    {
        _spawner.active = false;
        
        var playerDestroyScript = _player.GetComponent<DestoryOffScreen>();
        playerDestroyScript.DestroyCallback -= OnPlayerKilled;

        _player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        _timeManager.ManipulateTime(0, 5.5f);

        _gameStarted = false;
    }
}
