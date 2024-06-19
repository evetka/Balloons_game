using TouchScript.Gestures;
using System.Collections;
using UnityEngine;

public class PlayerControllerWithTapGesture : MonoBehaviour {

    [SerializeField] private TapGesture _tapGesture;
    [SerializeField] private Balloon _baloons;
    [SerializeField] private bool _canTapOnBalloon = false;

    private void OnEnable() {
        StartCoroutine(nameof(TapOnBalloon));
        _tapGesture.Tapped += OnTap;
    }

    private void OnDisable() {
        _canTapOnBalloon = true;
        _tapGesture.Tapped -= OnTap;
    }

    private void OnTap(object sender, System.EventArgs e) {
        if (_canTapOnBalloon) {
            _baloons.Die();
        }        
    }

    IEnumerator TapOnBalloon() {
        yield return new WaitForSeconds(0.4f);
        _canTapOnBalloon = true;
    }

}
