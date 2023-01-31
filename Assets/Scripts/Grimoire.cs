using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Grimoire : MonoBehaviour
{
    [SerializeField] private GameObject[] _ingredientPages;
    [SerializeField] private GameObject _recipePage;
    [SerializeField] private RecipeBook _recipeBook;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _ingredients;
    [SerializeField] private Button _previousPageButton;
    [SerializeField] private Button _nextPageButton;

    private List<Potion> _recipes;
    private int _currentPage = 0;
    private int _totalPages = 0;

    private const int _maxIngredients = 7;

    void SetPage()
    {
        // If the current page is an ingredient page
        if (_currentPage < _ingredientPages.Length) {
            // Show the current ingredient page
            _ingredientPages[_currentPage].SetActive(true);

            // Hide the other ingredient pages and the recipe page
            for (int i = 0; i < _ingredientPages.Length; i++)
                if (i != _currentPage)
                    _ingredientPages[i].SetActive(false);

            _recipePage.SetActive(false);
        }
        // If the current page is a recipe page
        else
        {
            // Set the recipe page
            Potion potion = _recipes[_currentPage - _ingredientPages.Length];
            _name.SetText(potion.Name);
            _icon.sprite = potion.Icon;

            string recipe = "";

            if (potion.Recipe.Count > _maxIngredients)
                throw new System.Exception("A potion cannot have more ingredients than displayable by the grimoire.");

            for (int i = 0; i < potion.Recipe.Count; i++)
                recipe += potion.Recipe[i].Count + "x " + potion.Recipe[i].Ingredient.Name + "\n";

            _ingredients.SetText(recipe);

            // Show the recipe page
            _recipePage.SetActive(true);

            // Hide the ingredient pages
            for (int i = 0; i < _ingredientPages.Length; i++)
                _ingredientPages[i].SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _recipes = _recipeBook.Recipes;
        _totalPages = _ingredientPages.Length + _recipes.Count;
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
            _currentPage = _totalPages - 1;

        SetPage();
    }

    void NextPage()
    {
        _currentPage++;
        if (_currentPage >= _totalPages)
            _currentPage = 0;

        SetPage();
    }
}
