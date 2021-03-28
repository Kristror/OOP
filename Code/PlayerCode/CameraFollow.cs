using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 _offSet;

    private void Start()
    {
        _offSet = transform.position - player.transform.position;
    }
    private void LateUpdate()
    {
        transform.position = player.transform.position + _offSet;
    }
}
