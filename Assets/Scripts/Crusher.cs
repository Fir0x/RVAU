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

        Debug.Log("OnEnterTrigger");

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


        ressource.transform.position = new Vector3(-0.859f, 0.605f, 0.3788981f);
        ressource.transform.rotation = transform.rotation;

        ressource.Fly();

        StartCoroutine(CrushIngredient(ressource));
    }

    public IEnumerator CrushIngredient(RessourceInstance ressource)
    {
        yield return new WaitForSeconds(_crushingDuration);
        _processedRessource.Crush();

        ressource.Unfly();


    }
}
