using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public sealed class DisplayBonuses
{
    private Text _text;
    public DisplayBonuses()
    {
        _text = Object.FindObjectOfType<Text>();
    }

    public string GetDisplayText()
    {
        return _text.text;
    }
    public void DisplayEnd()
    {
        _text.text = "";
    }
    public void DisplayGSpeed()
    {
        _text.text = "Увеличение скорости";
    }
    public void DisplayBSpeed()
    {
        _text.text = "Уменьшение скорости";
    }
    public void DisplayBUpsideDown()
    {
        _text.text = "Вверх ногами";
    }
    public void DisplayGInvincibility()
    {
        _text.text = "Неуязвимость";
    }
    public void DisplayKey(int value)
    {
        _text.text = $"Осталось найти {value} ключей";
    }
    public void DisplayExit()
    {
        _text.text = $"Вы нашли все ключи. Пора на выход!";
    }
}

