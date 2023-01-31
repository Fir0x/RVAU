using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mixer : MonoBehaviour
{
    private List<RecipeElement> _content;
    private Material _material;
    private Potion _createdPotion;
    private bool _isProducing = false;

    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
    }

    public void AddIngredient(Ingredient potion)
    {
        if (!(potion is Potion))
            throw new ArgumentException("Ingredient type should be a Potion.\n");

        RecipeElement ingredientGroup = _content.Find(e => e.GetIngredientGUID() == potion.Guid);
        if (ingredientGroup != null)
            ingredientGroup.IncrementCount();
        else
            _content.Add(new RecipeElement(potion));
    }

    public IEnumerator MixPotions()
    {
        _createdPotion = GameManager.Instance.GetPotion(_content);

        const float failDuration = 5.0f;
        float productionDuration = _createdPotion ? _createdPotion.ProductionDuration : failDuration;
        _isProducing = true;

        yield return new WaitForSeconds(productionDuration);

        if (_createdPotion == null)
            _material.SetColor("liquidColor", Color.black);

        _isProducing = false;
    }

    public Potion RetrievePotion()
    {
        if (_isProducing)
            return null;

        return _createdPotion;
    }
}
