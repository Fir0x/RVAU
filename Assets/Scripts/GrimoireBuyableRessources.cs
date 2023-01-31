using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrimoireBuyableRessources : MonoBehaviour
{
    [SerializeField] private Ressource _ressource;
    [SerializeField] private TMP_Text _nameText;

    private void Start()
    {
        if (_ressource)
        {
            this.GetComponent<MeshFilter>().mesh = _ressource.Mesh;
            _nameText.SetText(_ressource.Name);
        }
        else
        {
            _nameText.SetText("");
            Destroy(this.gameObject);
        }
    }
}
