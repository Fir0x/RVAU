using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionInstance : MonoBehaviour
{
    private Rigidbody _rb;
    private Potion _potionData;
    [SerializeField] private MeshRenderer _liquidRenderer;
    private Material _liquidMaterial;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _liquidMaterial = _liquidRenderer.material;
        _liquidMaterial.SetFloat("_Fill_percentage", 0.0f);
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
    }

    public void Unfly()
    {
        _rb.isKinematic = false;
        _rb.velocity = Vector3.zero;
        _rb.useGravity = true;
    }
}
