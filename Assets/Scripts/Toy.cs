using System.Collections;
using UnityEngine;

public class Toy : MonoBehaviour {

    [SerializeField] private Vector3 _positionOnShelf;
    [SerializeField] private AnimationCurve _animationCurve;
    [SerializeField] private Outline _outline;


    public void ToyAnimation() {  
        StartCoroutine(MoveToPosition(new Vector3(0f, 0f, -4f), _positionOnShelf));
    }

    
    IEnumerator MoveToPosition(Vector3 startPosition, Vector3 finalPosition) {
        Vector3 a = startPosition; //начальная точка траектории
        Vector3 b = startPosition + Vector3.back * 3.5f + Vector3.up * 2f; //вторая точка траектории        
        Vector3 d = finalPosition;
        Vector3 c = d + Vector3.back * 1f;
        
        for (float t = 0; t < 2f; t += Time.deltaTime) {
            transform.position = Bezier.GetPoint(a, b, c, d, t);
            transform.localScale = new Vector3(_animationCurve.Evaluate(t), _animationCurve.Evaluate(t), _animationCurve.Evaluate(t));
            
            if(t > 1f) {
                _outline.enabled = false;
            }

            yield return null;
        }
        
    }

    public void Die() {
        Destroy(gameObject);
    }
}
