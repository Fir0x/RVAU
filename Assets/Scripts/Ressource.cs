using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRessource", menuName = "")]
public class Ressource : Ingredient
{
    [SerializeField] private Mesh _rawMesh;
    [SerializeField] private Mesh _coreMesh;

    public Mesh RawMesh { get { return _rawMesh; } }
    public Mesh CoreMesh { get { return _coreMesh; } }
}
