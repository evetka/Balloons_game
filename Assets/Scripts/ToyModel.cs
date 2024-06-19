using System.Collections;
using UnityEngine;

public class ToyModel : MonoBehaviour {

    [SerializeField] private ParticleSystem _toyShowEffect;
    [SerializeField] private AnimationCurve _animationCurve;
    //[SerializeField] private Outline _outline;


    public void ToyModelAnimation(Vector3 finalPosition) {
        StartCoroutine(MoveToPosition(transform.position, finalPosition));
    }


    protected IEnumerator MoveToPosition(Vector3 startPosition, Vector3 finalPosition) {
        Vector3 a = startPosition; //начальная точка траектории
        Vector3 b = startPosition + Vector3.back + Vector3.up; //вторая точка траектории        
        Vector3 d = finalPosition;
        Vector3 c = d + Vector3.back * 3f;

        for (float t = 0; t < 1f; t += Time.deltaTime) {
            transform.position = Bezier.GetPoint(a, b, c, d, t);
            transform.localScale = new Vector3(_animationCurve.Evaluate(t), _animationCurve.Evaluate(t), _animationCurve.Evaluate(t));
            /*
            _outline.OutlineWidth = 10f - t * 8;
            if (t > 1f) {                
                _outline.enabled = false;
            }*/
            yield return null;
        }
    }

    public void Die() {
        Destroy(gameObject);
    }
}
