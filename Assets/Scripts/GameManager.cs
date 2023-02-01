using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    [SerializeField] private RecipeBook _recipeBook;
    [SerializeField] private List<Ressource> _ressourceList;
    [SerializeField] private RessourceBox _crushableRessourceBox;
    [SerializeField] private RessourceBox _endRessourceBox;

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

    public Ressource GetRessource(int index)
    {
        return _ressourceList[index];
    }

    public void SpawnRessource(int ressourceIndex)
    {
#if UNITY_ANDROID
        if (ressourceIndex < 5)
            _endRessourceBox.SpawnRessource(_ressourceList[ressourceIndex]);
        else
            _crushableRessourceBox.SpawnRessource(_ressourceList[ressourceIndex]);
#endif
    }
}
