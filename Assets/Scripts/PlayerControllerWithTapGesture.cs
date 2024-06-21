using TouchScript.Gestures;
using System.Collections;
using UnityEngine;

public class PlayerControllerWithTapGesture : MonoBehaviour {

    [SerializeField] private PressGesture _pressGesture;
    [SerializeField] private Balloon _baloons;

    private void OnEnable() {
        _pressGesture.Pressed += PressGestures;
    }

    private void OnDisable() {
        _pressGesture.Pressed -= PressGestures;
    }

    private void PressGestures(object sender, System.EventArgs e) {
        _baloons.Die();
    }

}
