using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrimoireUnbuyableRessources : MonoBehaviour
{
    [SerializeField] private CrushableRessource _ressource;
    [SerializeField] private MeshFilter _childMeshFilter;
    [SerializeField] private TMP_Text _childNameText;

    private void Start()
    {
        if (_ressource)
        {
            this.GetComponent<MeshFilter>().mesh = _ressource.Mesh;
            _childMeshFilter.mesh = _ressource.EndRessource.Mesh;
            _childNameText.SetText(_ressource.EndRessource.Name);
        }
        else
        {
            Destroy(this.gameObject);
            Destroy(_childMeshFilter.gameObject);
            Destroy(_childNameText.gameObject);
        }
    }
}
