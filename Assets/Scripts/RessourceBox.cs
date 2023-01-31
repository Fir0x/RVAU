using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceBox : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _ressourcePrefab;
    [SerializeField] Ressource _ressourceData;

    [Header("Debug")]
    [SerializeField] private float _debugSize = 0.02f;

    public void SpawnRessource()
    {
        var instance = Instantiate(_ressourcePrefab, _spawnPoint.position, Quaternion.identity);
        var ressourceInstance = instance.GetComponent<RessourceInstance>();
        ressourceInstance.SetRessource(_ressourceData);
    }

    private void OnDrawGizmos()
    {
        if (_spawnPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_spawnPoint.position, _debugSize);
    }
}
