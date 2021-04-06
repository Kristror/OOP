using System;
using UnityEngine;
using UnityEngine.UI;


public sealed class DisplayBonuses
{
    private Text _bonusText;
    public DisplayBonuses(GameObject bonus)
    {
        _bonusText = bonus.GetComponentInChildren<Text>();
        _bonusText.text = String.Empty;
    }

    public string GetDisplayText()
    {
        return _bonusText.text;
    }
    public void DisplayClear()
    {
        _bonusText.text = "";
    }
    public void DisplayGSpeed()
    {
        _bonusText.text = "Увеличение скорости";
    }
    public void DisplayBSpeed()
    {
        _bonusText.text = "Уменьшение скорости";
    }
    public void DisplayBUpsideDown()
    {
        _bonusText.text = "Вверх ногами";
    }
    public void DisplayGInvincibility()
    {
        _bonusText.text = "Неуязвимость";
    }
    public void DisplayKey(int value)
    {
        if(value == 0)
        {
            _bonusText.text = $"Вы нашли все ключи. \n Пора на выход!";
        }
        else _bonusText.text = $"Осталось найти {value} ключей";
    }
    public void DisplayNotEnough()
    {
        _bonusText.text = $"Вы еще не нашли всех ключей.";
    }
}

