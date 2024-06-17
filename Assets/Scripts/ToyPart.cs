using System.Collections;
using UnityEngine;

public class ToyPart : MonoBehaviour {

    //[SerializeField] private Transform _toyFinalPosition;
    [SerializeField] private ParticleSystem _toyShowEffect;
    [SerializeField] private Vector3 _positionOnShelf;


    public void ToysPartAnimation(Vector3 finalPosition) {
        //Instantiate(_toyShowEffect, transform.position, Quaternion.identity);

        StartCoroutine(MoveToPosition(transform.position, finalPosition));
    }



    IEnumerator MoveToPosition(Vector3 startPosition, Vector3 finalPosition) {
        Vector3 a = startPosition; //начальная точка траектории
        Vector3 b = startPosition + Vector3.back * 6.5f + Vector3.up * 5f; //вторая точка траектории        
        Vector3 d = finalPosition;
        Vector3 c = d + Vector3.back * 3f;

        for (float t = 0; t < 2f; t += Time.deltaTime) {
            transform.position = Bezier.GetPoint(a, b, c, d, t);
            yield return null;
        }
    }
      

    public void Die() {
        Destroy(gameObject);
    }
}
