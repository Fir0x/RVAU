using System;
using UnityEngine;

public abstract class Ingredient : ScriptableObject
{
    public enum Type
    {
        CrushableRessource,
        EndRessource,
        Potion
    };

    [SerializeField] protected string _name;
    [SerializeField] private Guid _guid;
    protected Type _ingredientType;

    public string Name { get { return name; } }
    public Guid Guid { get { return _guid;} }
    public Type IngredientType { get { return _ingredientType; } }

    protected virtual void Awake()
    {
        _guid = Guid.NewGuid();
    }
}
