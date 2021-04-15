using System;

class EndGame : CheckObject
{
    public event Action OnPlayerTrueInter = delegate () { };
    public event Action OnPlayerFalseInter = delegate () { };
    public override bool Check()
    {
        int amountKeys = 0;
        Key[] keys = FindObjectsOfType<Key>();
        foreach (Key key in keys)
        {
            if (key.IsInteractable) amountKeys++;
        }
        if (amountKeys == 0)
        {
            return true;
        }
        else return false;
    }

    protected override void Interaction()
    {
        if (Check())
        {
            OnPlayerTrueInter.Invoke();
        }
        else OnPlayerFalseInter.Invoke();
    }

}
