using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketRessource : MonoBehaviour
{
    [SerializeField] private Ressource _ressource;
    [SerializeField] private Bank _bank;

    private void Start()
    {
        if (_ressource)
        {
            this.GetComponent<MeshFilter>().mesh = _ressource.Mesh;
            this.GetComponent<MeshCollider>().sharedMesh = _ressource.Mesh;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void OnMouseUpAsButton()
    {
        Debug.Log("Buy " + _ressource.Name);
        _bank.Buy(_ressource);
    }
}
