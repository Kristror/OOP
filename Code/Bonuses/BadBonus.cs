using Assets.Code.Bonuses.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BadBonus : InteractiveObject, IFlay, IRotation
{
    [SerializeField] public BBonusType _type = BBonusType.SlowDouwn;
    private float _lengthFlay = 5;
    private float _speedRotation = 25;
    private DisplayBonuses _displayBonuses;
    private BonusEffects _bonusEffects;


    private void Awake()
    {
        _displayBonuses = new DisplayBonuses();
        _bonusEffects = FindObjectOfType<BonusEffects>();
    }

    protected override void Interaction()
    {
        switch (_type)
        {
            case BBonusType.SlowDouwn: _bonusEffects.SlowDouwn(); _displayBonuses.DisplayBSpeed(); break;
            case BBonusType.UpsideDown: _bonusEffects.UpsideDown(); _displayBonuses.DisplayBUpsideDown(); break;
        }
    }

    public void Flay()
    {
        transform.localPosition = new Vector3(transform.localPosition.x,
            Mathf.PingPong(Time.time, _lengthFlay),
            transform.localPosition.z);
    }

    public void Rotation()
    {
        transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
    }
}

