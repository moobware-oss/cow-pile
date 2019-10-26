using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    enum GameState { PlayerControl, CowFreeFall, GameOver };

    public Transform CowSpawn;
    public List<GameObject> CowPoses;
    public bool GravityEnabled;
    private Vector3 _originalGravity;
    private GameState _gameState = GameState.PlayerControl;

    void Start()
    {
        _originalGravity = Physics.gravity;
        SetGravity();


        var newCow = Instantiate(CowPoses[Random.RandomRange(0, CowPoses.Count)]);
        newCow.transform.position = CowSpawn.position;
    }

    void Update()
    {
        SetGravity();
    }

    void SetGravity()
    {
        if (GravityEnabled && Physics.gravity != _originalGravity)
        {
            Physics.gravity = _originalGravity;
        }
        else
        {
            Physics.gravity = Vector3.zero;
        }
    }

    private void PinTheBase()
    {

    }
}
