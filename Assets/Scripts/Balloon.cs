using UnityEngine;

public class Balloon : MonoBehaviour {

    [SerializeField] private float _maxY;
    [SerializeField] private Renderer _meshRenderer;   
    [SerializeField] private ParticleSystem _particleSystem;

    private ProgressManager _progressManager;
    private float _speedMove;
    private Color _color;



    public void Init(float speed, Color color, ProgressManager progressManager) {
        _speedMove = speed;
        _color = color;        
        _meshRenderer.material.color = _color;
        _progressManager = progressManager;
        
    }

    private void Update() {
        transform.position += _speedMove * Time.deltaTime * Vector3.up;
        if (transform.position.y > _maxY) {
            Destroy(gameObject, 1f);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider == null) {
            if(collision.collider.TryGetComponent(out Balloon balloon)) {
                transform.position += _speedMove * collision.contacts[0].normal;
            }
        }
    }

    public void Die() {
        ParticleSystem newParticleSystem = Instantiate(_particleSystem, transform.position, Quaternion.identity);
        newParticleSystem.startColor = _color;
        _progressManager.BallonHit(transform.position);
        Destroy(gameObject);
    }


}
