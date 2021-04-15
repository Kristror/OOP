using UnityEngine;
interface ISaveDataRepository
{
    void Save(GameObject _object);
    void Load(GameObject _object);
}
