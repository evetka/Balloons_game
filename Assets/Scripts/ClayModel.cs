using System.Collections;
using UnityEngine;

public class ClayModel : MonoBehaviour {

    //[SerializeField] private ParticleSystem _toyShowEffect;
    [SerializeField] private AnimationCurve _animationCurve;
    private ToysManager _toysManager;

    public void Init(ToysManager toysManager) {
        _toysManager = toysManager;               
    }

    public void ClayModelAnimation(Vector3 startPosition, Vector3 finalPosition) {
        transform.position = startPosition;
        StartCoroutine(MoveToPosition(transform.position, finalPosition));        
    }


    private IEnumerator MoveToPosition(Vector3 startPosition, Vector3 finalPosition) {
        Vector3 a = startPosition; //начальная точка траектории
        Vector3 b = startPosition + Vector3.right * 3f + Vector3.up * 3f; //вторая точка траектории        
        Vector3 d = finalPosition;
        Vector3 c = d + Vector3.back * 3f;

        for (float t = 0; t < 1f; t += Time.deltaTime / 0.7f) {
            transform.position = Bezier.GetPoint(a, b, c, d, t);
            transform.localScale = new Vector3(_animationCurve.Evaluate(t), _animationCurve.Evaluate(t), _animationCurve.Evaluate(t));
                        
            yield return null;
        }
        _toysManager.CreateModelToy();
        gameObject.SetActive(false);
    }

}
