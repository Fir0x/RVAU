using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceInstance : MonoBehaviour
{
    private Ressource _ressourceData;
    private bool _isCrushed = false;

    private MeshFilter _meshFilter;

    public Ressource RessourceData { get { return _ressourceData; } }
    public Ingredient.Type RessourceType { get { return _ressourceData.IngredientType; } }

    private void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _meshFilter.mesh = _ressourceData.Mesh;
    }

    public void SetRessource(Ressource ressourceData)
    {
        _ressourceData = ressourceData;
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
