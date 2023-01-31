using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    [SerializeField] private RecipeBook _recipeBook;

    private void Awake()
    {
        _instance = this;
    }

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("No instance of game manager");

            return _instance;
        }
    }

    public Potion GetPotion(List<RecipeElement> recipeElements)
    {
        return _recipeBook.GetPotion(recipeElements);
    }
}
