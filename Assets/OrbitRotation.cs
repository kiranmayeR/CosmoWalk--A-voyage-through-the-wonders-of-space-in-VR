using UnityEngine;

public class OrbitRotation : MonoBehaviour
{
    public float speed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * speed);
    }

}