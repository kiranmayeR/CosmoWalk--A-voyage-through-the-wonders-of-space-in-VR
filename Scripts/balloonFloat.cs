using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonFloat : MonoBehaviour
{
    public float floatSpeed = 0.5f;     // Speed of floating
    public float floatHeight = 0.5f;    // Max height variation

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        floatSpeed = Random.Range(0.3f, 0.8f);
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
