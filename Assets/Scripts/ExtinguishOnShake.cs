using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguishOnShake : MonoBehaviour
{
    [SerializeField] private ToggleParticle candleFlame;
    [SerializeField] private float extinguishSpeed = 1.5f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (candleFlame == null || rb == null) return;
        if (rb.velocity.magnitude > extinguishSpeed)
        {
            candleFlame.Stop();
        }
    }
}

