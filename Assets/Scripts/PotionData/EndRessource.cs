using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRessource", menuName = "")]
public class EndRessource : Ressource
{
    protected override void Awake()
    {
        base.Awake();

        _ingredientType = Type.EndRessource;
    }
}
