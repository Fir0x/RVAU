using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ressource : Ingredient
{
    [SerializeField] private Mesh _mesh;
    [SerializeField] private int _price = 10;

    public Mesh Mesh { get { return _mesh; } }
    public int Price { get { return _price; } }

    public abstract Color Color { get; }
}
