using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PaintTool : MonoBehaviour
{
    
    [SerializeField] private AnimationCurve _animationCurve;
    private ToysManager _toysManager;
    [SerializeField] private Outline _outline;

    public void Init(ToysManager toysManager) {
        _toysManager = toysManager;
    }


    public void PaintToolAnimation(Vector3 startPosition, Vector3 finalPosition) {
        _outline.enabled = true;
        transform.position = startPosition;
        StartCoroutine(MoveToPosition(transform.position, finalPosition));

    }

    

    private IEnumerator MoveToPosition(Vector3 startPosition, Vector3 finalPosition) {

        Vector3 a = startPosition; //начальная точка траектории
        Vector3 b = startPosition + Vector3.right + Vector3.up ; //вторая точка траектории        
        Vector3 d = finalPosition;
        Vector3 c = d + Vector3.back;

        for (float t = 0; t < 1f; t += Time.deltaTime * 2f) {
            transform.position = Vector3.Lerp(startPosition, finalPosition + new Vector3(-0.4f, 0f, -4f), 3 / t);
            transform.localScale = new Vector3(_animationCurve.Evaluate(t), _animationCurve.Evaluate(t), _animationCurve.Evaluate(t));
            
            yield return null;
        }
        yield return new WaitForSeconds(1.3f);
        _toysManager.CreatefinishToy();
        _outline.enabled = false;
        gameObject.SetActive(false);
    }

}
