using UnityEngine;
public class BonusEffects : MonoBehaviour
{
    private bool _speedBoost = false;
    private bool _slowDown = false;
    private float _speedmult = 2;
    private PlayerBase _playerMove;
    private PlayerStatus _playerStatus;
    private CameraController _camera;
    private float _effectTime = 7;

    public float EffectTime
    {
        get
        {
            return _effectTime;
        }
    }
    public void Data(PlayerBase player,CameraController camera, PlayerStatus status)
    {
        _playerMove = player;
        _camera = camera;
        _playerStatus = status;
    }
    public void SpeedBoost()
    {
        _speedBoost = true;
        _playerMove.Speed *= _speedmult;
        Invoke("NormalSpeed", _effectTime);
    }
    public void Invincibility()
    {
        _playerStatus.invincibility = true;
        Invoke("DisInvincibility", _effectTime);
    }
    public void SlowDown()
    {
        _slowDown = true;
        _playerMove.Speed /= _speedmult;
        Invoke("NormalSpeed", _effectTime);
    }
    public void UpsideDown()
    {
        _camera.Rotate(new Vector3(0, 0, 180));
        Invoke("NormalView", _effectTime);
    }
    public void Death()
    {
        Time.timeScale = 0.0f;
    }
    public void NormalView()
    {
        _camera.Rotate(new Vector3(0, 0, -180));
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
