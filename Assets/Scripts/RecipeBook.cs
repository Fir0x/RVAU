using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRecipeBook", menuName = "")]
public class RecipeBook : ScriptableObject
{
    [SerializeField] private List<Potion> _recipes;

    public Potion GetPotion(List<RecipeElement> recipeElements)
    {
        return _recipes.Find(p => p.CheckRecipe(recipeElements));
    }
}
