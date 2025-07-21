using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighterFlameStatus : MonoBehaviour
{
    private ParticleSystem ps;

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    public bool IsFlameOn()
    {
        return ps != null && ps.isPlaying;
    }
}


