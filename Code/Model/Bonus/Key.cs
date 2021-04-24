using Assets.Code.Bonuses.Interface;
using System;
using UnityEngine;

public sealed class Key : InteractiveObject, IFlay
{
    public event Action<int> OnPlayerInteraction = delegate (int i) { }; 
    public event Action OnPlayerAction = delegate () { };
    private float _lengthFlay = 3.5f;
    private int _keys = -1;

    public int Keys
    {
        get
        {
            return _keys;
        }
    }

    private void Awake()
    {
        CountKeys();
    }

    private void CountKeys()
    {
        _keys = -1;
        Key[] keys = FindObjectsOfType<Key>();
        foreach (Key key in keys)
        {
            if (key.IsInteractable) _keys++;
        }
    }

    public void Flay()
    {
        transform.localPosition = new Vector3(transform.localPosition.x,
            Mathf.PingPong(Time.time, _lengthFlay),
            transform.localPosition.z);
    }
    protected override void Interaction()
    {
        CountKeys();
        OnPlayerInteraction.Invoke(_keys);
        OnPlayerAction.Invoke();
    }

    public override void Execute()
    {
        if (!IsInteractable) { return; }
        Flay();
    }
}
