using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ressource : Ingredient
{
    [SerializeField] private Mesh _mesh;
    public Mesh Mesh { get { return _mesh; } }
}
