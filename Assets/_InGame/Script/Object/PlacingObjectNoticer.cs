using System.Collections;
using System.Collections.Generic;
using _TestObject;
using UnityEngine;

public class PlacingObjectNoticer : MonoBehaviour
{
    public bool _isSuccess = true;

    [SerializeField]
    ParticleSystem 
        _successParticle,
        _failedParticle;
    [SerializeField]
    AudioSource
        _successAudio,
        _failedAudio;


    // Start is called before the first frame update
    void Start()
    {
        if (!_isSuccess)
        {
            ParticleSystem _tempt = _successParticle;
            _successParticle = _failedParticle;
            _failedParticle = _tempt;

            AudioSource _temptSound = _successAudio;
            _successAudio = _failedAudio;
            _failedAudio = _temptSound;
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {

        if (!other.gameObject.GetComponent<TestObject>())
            return;

        if (other.gameObject.GetComponent<TestObject>().IsCorrectObject)
        {
            _successParticle.Play();
            _successAudio.Play();
            Spawner_practice.instance.DeleteObject(other.gameObject,_isSuccess);
        }
        else
        {
            _failedParticle.Play();
            _failedAudio.Play();
            Spawner_practice.instance.DeleteObject(other.gameObject, !_isSuccess);
        }

    }
}
