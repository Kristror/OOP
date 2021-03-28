using Assets.Code.Bonuses.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : InteractiveObject, IFlay
{
    private float _lengthFlay = 3.5f;
    private DisplayBonuses _displayBonuses;

    private void Awake()
    {
        _displayBonuses = new DisplayBonuses();
    }
    public void Flay()
    {
        transform.localPosition = new Vector3(transform.localPosition.x,
            Mathf.PingPong(Time.time, _lengthFlay),
            transform.localPosition.z);
    }
    protected override void Interaction()
    {
        int amo_keys = FindObjectsOfType<Keys>().Length - 1;
        if (amo_keys != 0)
        {
            _displayBonuses.DisplayKey(amo_keys);
        }
        else
        {
            _displayBonuses.DisplayExit();
        }
    }
}
