using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BalloonCreator : MonoBehaviour {

    [SerializeField] private ProgressManager _progressManager;

    [SerializeField] private Balloon _balloon;
    [SerializeField] private List<Color> _colorsBalloons = new List<Color>();
    private int x = 1;

    public void CreateBalloons() {
        StartCoroutine(nameof(CreateBallonsProcess));              
    }

    public void EndGame() {
        StopAllCoroutines();
    }

    private IEnumerator CreateBallonsProcess() {
        while (true) {
            Vector3 spawnPosition = new Vector3(Random.Range(2.5f, 7f) * x, transform.position.y, transform.position.z);
            Color color = _colorsBalloons[Random.Range(0, _colorsBalloons.Count)];
            
            Balloon newBalloon = Instantiate(_balloon, spawnPosition, Quaternion.identity, transform);
            
            newBalloon.Init(
                Random.Range(0.3f, 0.5f), //скорость полета шарика                
                color, 
                _progressManager);
            x *= -1;
            yield return new WaitForSeconds(1.2f);
        }
    }
}
