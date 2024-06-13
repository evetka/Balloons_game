using TouchScript.Gestures;
using UnityEngine;

public class PlayButton : MonoBehaviour {

    [SerializeField] private TapGesture _tapGesture;
    [SerializeField] private BalloonCreator _balloonCreator;

    private void Start() {
        if (_tapGesture == null) {
            _tapGesture = GetComponent<TapGesture>();
            if (_tapGesture == null) {
                Debug.LogError("�� ������ �� �������� ������ TapGesture");
                return;
            }
        }

        // �������� �� ������� �����
        _tapGesture.Tapped += OnTap;
    }

    private void OnTap(object sender, System.EventArgs e) {
        if (sender is TapGesture gesture) {
            _balloonCreator.StartGame();
            gameObject.SetActive(false);
        }
    }

    private void OnDestroy() {
        // ������� �� ������� ������
        if (_tapGesture != null) {
            _tapGesture.Tapped -= OnTap;
        }
    }
}
