using System.Collections.Generic;
using UnityEngine;

public class BoidSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _boidPrefabs;
    [SerializeField] private float _boidsCount;
    [SerializeField] private float _spawnRadius;
    [SerializeField] private float _aligmentMultiplier;
    [SerializeField] private float _cohesionMultiplier;
    [SerializeField] private float _separationMultiplier;
    [SerializeField] private GameObject _leader;
    public List<Boid> ActiveBoids = new();

    public void SpawnBoids()
    {
        for(int i = 0; i < _boidsCount; i++)
        {
            Vector3 position = Random.insideUnitSphere * _spawnRadius;
            Quaternion rotation = Random.rotation;

            int index = Random.Range(0, _boidPrefabs.Count);
            GameObject _boidPrefab = _boidPrefabs[index];
            GameObject boid = Instantiate(_boidPrefab, position, rotation);
            Boid boidScript = boid.GetComponent<Boid>();
            ActiveBoids.Add(boidScript);
            boidScript.SetValuesMultiplier(_aligmentMultiplier, _cohesionMultiplier, _separationMultiplier);
            boidScript.SetLeader(_leader);
        }
    }

    private void Update()
    {
        foreach(Boid boid in ActiveBoids)
        {
            boid.SetValuesMultiplier(_aligmentMultiplier, _cohesionMultiplier, _separationMultiplier);
        }
    }

}
