using System;
using UnityEngine;

public class Placement : MonoBehaviour, IDisposable
{
    [SerializeField] Transform _characterRoot;
    [Range(0,2)] [SerializeField] private int _id;
    GameObject _character;
    public int Id => _id;

    public void Place(GameObject character)
    {
        _character = character;
        character.transform.SetPositionAndRotation(_characterRoot.position, Quaternion.identity);
    }

    public void Dispose()
    {
        Destroy(_character);
    }
}
