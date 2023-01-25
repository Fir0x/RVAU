using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Grimoire : MonoBehaviour
{
    [SerializeField] private RecipeBook _recipeBook;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private List<TMP_Text> _ingredients;

    private List<Potion> _recipes;


    void SetPage(Potion potion)
    {
        _name.SetText(potion.Name);

        if (potion.Recipe.Count > _ingredients.Count)
            throw new System.Exception("A potion cannot have more ingredients than displayable by the grimoire.");

        for (int i = 0; i < potion.Recipe.Count; i++) {
            _ingredients[i].SetText(potion.Recipe[i].Ingredient.Name);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _recipes = _recipeBook.Recipes;
        SetPage(_recipes[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
