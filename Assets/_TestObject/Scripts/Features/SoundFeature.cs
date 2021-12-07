using UnityEngine;
using System.Collections;

namespace _TestObject
{
    /// <summary>
    /// Defect면 흔들었을 때 엔진 sound play
    /// </summary>
    public class SoundFeature : TestObjectFeature
    {
        private AudioClip audClip;
        [SerializeField] private Rigidbody rb;
        private AudioSource audioSource;
        [SerializeField] private float playSpeedThreshold;
        [SerializeField] private float waitTime = 0.5f;
        private bool defected, isOverPlaySpeed;
        private float speed;

        private void Start() {
            audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (defected) {
                return;
            }
            else {
                speed = rb.velocity.magnitude;
                isOverPlaySpeed = (speed >= playSpeedThreshold) ? true : false;

                if (isOverPlaySpeed && audioSource.isPlaying == false) {
                    StartCoroutine(PlaySound());
                }
            }
        }

        IEnumerator PlaySound() {
            audioSource.Play();
            yield return new WaitForSecondsRealtime(waitTime);
        }

        protected override void OnNormal() {
            defected = false;
        }

        protected override void OnDefect() {
            defected = true;
        }
    }
}