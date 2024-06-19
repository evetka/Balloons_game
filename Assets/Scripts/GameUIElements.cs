using System.Collections;
using UnityEngine;

public class GameUIElements : MonoBehaviour
{
    [SerializeField] GameObject _timer;
    [SerializeField] GameObject _score;

    public void ShowResult() {
        _timer.SetActive(false);
        StartCoroutine(nameof(ScaleScoreElements));
    }

    IEnumerator ScaleScoreElements() {
        for (float t = 0; t < 1.5f; t += Time.deltaTime * 3f) {
            _score.transform.localScale = Vector3.one * t;            
            yield return null;
        }
    }
}
