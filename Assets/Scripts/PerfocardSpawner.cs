using Scripts;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PerfocardSpawner : MonoBehaviour
{
    [SerializeField] private Transform RotateLeftSpawnPoint;
    [SerializeField] private Transform RotateRightSpawnPoint;
    [SerializeField] private Transform MoveForwardSpawnPoint;

    [SerializeField] private GameObject RotateLeftPrefab;
    [SerializeField] private GameObject RotateRightPrefab;
    [SerializeField] private GameObject MoveForwardPrefab;

    private Dictionary<Type, GameObject> _prefabsExamplers = new Dictionary<Type, GameObject>();


    public void Start()
    {
        SpawnAllPerfocards();
    }


    public void RespawnPerfocards()
    {
        foreach (var prefab in _prefabsExamplers.Values)
        {
            Destroy(prefab);
        }
        _prefabsExamplers.Clear();
        SpawnAllPerfocards();
    }

    public void RespawnPerfocard(Type perfocardType)
    {
        _prefabsExamplers.TryGetValue(perfocardType, out GameObject perfocard);
        if (perfocard is null)
            return;
        Destroy(perfocard);
        if (perfocardType == typeof(RotateLeftPerfocard))
            _prefabsExamplers[perfocardType] = Instantiate(RotateLeftPrefab, RotateLeftSpawnPoint.position, Quaternion.Euler(0, -90, 0));
        if (perfocardType == typeof(RotateRightPerfocard))
            _prefabsExamplers[perfocardType] = Instantiate(RotateRightPrefab, RotateRightSpawnPoint.position, Quaternion.Euler(0, -90, 0));
        if (perfocardType == typeof(MoveForwardPerfocard))
            _prefabsExamplers[perfocardType] = Instantiate(MoveForwardPrefab, MoveForwardSpawnPoint.position, Quaternion.Euler(0, -90, 0));
    }

    private void SpawnAllPerfocards()
    {
        List<Transform> SpawnPoints = new List<Transform>() {RotateLeftSpawnPoint, RotateRightSpawnPoint, MoveForwardSpawnPoint};

        Transform nextSpawnPoint =  SpawnPoints[UnityEngine.Random.Range(0, SpawnPoints.Count)];
        SpawnPoints.Remove(nextSpawnPoint);
        _prefabsExamplers.Add(typeof(RotateLeftPerfocard), Instantiate(RotateLeftPrefab, nextSpawnPoint.position, Quaternion.Euler(0, -90, 0)));
        
        nextSpawnPoint =  SpawnPoints[UnityEngine.Random.Range(0, SpawnPoints.Count)];
        SpawnPoints.Remove(nextSpawnPoint);
        _prefabsExamplers.Add(typeof(RotateRightPerfocard), Instantiate(RotateRightPrefab, nextSpawnPoint.position, Quaternion.Euler(0, -90, 0)));

        nextSpawnPoint =  SpawnPoints[UnityEngine.Random.Range(0, SpawnPoints.Count)];
        SpawnPoints.Remove(nextSpawnPoint);
        _prefabsExamplers.Add(typeof(MoveForwardPerfocard), Instantiate(MoveForwardPrefab, nextSpawnPoint.position, Quaternion.Euler(0, -90, 0)));
    }
}
