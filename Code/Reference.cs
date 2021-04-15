using UnityEngine;
using UnityEngine.UI;

public class Reference
{
    private PlayerMove _playerMove;
    private Camera _mainCamera;
    private GameObject _bonuse;
    private GameObject _endGame;
    private Canvas _canvas;
    private Button _restartButton;
    private BonusEffects _bonusEffects;
    private Radar _radar;

    public Radar Radar
    {
        get
        {
            if (_radar == null)
            {
                var gameObject = Resources.Load<Radar>("Radar/Radar");
                _radar = Object.Instantiate(gameObject);
            }

            return _radar;
        }
    }

    public BonusEffects BonusEffects
    {
        get
        {
            if (_bonusEffects == null)
            {
                var gameObject = Resources.Load<BonusEffects>("EffectController");
                _bonusEffects = Object.Instantiate(gameObject);
            }

            return _bonusEffects;
        }
    }

    public Button RestartButton
    {
        get
        {
            if (_restartButton == null)
            {
                var gameObject = Resources.Load<Button>("UI/RestartButton");
                _restartButton = Object.Instantiate(gameObject, Canvas.transform);
            }

            return _restartButton;
        }
    }

    public Canvas Canvas
    {
        get
        {
            if (_canvas == null)
            {
                _canvas = Object.FindObjectOfType<Canvas>();
            }
            return _canvas;
        }
    }

    public GameObject Bonuse
    {
        get
        {
            if (_bonuse == null)
            {
                var gameObject = Resources.Load<GameObject>("UI/Bonuse");
                _bonuse = Object.Instantiate(gameObject, Canvas.transform);
            }

            return _bonuse;
        }
    }

    public GameObject EndGame
    {
        get
        {
            if (_endGame == null)
            {
                var gameObject = Resources.Load<GameObject>("UI/EndGame");
                _endGame = Object.Instantiate(gameObject, Canvas.transform);
            }

            return _endGame;
        }
    }

    public PlayerMove PlayerMove
    {
        get
        {
            if (_playerMove == null)
            {
                var gameObject = Resources.Load<PlayerMove>("Player");
                _playerMove = Object.Instantiate(gameObject);
            }

            return _playerMove;
        }
    }

    public Camera MainCamera
    {
        get
        {
            if (_mainCamera == null)
            {
                _mainCamera = Camera.main;
            }
            return _mainCamera;
        }
    }
}


