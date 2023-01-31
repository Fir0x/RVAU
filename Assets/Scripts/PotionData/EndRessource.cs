using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRessource", menuName = "")]
public class EndRessource : Ressource
{
    [SerializeField] private Color _color;

    public override Color Color { get { return _color; } }

    protected override void Awake()
    {
        base.Awake();

        _ingredientType = Type.EndRessource;
    }
}
