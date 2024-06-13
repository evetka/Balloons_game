using TouchScript.Gestures;
using UnityEngine;

public class PlayerControllerWithTapGesture : MonoBehaviour {

    [SerializeField] private TapGesture _tapGesture;
    [SerializeField] private Balloon _baloons;

    private void OnEnable() {
        if (_tapGesture == null) {
            _tapGesture = GetComponent<TapGesture>();
            if (_tapGesture == null) {
                Debug.LogError("На объект не назначен скрипт TapGesture");
                return;
            }
        }

        // Подписка на событие жеста
        _tapGesture.Tapped += OnTap;
    }


    private void OnDisable() {
        // Отписка от событий жестов
        if (_tapGesture != null) {
            _tapGesture.Tapped -= OnTap;
        }
    }

    private void OnTap(object sender, System.EventArgs e) {
        if (sender is TapGesture gesture) {
            _baloons.Die();
        }
    }


}
