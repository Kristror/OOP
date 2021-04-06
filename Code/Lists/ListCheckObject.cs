using System;
using System.Collections;
using Object = UnityEngine.Object;

public sealed class ListCheckObject : IEnumerator, IEnumerable
{
    private ICheck[] _checkObjects;
    private int _index = -1;
    private CheckObject _current;

    public ListCheckObject()
    {
        var checkObjects = Object.FindObjectsOfType<CheckObject>();
        for (var i = 0; i < checkObjects.Length; i++)
        {
            if (checkObjects[i] is ICheck checkObject)
            {
                AddCheckObject(checkObject);
            }
        }
    }

    public void AddCheckObject(ICheck check)
    {
        if (_checkObjects == null)
        {
            _checkObjects = new[] { check };
            return;
        }
        Array.Resize(ref _checkObjects, Length + 1);
        _checkObjects[Length - 1] = check;
    }

    public ICheck this[int index]
    {
        get => _checkObjects[index];
        private set => _checkObjects[index] = value;
    }

    public int Length => _checkObjects.Length;

    public bool MoveNext()
    {
        if (_index == _checkObjects.Length - 1)
        {
            Reset();
            return false;
        }

        _index++;
        return true;
    }

    public void Reset() => _index = -1;

    public object Current => _checkObjects[_index];

    public IEnumerator GetEnumerator()
    {
        return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}