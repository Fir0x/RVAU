using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    private List<RecipeElement> _content;
    private Material _material;
    private Potion _createdPotion;
    private bool _isProducing = false;

    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
    }

    public void AddIngredient(Ingredient ingredient)
    {
        RecipeElement ingredientGroup = _content.Find(e => e.GetIngredientGUID() == ingredient.Guid);
        if (ingredientGroup != null)
            ingredientGroup.IncrementCount();
        else
            _content.Add(new RecipeElement(ingredient));
    }

    public IEnumerator ProducePotion()
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
