using UnityEngine;


public sealed class InputController : IExecute
{
    private readonly PlayerBase _playerBase; 
    private readonly ISaveDataRepository _saveDataRepository;
    private readonly KeyCode _savePlayer = KeyCode.C;
    private readonly KeyCode _loadPlayer = KeyCode.V;

    public InputController(PlayerBase player, SaveDataRepository saveDataRepository)
    {
        _playerBase = player;

        _saveDataRepository = saveDataRepository;
    }

    public void Execute()
    {
        _playerBase.Move(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(_savePlayer))
        {
            _saveDataRepository.Save(_playerBase.gameObject);
        }
        if (Input.GetKeyDown(_loadPlayer))
        {
            _saveDataRepository.Load(_playerBase.gameObject);
        }
    }
}