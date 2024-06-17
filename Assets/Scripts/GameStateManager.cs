using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameStateManager : MonoBehaviour
{    
    [SerializeField] private GameObject _startWindow;

    [SerializeField] private GameObject _gameUIWindow;
    [SerializeField] private GameObject _countdown;
    //[SerializeField] private GameObject _gameUI;

    [SerializeField] private GameObject _endWindow;

    [SerializeField] private BalloonCreator _balloonCreator;
    [SerializeField] private ProgressManager _progressManager;
    [SerializeField] private ToysManager _toysManager;

    private void Awake() {
        StartMenuGameState();
    }

    public void StartMenuGameState() {
        _startWindow.SetActive(true);

        _gameUIWindow.SetActive(false);
        _endWindow.SetActive(false);
    }

    public void PlayNewGameState() {
        _gameUIWindow.SetActive(true);
        _countdown.SetActive(true);
        //_gameUI.SetActive(true);

        _startWindow.SetActive(false);
        _endWindow.SetActive(false);

        _progressManager.StartNewGame();
        _balloonCreator.CreateBalloons();
        _toysManager.StartNewGame();
    }

    public void ContinueGameState() {
        _gameUIWindow.SetActive(true);
        _countdown.SetActive(true);
        //_gameUI.SetActive(true);

        _startWindow.SetActive(false);
        _endWindow.SetActive(false);

        _progressManager.ContinueGame();
        _balloonCreator.CreateBalloons();
    }
    /*
    public void StartCountdownState() {
        _gameUIWindow.SetActive(true);
        _countdown.SetActive(true);
        //_gameUI.SetActive(false);

        _startWindow.SetActive(false);
        _endWindow.SetActive(false);

        _balloonCreator.CreateBalloons();
    }*/
        

    public void ActiveGameUI() {
        _countdown.SetActive(false);
        //_gameUI.SetActive(true);        
    }


    public void EndGameState() {
        _endWindow.SetActive(true);

        _startWindow.SetActive(false);
        _gameUIWindow.SetActive(false);

        _balloonCreator.EndGame();
    }


}
