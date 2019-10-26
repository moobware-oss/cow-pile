using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    enum GameState { PlayerControl, CowFreeFall, GameOver };

    public Vector3 Gravity;
    public Transform CowSpawn;
    public List<GameObject> CowPoses;
    public bool GravityEnabled;

    public  Cow _currentCow;

    private GameState _gameState = GameState.PlayerControl;

    void Start()
    {
        SetGravity();

        SpawnCow();
    }

    void Update()
    {
        var left = false;
        var right = false;
        var fallFast = false;
        var fallSlow = false;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnCow();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            left = true;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            right = true;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            fallSlow = true;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            fallFast = true;
        }

        if (_currentCow != null)
        {
            _currentCow.Move(left, right, fallFast, fallSlow);
        }

        SetGravity();
    }

    void SetGravity()
    {
        Physics.gravity = Gravity;
    }

    private void SpawnCow()
    {
        if (_currentCow != null)
        {
            _currentCow.RagDoll();
        }
        var newCow = Instantiate(CowPoses[Random.Range(0, CowPoses.Count)]);
        newCow.transform.position = CowSpawn.position;
        _currentCow = newCow.GetComponent<Cow>();
    }
}
