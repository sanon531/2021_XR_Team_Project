using System.Collections;
using System.Collections.Generic;
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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (!other.gameObject.GetComponent<CheckObject>())
            return;

        if (other.gameObject.GetComponent<CheckObject>()._objectStatus == ObjectStatus.Fine)
        {
            _successParticle.Play();
            _successAudio.Play();
            Spawner_practice.instance.DeleteObject(_isSuccess);
            Destroy(other.gameObject);
        }
        else
        {
            _failedParticle.Play();
            _failedAudio.Play();
            Spawner_practice.instance.DeleteObject(!_isSuccess);
            Destroy(other.gameObject);
        }

    }
}
