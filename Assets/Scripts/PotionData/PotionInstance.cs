using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionInstance : MonoBehaviour
{
    private Rigidbody _rb;
    private Potion _potionData;
    [SerializeField] private MeshRenderer _liquidRenderer;
    private Material _liquidMaterial;

    [SerializeField] private float _flightRotationSpeed = 50;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _liquidMaterial = _liquidRenderer.material;
        _liquidMaterial.SetFloat("_Fill_percentage", 0.0f);
    }

    private void Update()
    {
        if (!_rb.useGravity)
            transform.RotateAround(transform.position, Vector3.up, _flightRotationSpeed * Time.deltaTime);
    }

    public void SetPotion(Potion potionData)
    {
        if (potionData == null)
        {
            Destroy(gameObject);
            return;
        }

        _potionData = potionData;
        _liquidMaterial.SetFloat("_Fill_percentage", 1.0f);
        _liquidMaterial.SetColor("_Top_color", _potionData.TopColor);
        _liquidMaterial.SetColor("_Base_color", _potionData.BaseColor);
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
}
