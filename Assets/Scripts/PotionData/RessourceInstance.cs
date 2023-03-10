using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceInstance : MonoBehaviour
{
    private Ressource _ressourceData;
    private bool _isCrushed = false;

    private MeshFilter _meshFilter;
    private Material _material;

    public Ressource RessourceData { get { return _ressourceData; } }
    public Ingredient.Type RessourceType { get { return _ressourceData.IngredientType; } }

    private void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _material = GetComponent<MeshRenderer>().material;
    }

    public void SetRessource(Ressource ressourceData)
    {
        _ressourceData = ressourceData;
        _meshFilter.mesh = _ressourceData.Mesh;
        _material.SetColor("Color", _ressourceData.Color);
    }

    public void Crush()
    {
        if (!_isCrushed && _ressourceData.IngredientType == Ingredient.Type.CrushableRessource)
        {
            _ressourceData = (_ressourceData as CrushableRessource).EndRessource;
            _meshFilter.mesh = _ressourceData.Mesh;
        }

        _isCrushed = true;
    }

    public Ressource GetRessourceData()
    {
        return _ressourceData;
    }
}
