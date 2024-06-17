using UnityEngine;

public class Balloon : MonoBehaviour {

    [SerializeField] private float _maxY;
    [SerializeField] private Renderer _meshRenderer;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GameObject _collider;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private float _speedMove;

    private ProgressManager _progressManager;
    private Color _color;


    public void Init(float speed, Color color, ProgressManager progressManager) {
        _speedMove = speed;
        _color = color;
        _meshRenderer.materials[1].color = _color;
        _progressManager = progressManager;

    }

    private void Update() {
        if (transform.position.y > _maxY) {
            Destroy(gameObject, 1f);
        }
    }

    private void FixedUpdate() {
        _rigidbody.velocity += _speedMove * Vector3.up;
    }


    private void OnCollisionEnter(Collision collision) {
        if (collision.collider == null) {
            if (collision.collider.GetComponent<Balloon>()) {
                collision.rigidbody.AddForceAtPosition(collision.contacts[0].normal, collision.contacts[0].point);
            }
        }
    }

    public void Die() {
        ParticleSystem newParticleSystem = Instantiate(_particleSystem, transform.position, Quaternion.identity);
        newParticleSystem.startColor = _color;
        _collider.transform.localScale *= 2f;
        _progressManager.BallonHit(transform.position);
        Destroy(gameObject, 0.1f);
    }


}
