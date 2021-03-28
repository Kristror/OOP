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
        _text.text = "���������� ��������";
    }
    public void DisplayBSpeed()
    {
        _text.text = "���������� ��������";
    }
    public void DisplayBUpsideDown()
    {
        _text.text = "����� ������";
    }
    public void DisplayGInvincibility()
    {
        _text.text = "������������";
    }
    public void DisplayKey(int value)
    {
        _text.text = $"�������� ����� {value} ������";
    }
    public void DisplayExit()
    {
        _text.text = $"�� ����� ��� �����. ���� �� �����!";
    }
}

