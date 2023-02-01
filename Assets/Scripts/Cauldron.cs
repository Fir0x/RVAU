using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    private List<RecipeElement> _content;
    private Potion _createdPotion;
    private bool _isBrewing = false;

    [SerializeField] private MeshRenderer _liquidRenderer;
    private Material _liquidMaterial;
    [SerializeField] private Color _failColor;

    private PotionInstance _potionFlask;
    [SerializeField] private Transform _flaskWaitPosition;

    [Header("Debug")]
    [SerializeField] private float _debugRadius;

    private void Start()
    {
        if (_liquidRenderer == null)
            return;

        _liquidMaterial = _liquidRenderer.material;
        _liquidMaterial.SetFloat("_IsPotion", 0);
        _content = new List<RecipeElement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isBrewing || _createdPotion != null)
            Destroy(other.gameObject);

        var ressourceInstance = other.GetComponent<RessourceInstance>();
        if (ressourceInstance != null)
        {
            AddIngredient(ressourceInstance.RessourceData);
            Destroy(other.gameObject);
        }
        else
        {
            var potionInstance = other.GetComponent<PotionInstance>();
            if (potionInstance != null)
            {
                _potionFlask = potionInstance;
                _potionFlask.Fly();
                other.gameObject.transform.position = _flaskWaitPosition.position;
                StartCoroutine(ProducePotion());
            }
        }

    }

    public bool AddIngredient(Ingredient ingredient)
    {
        if (_isBrewing)
            return false;

        RecipeElement ingredientGroup = _content.Find(e => e.GetIngredientGUID() == ingredient.Guid);
        if (ingredientGroup != null)
            ingredientGroup.IncrementCount();
        else
            _content.Add(new RecipeElement(ingredient));

        return true;
    }

    public IEnumerator ProducePotion()
    {
        _createdPotion = GameManager.Instance.GetPotion(_content);

        const float failDuration = 5.0f;
        float productionDuration = _createdPotion ? _createdPotion.ProductionDuration : failDuration;
        _isBrewing = true;

        _liquidMaterial.SetFloat("_IsPotion", 1);
        _liquidMaterial.SetFloat("_IsBrewing", 1);

        if (_createdPotion == null)
            _liquidMaterial.SetColor("_Potion_color", _failColor);

        yield return new WaitForSeconds(productionDuration);

        _isBrewing = false;
        _liquidMaterial.SetFloat("_IsBrewing", 0);

        _potionFlask.SetPotion(_createdPotion);
    }

    public Potion RetrievePotion()
    {
        if (_isBrewing)
            return null;

        _liquidMaterial.SetFloat("_IsPotion", 0);
        _potionFlask.Unfly();

        return _createdPotion;
    }

    private void OnDrawGizmos()
    {
        if (_flaskWaitPosition == null)
            return;
            
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(_flaskWaitPosition.position, _debugRadius);
    }
}
