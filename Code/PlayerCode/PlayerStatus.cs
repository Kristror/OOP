using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float hp = 100;
    public bool invincibility = false;

    public bool Invincibility
    {
        internal get => invincibility;
        set => invincibility = value;
    }
}
