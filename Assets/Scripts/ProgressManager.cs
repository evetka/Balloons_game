using System.Collections;
using TMPro;
using UnityEngine;

public class ProgressManager : MonoBehaviour {

    [SerializeField] private int _score;
    [SerializeField] private int _timer;
    [SerializeField] private int _toys;
    [SerializeField] private int _countdown;
    [SerializeField] private TMP_Text _textCountdown;
    [SerializeField] private TMP_Text _textBallons;
    [SerializeField] private TMP_Text _textTimer;
    [SerializeField] private TMP_Text _textToys;


    [SerializeField] private GameStateManager _gameStateManager;
    [SerializeField] private ToysManager _toysManager;
    [SerializeField] private SoungManager _soungManager;


    public void StartNewGame() {
        _score = 0;
        _textBallons.text = _score.ToString();
        _timer = 0;
        _textTimer.text = _timer.ToString();
        _toys = 0;
        _textToys.text = _toys.ToString();
        StartCoroutine(nameof(Countdown));
    }

    public void ContinueGame() {         
        _textBallons.text = _score.ToString();
        _textToys.text = _toys.ToString();
        _timer = 0;
        _textTimer.text = _timer.ToString();
        StartCoroutine(nameof(Countdown));        
    }

    public void BallonHit(Vector3 spawnToy) {
        _soungManager.OnHitSoundPlay();
        _score++;
        _textBallons.text = _score.ToString();
        if (_score % 2 == 0) {
            _toysManager.AssemblyToy(spawnToy);
        }
    }

    public void AddToyScore(int score) {
        _toys = score;
        _textToys.text = _toys.ToString();
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

        _gameStateManager.OffCountdownWindow();
    }

    private IEnumerator Timer() {
        while (_timer < 30) {
            yield return new WaitForSeconds(1f);
            _timer++;
            _textTimer.text = _timer.ToString();
        }
        _gameStateManager.ResultWindow();        
    }


    
        
}
