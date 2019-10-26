using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    public Rigidbody BaseRigidBody;

    public float x;
    public float y;

    private bool _ragDoll = false;

    public void FixedUpdate()
    {
        if (!_ragDoll)
        {
            BaseRigidBody.velocity = new Vector3(x, y, BaseRigidBody.velocity.z);
        }
    }

    public void Move(bool left, bool right, bool fallFast, bool fallSlow)
    {
        Debug.Log("you called move with left: " + left);

        x = 0f;
        y = -1f;

        if (left)
        {
            x = -1;
        }
        else if (right)
        {
            x = 1;
        }

        if (fallFast)
        {
            y = -2;
        }
        else if (fallSlow)
        {
            y = -0.5f;
        }
    }

    public void RagDoll()
    {
        _ragDoll = true;
    }
}
