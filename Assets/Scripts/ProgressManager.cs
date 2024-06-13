using System.Collections;
using TMPro;
using UnityEngine;

public class ProgressManager : MonoBehaviour {
        
    [SerializeField] private int _score;
    [SerializeField] private int _timer;
    [SerializeField] private TMP_Text _textScore;
    [SerializeField] private TMP_Text _textTimer;

    [SerializeField] private Toy _toyPrefab;

    public void StartGame() {
        StartCoroutine(nameof(Timer));
    }
   
    public void BallonHit(Vector3 spawnToy) {        
        _score++;
        _textScore.text = _score.ToString();
        if(_score % 10 == 0 ) {
            CreateToy(spawnToy);
        }
    }

    public void CreateToy(Vector3 spawnToy) {
        Toy newToy = Instantiate(_toyPrefab, spawnToy, Quaternion.identity);
        newToy.ToyAnimation();
    }

    private IEnumerator Timer() {        
        while(true) {
            yield return new WaitForSeconds(1f);
            _timer++;
            _textTimer.text = _timer.ToString();
        }
    }
}
