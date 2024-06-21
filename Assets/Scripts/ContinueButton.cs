using System.Collections;
using TouchScript.Gestures;
using UnityEngine;

public class ContinueButton : MonoBehaviour {

    [SerializeField] private TapGesture _tapGesture;
    [SerializeField] private GameStateManager _gameStateManager;
    [SerializeField] private bool _canTapContinue = false;

    private void OnEnable() {
        StartCoroutine(nameof(TapCooldown));
        _tapGesture.Tapped += OnTap;
    }
    private void OnDisable() {
        _canTapContinue = false;
        _tapGesture.Tapped -= OnTap;
    }

    private void OnTap(object sender, System.EventArgs e) {
        if (_canTapContinue == true) {
            _gameStateManager.ContinueGameState();
        }            
    }

    IEnumerator TapCooldown() {   
        yield return new WaitForSeconds(2f);
        _canTapContinue = true;
    }
}
