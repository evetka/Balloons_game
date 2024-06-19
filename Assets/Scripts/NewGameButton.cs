using System.Collections;
using TouchScript.Gestures;
using UnityEngine;

public class NewGameButton : MonoBehaviour {

    [SerializeField] private TapGesture _tapGesture;
    [SerializeField] private GameStateManager _gameStateManager;
    [SerializeField] private bool _canTapNewGame = false;

    private void OnEnable() {
        StartCoroutine(nameof(TapCooldown));
        _tapGesture.Tapped += OnTap;
    }
    private void OnDisable() {
        _canTapNewGame = false;
        _tapGesture.Tapped -= OnTap;
    }

    private void OnTap(object sender, System.EventArgs e) {        
        if(_canTapNewGame) {
            _gameStateManager.PlayNewGameState();
        }        
    }

    IEnumerator TapCooldown() {
        yield return new WaitForSeconds(2f);
        _canTapNewGame = true;
    }
}
