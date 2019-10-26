using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool GravityEnabled;
    private Vector3 _originalGravity;

    // Start is called before the first frame update
    void Awake()
    {
        _originalGravity = Physics.gravity;
        SetGravity();
    }

    // Update is called once per frame
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
}
