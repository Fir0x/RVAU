using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPotion", menuName = "")]
public class Potion : Ingredient
{
    [SerializeField] private Material _material;
    [SerializeField] private List<RecipeElement> _recipe;
    [SerializeField] private float _productionDuration = 5.0f;

    public Material Material { get { return _material; } }
    public float ProductionDuration { get { return _productionDuration; } }
    public List<RecipeElement> Recipe { get { return _recipe; } }

    protected override void Awake()
    {
        base.Awake();

        _ingredientType = Type.Potion;
    }

    public bool CheckRecipe(List<RecipeElement> recipeToTest)
    {
        if (recipeToTest.Count != _recipe.Count)
            return false;

        foreach (RecipeElement element in recipeToTest)
        {
            if (!recipeToTest.Exists(e => element.Equals(e)))
                return false;
        }

        return true;
    }
}
