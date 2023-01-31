using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrimoireUnbuyableRessources : MonoBehaviour
{
    [SerializeField] private CrushableRessource _ressource;
    [SerializeField] private GameObject _child;
    [SerializeField] private TMP_Text _childNameText;

    private void Start()
    {
        if (_ressource)
        {
            this.GetComponent<MeshFilter>().mesh = _ressource.Mesh;
            this.GetComponent<Renderer>().material.color = _ressource.Color;
            _child.GetComponent<MeshFilter>().mesh = _ressource.EndRessource.Mesh;
            _child.GetComponent<Renderer>().material.color = _ressource.Color;
            _childNameText.SetText(_ressource.EndRessource.Name);
        }
        else
        {
            Destroy(this.gameObject);
            Destroy(_child);
            Destroy(_childNameText.gameObject);
        }
    }
}
