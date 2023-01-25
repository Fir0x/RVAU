using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{
    private RecipeElement _content = null;
    private Material _material;
    private bool _isProducing = false;

    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
    }

    public void AddIngredient(Ingredient ingredient)
    {
        if (_content == null) // Cruhser is empty
        {
            _content = new RecipeElement(ingredient);
        }
        else if (!_content.Crushed && _content.GetIngredientGUID() == ingredient.Guid) // Crusher contains instances of the same ingredient not crushed
        {
            _content.IncrementCount();
        }
        else // Crusher is already crushed or contains instances of another ingredient
        {
            // TODO Reject different ingredient
            // Send it back to ingredient spawn ? 
            throw new System.NotImplementedException("Reject different ingredient");
        }
    }

    public IEnumerator CrushIngredient()
    {
        _isProducing = true;
        
        yield return new WaitForSeconds(_content.CrushDuration);

        _content.Crush();
        // TODO Change material to crushed

        _isProducing = false;
    }

    public RecipeElement RetrieveCrushedIngredient()
    {
        if (_isProducing)
            return null;

        RecipeElement crushedIngredient = _content;
        _content = null;

        return crushedIngredient;
    }
}
