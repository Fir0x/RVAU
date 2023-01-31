using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    private List<RecipeElement> _content;
    private Potion _createdPotion;
    private bool _isBrewing = false;

    [SerializeField] private MeshRenderer _liquidRenderer;
    private Material _material;

    private void Start()
    {
        if (_liquidRenderer == null)
            return;

        _material = _liquidRenderer.material;
        _material.SetInteger("IsPotion", 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        var ressourceInstance = other.GetComponent<RessourceInstance>();
        if (ressourceInstance == null)
            return;

        AddIngredient(ressourceInstance.RessourceData);
        Destroy(other.gameObject);
    }

    public bool AddIngredient(Ingredient ingredient)
    {
        if (ingredient.IngredientType == Ingredient.Type.Potion || _isBrewing)
            return false;

        RecipeElement ingredientGroup = _content.Find(e => e.GetIngredientGUID() == ingredient.Guid);
        if (ingredientGroup != null)
            ingredientGroup.IncrementCount();
        else
            _content.Add(new RecipeElement(ingredient));

        return true;
    }

    public IEnumerator ProducePotion()
    {
        _createdPotion = GameManager.Instance.GetPotion(_content);

        const float failDuration = 5.0f;
        float productionDuration = _createdPotion ? _createdPotion.ProductionDuration : failDuration;
        _isBrewing = true;

        _material.SetInteger("IsPotion", 1);
        _material.SetInteger("IsBrewing", 1);

        yield return new WaitForSeconds(productionDuration);

        if (_createdPotion == null)
            _material.SetColor("Potion color", Color.black);

        _isBrewing = false;
        _material.SetInteger("IsBrewing", 0);
    }

    public Potion RetrievePotion()
    {
        if (_isBrewing)
            return null;

        _material.SetInteger("IsPotion", 0);

        return _createdPotion;
    }
}
