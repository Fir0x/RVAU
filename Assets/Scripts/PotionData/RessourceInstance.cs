using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceInstance : MonoBehaviour
{
    private Ressource _ressourceData;
    private bool _isCrushed = false;

    private MeshFilter _meshFilter;
    private Material _material;
    private MeshCollider _meshCollider;
    private Rigidbody _rb;

    [SerializeField] private float _flightRotationSpeed = 50;

    public Ressource RessourceData { get { return _ressourceData; } }
    public Ingredient.Type RessourceType { get { return _ressourceData.IngredientType; } }

    private void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _material = GetComponent<MeshRenderer>().material;
        _meshCollider = GetComponent<MeshCollider>();
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (!_rb.useGravity)
            transform.RotateAround(transform.position, Vector3.up, _flightRotationSpeed * Time.deltaTime);
    }

    public void Fly()
    {
        _rb.isKinematic = true;
        _rb.useGravity = false;
        transform.Rotate(Vector3.right * 30);
    }

    public void Unfly()
    {
        _rb.isKinematic = false;
        _rb.velocity = Vector3.zero;
    }

    public void SetRessource(Ressource ressourceData)
    {
        _ressourceData = ressourceData;
        _meshFilter.mesh = _ressourceData.Mesh;
        _meshCollider.sharedMesh = _ressourceData.Mesh;
        _material.SetColor("_Color", _ressourceData.Color);
    }

    public void Crush()
    {
        if (!_isCrushed && _ressourceData.IngredientType == Ingredient.Type.CrushableRessource)
        {
            _ressourceData = (_ressourceData as CrushableRessource).EndRessource;
            _meshFilter.mesh = _ressourceData.Mesh;
            _meshCollider.sharedMesh = _ressourceData.Mesh;
        }

        _isCrushed = true;
    }

    public Ressource GetRessourceData()
    {
        return _ressourceData;
    }
}
