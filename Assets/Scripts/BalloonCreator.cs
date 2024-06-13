using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BalloonCreator : MonoBehaviour {

    [SerializeField] private ProgressManager _progressManager;

    [SerializeField] private List<Balloon> _balloons = new List<Balloon>();
    [SerializeField] private List<Color> _colorsBalloons = new List<Color>();
    [SerializeField] private List<Material> _materialBalloons = new List<Material>();


    public void StartGame() {
        StartCoroutine(nameof(CreateBallons));
        _progressManager.StartGame();
        
    }
        
    private IEnumerator CreateBallons() {
        while (true) {
            Vector3 spawnPosition = new Vector3(Random.Range(-7f, 7f), transform.position.y, transform.position.z);
            int index = Random.Range(0, _balloons.Count);
            Balloon newBalloon = Instantiate(_balloons[index], spawnPosition, Quaternion.identity, transform);
            
            Color color = _colorsBalloons[Random.Range(0, _colorsBalloons.Count)];

            newBalloon.Init(
                Random.Range(0.6f, 1.5f),                 
                color, 
                _progressManager);
            
            yield return new WaitForSeconds(1f);
        }
    }
}
