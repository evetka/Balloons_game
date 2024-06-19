using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashPaintEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _splashPaintEffect;

    public void SplashPaint() {
        _splashPaintEffect.Play();
    }
}
