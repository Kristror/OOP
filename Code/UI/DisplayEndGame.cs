using UnityEngine;
using UnityEngine.UI;
using System;

public sealed class DisplayEndGame
{
    private Text _finishGameText;

    public DisplayEndGame(GameObject endGame)
    {
        _finishGameText = endGame.GetComponentInChildren<Text>();
        _finishGameText.text = String.Empty;

    }
    public void GameWin()
    {
        _finishGameText.color = Color.green;
        _finishGameText.text = $"Вы выйграли!";
    }
    public void GameOver()
    {
        _finishGameText.text = $"Вы проиграли!";
    }
}
