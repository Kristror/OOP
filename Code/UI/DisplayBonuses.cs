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
        _bonusText.text = "���������� ��������";
    }
    public void DisplayBSpeed()
    {
        _bonusText.text = "���������� ��������";
    }
    public void DisplayBUpsideDown()
    {
        _bonusText.text = "����� ������";
    }
    public void DisplayGInvincibility()
    {
        _bonusText.text = "������������";
    }
    public void DisplayKey(int value)
    {
        if(value == 0)
        {
            _bonusText.text = $"�� ����� ��� �����. \n ���� �� �����!";
        }
        else _bonusText.text = $"�������� ����� {value} ������";
    }
    public void DisplayNotEnough()
    {
        _bonusText.text = $"�� ��� �� ����� ���� ������.";
    }
}

