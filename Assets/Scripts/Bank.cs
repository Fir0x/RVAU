using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] private int _gold = 100;
    [SerializeField] private TMP_Text _goldCounter;

    private void Start()
    {
        _goldCounter.SetText(_gold.ToString());
    }

    public void Buy(Ressource ressource)
    {
        if (_gold >= ressource.Price)
        {
            _gold -= ressource.Price;
            _goldCounter.SetText(_gold.ToString());
            Debug.Log("Gold: " + _gold);
        }
        else
        {
            Debug.Log("Not enough gold");
        }
    }
}
