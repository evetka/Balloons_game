using System.Collections;
using UnityEngine;

public class ToyPrint : MonoBehaviour {

    [SerializeField] private Material _printMaterial;
    [SerializeField] private ParticleSystem _toyShowEffect;
    [SerializeField] private AnimationCurve _animationCurve;
    [SerializeField] Animator _animator;
    //[SerializeField] private Outline _outline;
    
    public void Init(Texture print, Vector3 startPosition) {
        transform.position = startPosition;
        _printMaterial.mainTexture = print;
    }

    public void ToyModelAnimation(Vector3 finalPosition) {
        _animator.SetTrigger("Fly");
        StartCoroutine(MoveToPosition(transform.position, finalPosition));
    }

    protected IEnumerator MoveToPosition(Vector3 startPosition, Vector3 finalPosition) {
        Vector3 a = startPosition; //начальная точка траектории
        Vector3 b = startPosition + Vector3.back * 6.5f + Vector3.up * 5f; //вторая точка траектории        
        Vector3 d = finalPosition;
        Vector3 c = d + Vector3.back * 3f;

        for (float t = 0; t < 2f; t += Time.deltaTime) {
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
        gameObject.SetActive(false);
    }
}
