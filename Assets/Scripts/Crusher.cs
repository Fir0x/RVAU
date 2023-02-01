using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{
    private RessourceInstance _processedRessource = null;
    private float _crushingDuration;

    private void OnTriggerEnter(Collider other)
    {
        var ressourceInstance = other.GetComponent<RessourceInstance>();
        if (ressourceInstance == null)
            return;

        AddRessource(ressourceInstance);
    }

/*    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Hello Exit");
        var otherRessourceInstance = other.GetComponent<RessourceInstance>();
        if (otherRessourceInstance == null)
            return;

        if (otherRessourceInstance == _processedRessource)
            _processedRessource = null;

    }*/
    public void AddRessource(RessourceInstance ressource)
    {
        if (_processedRessource != null || ressource.RessourceType != Ingredient.Type.CrushableRessource)
            return;

        _crushingDuration = (ressource.RessourceData as CrushableRessource).CrushingDuration;
        _processedRessource = ressource;

        ressource.GetComponent<Rigidbody>().isKinematic = true;
        ressource.transform.position = transform.position;
        ressource.transform.rotation = transform.rotation;

        StartCoroutine(CrushIngredient());
        // gravity ?
        // ressource.GetComponent<Rigidbody>().isKinematic = false;
    }

    public IEnumerator CrushIngredient()
    {
        yield return new WaitForSeconds(_crushingDuration);
        _processedRessource.Crush();
    }
}
