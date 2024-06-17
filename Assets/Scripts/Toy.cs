using System.Collections;
using UnityEngine;

public class Toy : MonoBehaviour {

    //[SerializeField] private Transform _toyFinalPosition;
    [SerializeField] private ParticleSystem _toyShowEffect;
    [SerializeField] private Vector3 _positionOnShelf;
    

    public void ToyAnimation() {
        //Instantiate(_toyShowEffect, transform.position, Quaternion.identity);
        
        StartCoroutine(MoveToPosition(Vector3.down, _positionOnShelf));
    }

    
    IEnumerator MoveToPosition(Vector3 startPosition, Vector3 finalPosition) {
        Vector3 a = startPosition; //начальная точка траектории
        Vector3 b = startPosition + Vector3.back * 3.5f + Vector3.up * 2f; //вторая точка траектории        
        Vector3 d = finalPosition;
        Vector3 c = d + Vector3.back * 1f;
        
        for (float t = 0; t < 2f; t += Time.deltaTime) {
            transform.position = Bezier.GetPoint(a, b, c, d, t);
            yield return null;
        }        
    }

    public void Die() {
        Destroy(gameObject);
    }
}
