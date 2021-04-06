using Assets.Code.Bonuses.Interface;
using System;
using UnityEngine;

public sealed class BadBonus : InteractiveObject, IFlay, IRotation
{
    public event Action OnCaughtPlayerChange = delegate () {};
    private float _lengthFlay = 5;
    private float _speedRotation = 25;
    [SerializeField] public BBonusType _type = BBonusType.SlowDouwn;
    public BBonusType Type
    {
        get
        {
            return _type;
        }
    }
    protected override void Interaction()
    {
        OnCaughtPlayerChange.Invoke();
    }

    public override void Execute()
    {
        if (!IsInteractable) { return; }
        Flay();
        Rotation();
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
    #region old
    //[SerializeField] public BBonusType _type = BBonusType.SlowDouwn;
    //private float _lengthFlay = 5;
    //private float _speedRotation = 25;
    //private DisplayBonuses _displayBonuses;
    //private BonusEffects _bonusEffects;
    //public Interaction _interaction;

    //private void Awake()
    //{
    //    _displayBonuses = new DisplayBonuses();
    //    _bonusEffects = FindObjectOfType<BonusEffects>(); 
    //    PlayerMove player = FindObjectOfType<PlayerMove>(); 
    //    _interaction = new Interaction(player);
    //    _bonusEffects = FindObjectOfType<BonusEffects>();
    //    _bonusEffects.AddListener(_interaction.SizeChange);
    //    _bonusEffects.AddListener(_interaction.ChangeColor);
    //}

    //protected override void Interaction()
    //{
    //    switch (_type)
    //    {
    //        case BBonusType.SlowDouwn: _bonusEffects.SlowDouwn(); _displayBonuses.DisplayBSpeed(); break;
    //        case BBonusType.UpsideDown: _bonusEffects.UpsideDown(); _displayBonuses.DisplayBUpsideDown(); break;
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

    //public void Rotation()
    //{
    //    transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
    //}
    #endregion
}

