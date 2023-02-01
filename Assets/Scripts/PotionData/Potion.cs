using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPotion", menuName = "")]
public class Potion : Ingredient
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private Color _topColor;
    [SerializeField] private Color _baseColor;
    [SerializeField] private List<RecipeElement> _recipe;
    [SerializeField] private float _productionDuration = 5.0f;
    [SerializeField] private int _price = 30;

    public Sprite Icon { get { return _icon; } }
    public Color TopColor { get { return _topColor; } }
    public Color BaseColor { get { return _baseColor; } }
    public float ProductionDuration { get { return _productionDuration; } }
    public List<RecipeElement> Recipe { get { return _recipe; } }
    public int Price { get { return _price; } }

    protected override void Awake()
    {
        base.Awake();

        _ingredientType = Type.Potion;
    }

    public bool CheckRecipe(List<RecipeElement> recipeToTest)
    {
        if (recipeToTest == null || recipeToTest.Count != _recipe.Count)
            return false;

        foreach (RecipeElement element in recipeToTest)
        {
            if (!recipeToTest.Exists(e => element.Equals(e)))
                return false;
        }

        return true;
    }
}
