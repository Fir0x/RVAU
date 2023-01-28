using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Grimoire : MonoBehaviour
{
    [SerializeField] private RecipeBook _recipeBook;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _ingredients;
    [SerializeField] private Button _previousPageButton;
    [SerializeField] private Button _nextPageButton;

    private List<Potion> _recipes;
    private int _currentPage = 0;

    private const int _maxIngredients = 7;

    void SetPage()
    {
        Potion potion = _recipes[_currentPage];
        _name.SetText(potion.Name);
        _icon.sprite = potion.Icon;

        string recipe = "";

        if (potion.Recipe.Count > _maxIngredients)
            throw new System.Exception("A potion cannot have more ingredients than displayable by the grimoire.");

        for (int i = 0; i < potion.Recipe.Count; i++)
            recipe += potion.Recipe[i].Count + "x " + potion.Recipe[i].Ingredient.Name + "\n";

        _ingredients.SetText(recipe);

    }

    // Start is called before the first frame update
    void Start()
    {
        _recipes = _recipeBook.Recipes;
        SetPage();
    }

    void OnEnable()
    {
        _previousPageButton.onClick.AddListener(PreviousPage);
        _nextPageButton.onClick.AddListener(NextPage);
    }

    void PreviousPage()
    {
        _currentPage--;
        if (_currentPage < 0)
            _currentPage = _recipes.Count - 1;

        SetPage();
    }

    void NextPage()
    {
        _currentPage++;
        if (_currentPage >= _recipes.Count)
            _currentPage = 0;

        SetPage();
    }
}
