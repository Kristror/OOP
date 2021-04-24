
using UnityEngine;
public abstract class CheckObject : MonoBehaviour , ICheck
{
    public abstract bool Check();
    protected abstract void Interaction();

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        Interaction();
    }
}
