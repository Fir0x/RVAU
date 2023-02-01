using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaskSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _flaskPrefab;
    
    private MeshCollider _flaskCollider;

    public void SpawnFlask()
    {
        GameObject flask = Instantiate(_flaskPrefab, transform.position, Quaternion.identity, transform.parent);
        flask.transform.Rotate(-90, 0, 0);
        _flaskCollider = flask.GetComponent<MeshCollider>();
    }

    // At the start of the game, spawn a flask
    public void Start()
    {
        SpawnFlask();
    }

    // When the previous flask exits the spawner, spawn a new one
    public void OnTriggerExit(Collider other)
    {
        if (other == _flaskCollider)
            SpawnFlask();
    }
}
