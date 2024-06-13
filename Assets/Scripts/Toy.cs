using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Toy : MonoBehaviour {

    [SerializeField] private Vector3 _toyIconPosition;
    [SerializeField] private ParticleSystem _toyShowEffect;


    public void ToyAnimation() {
        Instantiate(_toyShowEffect, transform.position, Quaternion.identity);
        StartCoroutine(AddScoreAnimation());
    }

    IEnumerator AddScoreAnimation() {
        Vector3 a = transform.position; //начальная точка траектории
        Vector3 b = transform.position + Vector3.back * 6.5f + Vector3.down * 5f; //вторая точка траектории        
        Vector3 d = _toyIconPosition;
        Vector3 c = d + Vector3.back * 6f;
        
        for (float t = 0; t < 1f; t += Time.deltaTime) {
            transform.position = Bezier.GetPoint(a, b, c, d, t);
            yield return null;
        }        
    }
}
