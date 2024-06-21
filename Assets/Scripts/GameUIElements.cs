using System.Collections;
using UnityEngine;

public class GameUIElements : MonoBehaviour
{
    [SerializeField] GameObject _timer;
    [SerializeField] GameObject _score;

    public void ShowResult() {
        _timer.SetActive(false);
        StartCoroutine(nameof(UpScaleScoreElements));
    }

    public void ShowContinueUI() {
        _timer.SetActive(true);
        StartCoroutine(nameof(UnScaleScoreElements));
    }
    IEnumerator UnScaleScoreElements() {
        for (float t = 0; t > 1f; t -= Time.deltaTime * 3f) {
            _score.transform.localScale = Vector3.one * t;
            yield return null;
        }
        _score.transform.localScale = Vector3.one;
    }

    IEnumerator UpScaleScoreElements() {
        for (float t = 0; t < 1.5f; t += Time.deltaTime * 3f) {
            _score.transform.localScale = Vector3.one * t;            
            yield return null;
        }
        _score.transform.localScale = Vector3.one * 1.5f;
    }
}
