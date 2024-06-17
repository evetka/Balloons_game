using System.Collections;
using TMPro;
using UnityEngine;

public class ProgressManager : MonoBehaviour {

    [SerializeField] private int _score;
    [SerializeField] private int _timer;
    [SerializeField] private int _countdown;
    [SerializeField] private TMP_Text _textCountdown;
    [SerializeField] private TMP_Text _textScore;
    [SerializeField] private TMP_Text _textTimer;

    [SerializeField] private GameStateManager _gameStateManager;
    [SerializeField] private ToysManager _toysManager;


    public void StartNewGame() {
        _score = 0;
        _textScore.text = _score.ToString();
        _timer = 0;
        _textTimer.text = _timer.ToString();
        StartCoroutine(nameof(Countdown));
    }

    public void ContinueGame() {         
        _textScore.text = _score.ToString();
        _timer = 0;
        _textTimer.text = _timer.ToString();
        StartCoroutine(nameof(Countdown));        
    }

    public void BallonHit(Vector3 spawnToy) {
        _score++;
        _textScore.text = _score.ToString();
        if (_score % 2 == 0) {
            _toysManager.AssemblyToy(spawnToy);
        }
    }

    private IEnumerator Countdown() {
        _countdown = 3;
        while (_countdown > 0) {
            _textCountdown.text = _countdown.ToString();
            for (float t = 0; t < 1; t += Time.deltaTime) {
                _textCountdown.fontSize = t * 155f;
                yield return null;
            }
            _countdown--;
        }

        StartCoroutine(nameof(Timer));

        _gameStateManager.ActiveGameUI();
    }

    private IEnumerator Timer() {
        while (_timer < 50) {
            yield return new WaitForSeconds(1f);
            _timer++;
            _textTimer.text = _timer.ToString();
        }
        _gameStateManager.EndGameState();
    }


    
        
}
