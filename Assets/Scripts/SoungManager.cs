using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoungManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _hitBallonSound = new List<AudioClip>();
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private float _backgroundVolume;
    [SerializeField] private float _hitEffectVolume;

    public void OnHitSoundPlay() {
        //_audioSource.pitch = Random.Range(-0.5f, 0.5f);
        //AudioSource.PlayClipAtPoint(ChoiceHitBallonSound(), Vector3.zero);
        _audioSource.PlayOneShot(ChoiceHitBallonSound(), _hitEffectVolume); 
    }


    public void OnPlayBGSound() {
        float volume = Mathf.Min(1f, _backgroundVolume);
        StartCoroutine(ChangeBGSoundVolume(volume, 3f));
    }

    public void OffPlayBGSound() {
        StartCoroutine(ChangeBGSoundVolume(0.1f, 2f));
    }

    IEnumerator ChangeBGSoundVolume(float finishVolume, float timer) {
        float startVolume = _audioSource.volume;
        for (float t = 0f; t < 1f; t += Time.deltaTime / timer) {            
            _audioSource.volume = Mathf.Lerp(startVolume, finishVolume, t);
            yield return null;
        }
        _audioSource.volume = finishVolume;
    }


    private AudioClip ChoiceHitBallonSound() {
        return _hitBallonSound[Random.Range(0, _hitBallonSound.Count)];
    }
}
