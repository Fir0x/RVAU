using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{
    private RessourceInstance _processedRessource;
    private Material _material;
    private bool _isProducing = false;
    private float _crushingDuration;

    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
    }

    public bool AddRessource(RessourceInstance ressource)
    {
        if (_processedRessource != null || _isProducing
            || ressource.RessourceType == Ingredient.Type.CrushableRessource)
            return false;

        _crushingDuration = (ressource.RessourceData as CrushableRessource).CrushingDuration;
        _processedRessource = ressource;

        return true;
    }

    public IEnumerator CrushIngredient()
    {
        _isProducing = true;
        
        yield return new WaitForSeconds(_crushingDuration);

        _isProducing = false;
    }

    public bool RetrieveCrushedIngredient()
    {
        if (_isProducing)
            return false;

        _processedRessource.Crush();

        return true;
    }
}
