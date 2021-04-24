using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerMove : PlayerBase
{
    private Rigidbody _rigidbody;
    private Vector3 _direction = Vector3.zero;

    private void Start()
    {
        try
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        catch (MissingComponentException)
        {
            Debug.Log("Missing RigidBody");
        }
    }
    public override void Move(float x, float y, float z)
    {
        _rigidbody.AddForce(new Vector3(x, y, z) * Speed);
    }

}
