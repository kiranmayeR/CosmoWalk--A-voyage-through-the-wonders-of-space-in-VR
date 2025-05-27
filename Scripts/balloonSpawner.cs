using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonSpawner : MonoBehaviour
{
    public GameObject balloonPrefab;
    public int balloonCount;
    public Vector3 spawnAreaSize;

    void Start()
    {
        SpawnInitialBalloons();
    }

    void SpawnInitialBalloons()
    {
        for (int i = 0; i < balloonCount; i++)
        {
            SpawnBalloon();
        }
    }

    void SpawnBalloon()
    {
            Vector3 randomPos = GetRandomPosition();
            Instantiate(balloonPrefab, randomPos, Quaternion.identity);
        
    }

    Vector3 GetRandomPosition()
    {
        Vector3 center = transform.position;
        return new Vector3(
            UnityEngine.Random.Range(center.x - spawnAreaSize.x / 2, center.x + spawnAreaSize.x / 2),
            UnityEngine.Random.Range(center.y - spawnAreaSize.y / 2, center.y + spawnAreaSize.y / 2),
            UnityEngine.Random.Range(center.z - spawnAreaSize.z / 2, center.z + spawnAreaSize.z / 2)
        );
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}
