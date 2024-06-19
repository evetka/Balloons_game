using System.Collections;
using UnityEngine;


public class GameStateManager : MonoBehaviour
{    
    [SerializeField] private GameObject _startWindow;
    [SerializeField] private GameObject _countdown;
    [SerializeField] private GameObject _gameUI;
    [SerializeField] private GameObject _resultWindow;
    [SerializeField] private GameObject _endWindow;

    [SerializeField] private GameUIElements _gameUIElements;

    [SerializeField] private BalloonCreator _balloonCreator;
    [SerializeField] private ProgressManager _progressManager;
    [SerializeField] private ToysManager _toysManager;
    [SerializeField] private SoungManager _soungManager;

    [SerializeField] private ParticleSystem _particleSystem;


    private void Awake() {
        StartMenuGameState();
    }

    public void StartMenuGameState() {        
        _startWindow.SetActive(true);

        _gameUI.SetActive(false);
        _endWindow.SetActive(false);
    }

    public void PlayNewGameState() {
        _countdown.SetActive(true);

        _startWindow.SetActive(false);
        _gameUI.SetActive(false);
        _endWindow.SetActive(false);

        _progressManager.StartNewGame();
        _balloonCreator.CreateBalloons();
        _toysManager.StartNewGame();
        _soungManager.OnPlayBGSound();
    }

    public void ContinueGameState() {
        _countdown.SetActive(true);

        _startWindow.SetActive(false);
        _gameUI.SetActive(false);
        _endWindow.SetActive(false);

        _progressManager.ContinueGame();
        _balloonCreator.CreateBalloons();
        _soungManager.OnPlayBGSound();
    }
    
    public void OffCountdownWindow() {
        _countdown.SetActive(false);
        _gameUI.SetActive(true);
        _gameUIElements.ShowContinueUI();
    }

    public void ResultWindow() {
        _soungManager.Applause();
        Instantiate(_particleSystem);
        _balloonCreator.EndGame();
        _soungManager.OffPlayBGSound();

        _resultWindow.SetActive(true);
        _gameUI.SetActive(true);
        _gameUIElements.ShowResult();
        Invoke("EndGameState", 5f);
    }

    public void EndGameState() {
        _resultWindow.SetActive(false);
        _gameUI.SetActive(false);
        _endWindow.SetActive(true);        
    }

    
    
}
