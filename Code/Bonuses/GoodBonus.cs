using Assets.Code.Bonuses.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodBonus : InteractiveObject, IFlay, IFlicker
{
    [SerializeField] public GBonusType _type = GBonusType.SpeedBoost;
    private Material _material;
    private float _lengthFlay = 3.5f;
    private DisplayBonuses _displayBonuses;
    private BonusEffects _bonusEffects;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material; 
        _displayBonuses = new DisplayBonuses();
        _bonusEffects = FindObjectOfType<BonusEffects>();
    }

    protected override void Interaction()
    {
        switch (_type)
        {
            case GBonusType.SpeedBoost: _bonusEffects.SpeedBoost(); _displayBonuses.DisplayGSpeed(); break;
            case GBonusType.Invincibility: _bonusEffects.Invincibility(); _displayBonuses.DisplayGInvincibility(); break;
        }
    }

    public void Flay()
    {
        transform.localPosition = new Vector3(transform.localPosition.x,
            Mathf.PingPong(Time.time, _lengthFlay),
            transform.localPosition.z);
    }

    public void Flicker()
    {
        _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
            Mathf.PingPong(Time.time, 1.0f));
    }
}
