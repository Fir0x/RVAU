using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCrushableRessource", menuName = "")]
public class CrushableRessource : Ressource
{
    [SerializeField] private float _crushingDuration = 2.0f;
    [SerializeField] private EndRessource _endRessource;

    public float CrushingDuration { get { return _crushingDuration; } }
    public EndRessource EndRessource { get { return _endRessource; } }
    public override Color Color { get { return _endRessource.Color; } }

    protected override void Awake()
    {
        base.Awake();

        _ingredientType = Type.CrushableRessource;
    }
}
