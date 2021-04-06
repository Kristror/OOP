using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusEffects : MonoBehaviour
{
    private bool _speedBoost = false;
    private bool _invincibility = false;
    private bool _slowDown = false;
    private bool _upsideDown = false;
    private float _speedmult = 2;
    private PlayerMove _playerMove; 
    private PlayerStatus _playerStatus;
    private CameraFollow _camera;
    private float _effectTime = 7;

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
        Invoke("NormalSpeed", _effectTime);
    }
    public void Invincibility()
    {
        _invincibility = true;
        _playerStatus.invincibility = true;
        Invoke("DisInvincibility", _effectTime);
    }
    public void SlowDouwn()
    {
        _slowDown = true; 
        _playerMove.Speed /= _speedmult;
        Invoke("NormalSpeed", _effectTime);
    }
    public void UpsideDown()
    {
        _upsideDown = true;
        _camera.transform.Rotate(new Vector3(0, 0, 180));
        Invoke("NormalView", _effectTime);
    }
    public void NormalView()
    {
        _upsideDown = false;
        _camera.transform.Rotate(new Vector3(0,0,-180));
    }
    public void DisInvincibility()
    {
        _invincibility = false;
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
