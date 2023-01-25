using System;
using UnityEngine;

[Serializable]
public class RecipeElement
{
    [SerializeField] private Ingredient _ingredient;
    [SerializeField] private int _count;

    public Ingredient Ingredient { get { return _ingredient; } }

    public RecipeElement(Ingredient ingredient)
    {
        _ingredient = ingredient;
        _count = 1;
    }

    public RecipeElement(Ingredient ingredient, int count)
    {
        _ingredient = ingredient;
        _count = count;
    }

    public bool Equals(RecipeElement other)
    {
        return _ingredient.Guid == other._ingredient.Guid && _count == other._count;
    }

    public Guid GetIngredientGUID()
    {
        return _ingredient.Guid;
    }

    public void IncrementCount()
    {
        _count++;
    }
}
