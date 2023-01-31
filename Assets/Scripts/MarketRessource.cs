using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MarketRessource : MonoBehaviour
{
    [SerializeField] private Ressource _ressource;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private Bank _bank;

    private void Start()
    {
        if (_ressource)
        {
            this.GetComponent<MeshFilter>().mesh = _ressource.Mesh;
            this.GetComponent<MeshCollider>().sharedMesh = _ressource.Mesh;
            this.GetComponent<Renderer>().material.color = _ressource.Color;
            _priceText.SetText(_ressource.Price.ToString());
        }
        else
        {
            _priceText.SetText("");
            Destroy(this.gameObject);
        }
    }

    void OnMouseUpAsButton()
    {
        Debug.Log("Buy " + _ressource.Name);
        _bank.Buy(_ressource);
    }
}
