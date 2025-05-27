using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] balloons; // Array to hold multiple balloons
    private Vector3[] startPositions;
    private float[] speeds;
    private float[] heights;

    void Start()
    {
        int count = balloons.Length;
        startPositions = new Vector3[count];
        speeds = new float[count];
        heights = new float[count];

        for (int i = 0; i < count; i++)
        {
            startPositions[i] = balloons[i].transform.position;

            // Assign a random speed and height within a reasonable range
            speeds[i] = Random.Range(1.5f, 3.0f); // Different speed for each balloon
            heights[i] = Random.Range(0.5f, 1.5f); // Different height for each balloon
        }
    }

    void Update()
    {
        for (int i = 0; i < balloons.Length; i++)
        {
            float newY = startPositions[i].y + Mathf.Sin(Time.time * speeds[i]) * heights[i];
            balloons[i].transform.position = new Vector3(startPositions[i].x, newY, startPositions[i].z);
        }
    }
}
