using System.Collections.Generic;
using System.IO;
using UnityEngine;

public sealed class SaveDataRepository : ISaveDataRepository
{
    private readonly IData<List<SavedData>> _data;

    private const string _folderName = "dataSave";
    private const string _fileName = "data.xml";
    private readonly string _path;
    private ListExecuteObject _interactiveObject;

    private List<SavedData> _saveObjects = new List<SavedData>();

    public SaveDataRepository(ListExecuteObject interactiveObject)
    {
        _interactiveObject = interactiveObject;
        _data = new SerializableXMLData<List<SavedData>>();
        _path = Path.Combine(Application.dataPath, _folderName);
    }

    private SavedData CreateSaveData(GameObject _object)
    {
        SavedData data = new SavedData
        {
            Position = _object.transform.position,
            Name = _object.name,
            IsEnabled = _object.GetComponent<InteractiveObject>().IsInteractable
        };
        return data;
    }

    public void Save(GameObject player)
    {
        if (!Directory.Exists(Path.Combine(_path)))
        {
            Directory.CreateDirectory(_path);
        }
        var savePlayer = new SavedData
        {
            Position = player.transform.position,
            Name = player.name,
            IsEnabled = true
        };
        foreach (var o in _interactiveObject)
        {
            if (o is InteractiveObject interactiveObject)
                _saveObjects.Add(CreateSaveData(interactiveObject.gameObject));
        }
        _saveObjects.Add(savePlayer);

        _data.Save(_saveObjects, Path.Combine(_path, _fileName));
        _saveObjects.Clear();
    }

    public void Load(GameObject player)
    {
        var file = Path.Combine(_path, _fileName);
        if (!File.Exists(file)) return;
        var loadData = _data.Load(file);
        for (int i = 0; i < _interactiveObject.Length; i++) 
        { 
            if (_interactiveObject[i] is InteractiveObject interactiveObject)
            {
                interactiveObject.gameObject.transform.position = loadData[i].Position;
                interactiveObject.IsInteractable =  loadData[i].IsEnabled;
            }
        }
        player.transform.position = loadData[loadData.Count-1].Position;
    }
}
