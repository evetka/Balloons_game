using TouchScript.Gestures;
using System.Collections;
using UnityEngine;

public class PlayerControllerWithTapGesture : MonoBehaviour {

    [SerializeField] private TapGesture _tapGesture;
    [SerializeField] private Balloon _baloons;

    private void OnEnable() {        
        _tapGesture.Tapped += OnTap;
    }

    private void OnDisable() {        
        _tapGesture.Tapped -= OnTap;
    }

    private void OnTap(object sender, System.EventArgs e) {
            _baloons.Die();
    }


}
