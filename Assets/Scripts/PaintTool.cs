using System.Collections;
using UnityEngine;

public class PaintTool : MonoBehaviour
{
    //[SerializeField] private ParticleSystem _toyShowEffect;
    [SerializeField] private AnimationCurve _animationCurve;
    private ToysManager _toysManager;
    [SerializeField] private Outline _outline;

    public void Init(ToysManager toysManager) {
        _toysManager = toysManager;
    }


    public void PaintToolAnimation(Vector3 startPosition, Vector3 finalPosition) {
        transform.position = startPosition;
        StartCoroutine(MoveToPosition(transform.position, finalPosition));

    }



    private IEnumerator MoveToPosition(Vector3 startPosition, Vector3 finalPosition) {

        Vector3 a = startPosition; //начальная точка траектории
        Vector3 b = startPosition + Vector3.right + Vector3.up ; //вторая точка траектории        
        Vector3 d = finalPosition;
        Vector3 c = d + Vector3.back;

        for (float t = 0; t < 1f; t += Time.deltaTime * 2f) {
            //transform.position = Bezier.GetPoint(a, b, c, d, t);
            transform.position = Vector3.Lerp(startPosition, finalPosition + new Vector3(-0.4f, 0f, -4f), 3 / t);
            transform.localScale = new Vector3(_animationCurve.Evaluate(t), _animationCurve.Evaluate(t), _animationCurve.Evaluate(t));
            /*
            _outline.OutlineWidth = 10f - t * 8;
            if (t > 1f) {
                _outline.enabled = false;
            }*/
            yield return null;
        }
        yield return new WaitForSeconds(1.3f);
        _toysManager.CreatefinishToy();
        gameObject.SetActive(false);
    }

}
