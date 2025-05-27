using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonBurst : MonoBehaviour
{
    private ParticleSystem burstEffect;
    private AudioSource balloonPopAudio;
    public GameObject balloonVisual; 
    private Collider col;

    void Start()
    {
        burstEffect = GetComponentInChildren<ParticleSystem>();
        balloonPopAudio = GetComponent<AudioSource>();
        col = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // or use hand/controller tag
        {
            // Play particle effect
            if (burstEffect != null)
                burstEffect.Play();

            if (balloonPopAudio != null)
                balloonPopAudio.Play();

            // Hide balloon
            balloonVisual.SetActive(false);

            // Disable collider to avoid repeated triggers
            col.enabled = false;

            // Destroy after particle effect ends
            Destroy(gameObject, burstEffect.main.duration);
        }
    }
}
