using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCandleOnTrigger : MonoBehaviour
{
    [SerializeField] private ToggleParticle candleFlame;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("LighterFlame"))
        {
            var flameStatus = other.GetComponent<LighterFlameStatus>();
            if (flameStatus != null && flameStatus.IsFlameOn())
            {
                candleFlame?.Play();
            }
        }
    }
}
