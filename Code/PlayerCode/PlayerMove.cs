using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerMove : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _direction = Vector3.zero;
    [SerializeField] public float _speed = 1000;
    public float Speed
    {
        internal get => _speed;
        set
        {
            if (value > 0)
            {
                _speed = value;
            }
        }
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        _rb.AddForce(_direction * _speed);
    }
}
