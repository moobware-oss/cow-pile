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

    private GameState _gameState = GameState.PlayerControl;

    void Start()
    {
        SetGravity();

        SpawnCow();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SpawnCow();
        }
        SetGravity();
    }

    void SetGravity()
    {
        Physics.gravity = Gravity;
    }

    private void SpawnCow()
    {
        var newCow = Instantiate(CowPoses[Random.RandomRange(0, CowPoses.Count)]);
        newCow.transform.position = CowSpawn.position;
    }
}
