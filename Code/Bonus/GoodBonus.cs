using Assets.Code.Bonuses.Interface;
using System;
using UnityEngine;


public sealed class GoodBonus : InteractiveObject, IFlay, IFlicker
{
    public event Action OnPlayerInteraction = delegate () { };
    private Material _material;
    private float _lengthFlay = 3.5f;
    [SerializeField] public GBonusType _type = GBonusType.SpeedBoost;

    public GBonusType Type
    {
        get
        {
            return _type;
        }
    }

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;        
    }

    protected override void Interaction()
    {
        OnPlayerInteraction.Invoke(); 
    }

    public override void Execute()
    {
        if (!IsInteractable) { return; }
        Flay();
        Flicker();
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
    #region old
    //[SerializeField] public GBonusType _type = GBonusType.SpeedBoost;
    //private Material _material;
    //private float _lengthFlay = 3.5f;
    //private DisplayBonuses _displayBonuses;
    //private BonusEffects _bonusEffects;
    //public Interaction _interaction;

    //private void Awake()
    //{
    //    _material = GetComponent<Renderer>().material;
    //    PlayerMove player = FindObjectOfType<PlayerMove>();
    //    _displayBonuses = new DisplayBonuses();
    //    _interaction = new Interaction(player);
    //    _bonusEffects = FindObjectOfType<BonusEffects>();
    //    _bonusEffects.AddListener(_interaction.SizeChange); 
    //    _bonusEffects.AddListener(_interaction.ChangeColor);
    //}

    //protected override void Interaction()
    //{
    //    switch (_type)
    //    {
    //        case GBonusType.SpeedBoost: _bonusEffects.SpeedBoost(); _displayBonuses.DisplayGSpeed(); break;
    //        case GBonusType.Invincibility: _bonusEffects.Invincibility(); _displayBonuses.DisplayGInvincibility(); break;
    //    }
    //    Invoke("Normal", 1f);
    //}
    //public void Normal()
    //{
    //    _interaction.NormalColor();
    //    _interaction.NormalSize();        
    //}
    //public void Flay()
    //{
    //    transform.localPosition = new Vector3(transform.localPosition.x,
    //        Mathf.PingPong(Time.time, _lengthFlay),
    //        transform.localPosition.z);
    //}

    //public void Flicker()
    //{
    //    _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
    //        Mathf.PingPong(Time.time, 1.0f));
    //}
    #endregion
}
