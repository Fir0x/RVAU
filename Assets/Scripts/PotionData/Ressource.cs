using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ressource : Ingredient
{
    [SerializeField] private Color _color;
    [SerializeField] private Mesh _mesh;
    [SerializeField] private int _price = 10;

    public Color Color { get { return _color; } }
    public Mesh Mesh { get { return _mesh; } }
    public int Price { get { return _price; } }
}
