using Assets.Code.Bonuses.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class GameController : MonoBehaviour
{
    private InteractiveObject[] _interactiveObjects;
    private static DisplayBonuses _displayBonuses;

    private void Awake()
    {
        _interactiveObjects = FindObjectsOfType<InteractiveObject>();
        _displayBonuses = new DisplayBonuses();
    }

    private void Update()
    {
        for (var i = 0; i < _interactiveObjects.Length; i++)
        {
            var interactiveObject = _interactiveObjects[i];

            if (interactiveObject == null)
            {
                continue;
            }

            if (interactiveObject is IFlay flay)
            {
                flay.Flay();
            }
            if (interactiveObject is IFlicker flicker)
            {
                flicker.Flicker();
            }
            if (interactiveObject is IRotation rotation)
            {
                rotation.Rotation();
            }
        }
        if (!_displayBonuses.GetDisplayText().Equals(""))
        {
            Invoke("DisplayEnd", 3);
        }
    }
    private void DisplayEnd()
    {
        _displayBonuses.DisplayEnd();
    }
}
