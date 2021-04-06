using UnityEngine;

public abstract class PlayerBase : MonoBehaviour
{
    public float Speed = 10.0f;

    public abstract void Move(float x, float y, float z);
}