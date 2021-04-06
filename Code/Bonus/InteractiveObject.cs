using Assets.Code.Bonuses.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour, IExecute
{
    private bool _isInteractable;    

    public bool IsInteractable
    {
        get { return _isInteractable; }
        private set
        {
            _isInteractable = value;
            GetComponent<Renderer>().enabled = _isInteractable;
            GetComponent<Collider>().enabled = _isInteractable;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!IsInteractable || !other.CompareTag("Player"))
        {
            return;
        }
        Interaction();
        IsInteractable = false;
    }

    protected abstract void Interaction();
    public abstract void Execute();

    private void Start()
    {
        IsInteractable = true;
    }
}

