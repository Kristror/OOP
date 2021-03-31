using UnityEngine;
public class BonusEffects : MonoBehaviour
{
    private bool _speedBoost = false;
    private bool _slowDown = false;
    private float _speedmult = 2;
    private PlayerMove _playerMove;
    private PlayerStatus _playerStatus;
    private CameraFollow _camera;
    private float _effectTime = 7;
    #region Alerts
    public delegate void Action(float time);

    private event Action _functions;

    public void AddListener(Action f)
    {
        _functions += f;
    }

    public void RemoveListener(Action f)
    {
        _functions -= f;
    }

    public void PickUpEffect()
    {
        if (_functions != null) _functions(_effectTime);
    }
    #endregion
    private void Awake()
    {
        _playerMove = FindObjectOfType<PlayerMove>();
        _playerStatus = FindObjectOfType<PlayerStatus>();
        _camera = FindObjectOfType<CameraFollow>();
    }
    public void SpeedBoost()
    {
        _speedBoost = true;
        _playerMove.Speed *= _speedmult;
        PickUpEffect();
        Invoke("NormalSpeed", _effectTime);
    }
    public void Invincibility()
    {
        _playerStatus.invincibility = true;
        PickUpEffect();
        Invoke("DisInvincibility", _effectTime);
    }
    public void SlowDouwn()
    {
        _slowDown = true;
        _playerMove.Speed /= _speedmult;
        PickUpEffect();
        Invoke("NormalSpeed", _effectTime);
    }
    public void UpsideDown()
    {
        _camera.transform.Rotate(new Vector3(0, 0, 180));
        PickUpEffect();
        Invoke("NormalView", _effectTime);
    }
    public void NormalView()
    {
        _camera.transform.Rotate(new Vector3(0, 0, -180));
    }
    public void DisInvincibility()
    {
        _playerStatus.invincibility = false;
    }
    public void NormalSpeed()
    {
        if (_speedBoost)
        {
            _playerMove.Speed /= _speedmult;
            _speedBoost = false;
        }
        if (_slowDown)
        {
            _playerMove.Speed *= _speedmult;
            _slowDown = false;
        }
    }
}
