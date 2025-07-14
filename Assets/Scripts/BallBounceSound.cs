using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounceSound : MonoBehaviour
{
    [SerializeField] private AudioClip bounceClip;
    [SerializeField] private float volumeMultiplier = 0.1f;
    [SerializeField] private float minVolume = 0.1f;
    [SerializeField] private float maxVolume = 1.0f;

    private AudioSource audioSource;
    private Rigidbody rb;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Only trigger sound when hitting the floor
        if (collision.gameObject.CompareTag("Floor"))
        {
            float speed = rb.velocity.magnitude;
            float volume = Mathf.Clamp(speed * volumeMultiplier, minVolume, maxVolume);
            audioSource.PlayOneShot(bounceClip, volume);
        }
    }
}