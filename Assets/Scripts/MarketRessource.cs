using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MarketRessource : MonoBehaviour
{
    [SerializeField] private int _ressourceIndex = -1;
    private Ressource _ressource;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private Bank _bank;

    private void Start()
    {
        if (_ressourceIndex >= 0)
        {
            _ressource = GameManager.Instance.GetRessource(_ressourceIndex);
            GetComponent<MeshFilter>().mesh = _ressource.Mesh;
            GetComponent<MeshCollider>().sharedMesh = _ressource.Mesh;
            GetComponent<Renderer>().material.color = _ressource.Color;
            _priceText.SetText(_ressource.Price.ToString());
        }
        else
        {
            Destroy(_priceText.gameObject);
            Destroy(gameObject);
        }
    }

    void OnMouseUpAsButton()
    {
        if (_bank.Buy(_ressourceIndex))
            EventRelay.Instance.RaiseBuyRessource(_ressourceIndex, true);
    }
}
