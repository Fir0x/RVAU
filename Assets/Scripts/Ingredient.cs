using System;
using UnityEngine;

public abstract class Ingredient : ScriptableObject
{
    [SerializeField] protected string _name;
    [SerializeField] private Guid _guid;

    public string Name { get { return name; } }
    public Guid Guid { get { return _guid;} }

    private void Awake()
    {
        _guid = Guid.NewGuid();
    }
}
