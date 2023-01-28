using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Commands : MonoBehaviour
{
    [SerializeField] private RecipeBook _recipeBook;
    [SerializeField] private Image[] _commandsDisplay;


    private Potion[] _commands;

    // Start is called before the first frame update
    void Start()
    {
        System.Random rnd = new System.Random();
        
        _commands = new Potion[_commandsDisplay.Length];

        // For each command to display
        for (int i = 0; i < _commandsDisplay.Length; i++) {
            // Take a random potion from the recipe book and add it to the commands
            _commands[i] = _recipeBook.Recipes[rnd.Next(0, _recipeBook.Recipes.Count)];

            // Display it
            _commandsDisplay[i].sprite = _commands[i].Icon;
        }
    }
}
