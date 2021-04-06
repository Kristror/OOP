using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameController : MonoBehaviour, IDisposable
{
    private ListExecuteObject _interactiveObject;
    private ListCheckObject _checkObject;
    private DisplayEndGame _displayEndGame;
    private DisplayBonuses _displayBonuses;
    private BonusEffects _bonusEffects;
    private CameraController _cameraController;
    private InputController _inputController;
    private Reference _reference;
    private int _countBonuses;

    private void Awake()
    {
        _interactiveObject = new ListExecuteObject();
        _checkObject = new ListCheckObject();
        _reference = new Reference();

        PlayerBase player = null;
        player = _reference.PlayerMove;
        _cameraController = new CameraController(_reference.PlayerMove.transform, _reference.MainCamera.transform);
        _interactiveObject.AddExecuteObject(_cameraController);

        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            _inputController = new InputController(player);
            _interactiveObject.AddExecuteObject(_inputController);
        }
        _bonusEffects = _reference.BonusEffects;
        _bonusEffects.Data(player, _cameraController, player.GetComponent<PlayerStatus>());
        _displayEndGame = new DisplayEndGame(_reference.EndGame);
        _displayBonuses = new DisplayBonuses(_reference.Bonuse);
        FillInterObjects();
        FillCheckObjects();
        _reference.RestartButton.onClick.AddListener(RestartGame);
        _reference.RestartButton.gameObject.SetActive(false);
    }

    private void FillInterObjects()
    {
        foreach (var o in _interactiveObject)
        {
            if (o is BadBonus badBonus)
            {
                if (badBonus.Type == BBonusType.SlowDouwn)
                {
                    badBonus.OnCaughtPlayerChange += _bonusEffects.SlowDown;
                    badBonus.OnCaughtPlayerChange += _displayBonuses.DisplayBSpeed;
                    badBonus.OnCaughtPlayerChange += ClearON;
                }
                if (badBonus.Type == BBonusType.UpsideDown)
                {
                    badBonus.OnCaughtPlayerChange += _bonusEffects.UpsideDown;
                    badBonus.OnCaughtPlayerChange += _displayBonuses.DisplayBUpsideDown;
                    badBonus.OnCaughtPlayerChange += ClearON;
                }
                if (badBonus.Type == BBonusType.Death)
                {
                    badBonus.OnCaughtPlayerChange += _bonusEffects.Death;
                    badBonus.OnCaughtPlayerChange += _displayEndGame.GameOver;
                    badBonus.OnCaughtPlayerChange += ActiveButton;
                }                
            }

            if (o is GoodBonus goodBonus)
            {
                if (goodBonus.Type == GBonusType.SpeedBoost)
                {
                    goodBonus.OnPlayerInteraction += _bonusEffects.SpeedBoost;
                    goodBonus.OnPlayerInteraction += _displayBonuses.DisplayGSpeed;
                    goodBonus.OnPlayerInteraction += ClearON;
                }
                if (goodBonus.Type == GBonusType.Invincibility)
                {
                    goodBonus.OnPlayerInteraction += _bonusEffects.Invincibility;
                    goodBonus.OnPlayerInteraction += _displayBonuses.DisplayGInvincibility;
                    goodBonus.OnPlayerInteraction += ClearON;
                }
            }
            
            if(o is Key key)
            {
                key.OnPlayerInteraction += _displayBonuses.DisplayKey;
                key.OnPlayerAction += ClearON;
            } 
        }
    }
    private void FillCheckObjects()
    {
        foreach (var o in _checkObject)
        {
            if (o is EndGame endgame)
            {
                endgame.OnPlayerTrueInter += _bonusEffects.Death;
                endgame.OnPlayerTrueInter += _displayEndGame.GameWin;
                endgame.OnPlayerTrueInter += ActiveButton;

                endgame.OnPlayerFalseInter += _displayBonuses.DisplayNotEnough;
                endgame.OnPlayerFalseInter += ClearON;
            }
        }
    }
    private void ActiveButton()
    {
        _reference.RestartButton.gameObject.SetActive(true);
    }
    public void ClearON()
    {
        Invoke("Clear", _bonusEffects.EffectTime);
    }

    public void Clear()
    {
        _displayBonuses.DisplayClear();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
        Time.timeScale = 1.0f;
    }


    private void Update()
    {
        for (var i = 0; i < _interactiveObject.Length; i++)
        {
            var interactiveObject = _interactiveObject[i];

            if (interactiveObject == null)
            {
                continue;
            }
            interactiveObject.Execute();
        }
    }

    public void Dispose()
    {
        foreach (var o in _interactiveObject)
        {
            if (o is BadBonus badBonus)
            {
                if (badBonus.Type == BBonusType.SlowDouwn)
                {
                    badBonus.OnCaughtPlayerChange -= _bonusEffects.SlowDown;
                    badBonus.OnCaughtPlayerChange -= _displayBonuses.DisplayBSpeed;
                }
                if (badBonus.Type == BBonusType.UpsideDown)
                {
                    badBonus.OnCaughtPlayerChange -= _bonusEffects.UpsideDown;
                    badBonus.OnCaughtPlayerChange -= _displayBonuses.DisplayBUpsideDown;
                }
                if (badBonus.Type == BBonusType.Death)
                {
                    badBonus.OnCaughtPlayerChange -= _bonusEffects.Death;
                    badBonus.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                    badBonus.OnCaughtPlayerChange -= delegate () { _reference.RestartButton.gameObject.SetActive(true); };
                }
            }

            if (o is GoodBonus goodBonus)
            {
                if (goodBonus.Type == GBonusType.SpeedBoost)
                {
                    goodBonus.OnPlayerInteraction -= _bonusEffects.SpeedBoost;
                    goodBonus.OnPlayerInteraction -= _displayBonuses.DisplayGSpeed;
                }
                if (goodBonus.Type == GBonusType.Invincibility)
                {
                    goodBonus.OnPlayerInteraction -= _bonusEffects.Invincibility;
                    goodBonus.OnPlayerInteraction -= _displayBonuses.DisplayGInvincibility;
                }
            }

            if (o is Key key)
            {
                key.OnPlayerInteraction -= _displayBonuses.DisplayKey;
                key.OnPlayerAction -= ClearON;
            }
        }
        foreach (var o in _checkObject)
        {
            if (o is EndGame endgame)
            {
                endgame.OnPlayerTrueInter -= _bonusEffects.Death;
                endgame.OnPlayerTrueInter -= _displayEndGame.GameWin;
                endgame.OnPlayerTrueInter -= ActiveButton;

                endgame.OnPlayerFalseInter -= _displayBonuses.DisplayNotEnough;
                endgame.OnPlayerFalseInter -= ClearON;
            }
        }
    }
} 