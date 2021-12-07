using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;

namespace _TestObject
{
    /// <summary>
    /// Defect면 잡아서 흔들었을 때 엔진 sound play
    /// </summary>
    public class SoundFeature : TestObjectFeature
    {
        [SerializeField] private CarState carState;
        private AudioClip audClip;
        [SerializeField] private Rigidbody rb;
        private AudioSource audioSource;
        [SerializeField] private float playSpeedThreshold = 7.0f;
        [SerializeField] private float playAgainWaitTime = 0.5f;
        [SerializeField] private float heldTimeThreshold = 0.4f;
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

                if (isOverPlaySpeed && audioSource.isPlaying == false && carState.heldtime > heldTimeThreshold) {
                    StartCoroutine(PlaySound());
                }
            }
        }

        IEnumerator PlaySound() {
            audioSource.Play();
            yield return new WaitForSecondsRealtime(playAgainWaitTime);
        }

        protected override void OnNormal() {
            defected = false;
        }

        protected override void OnDefect() {
            defected = true;
        }
    }
}