using System;
using UnityEngine;

namespace _TestObject
{
    /// <summary>
    /// 충돌 뿌려주는 broad caster
    /// observer pattern
    /// </summary>
    public class CollisionCaster : MonoBehaviour
    {
        public event Action<Collider> onTriggerEnter = delegate{};
        public event Action<Collider> onTriggerStay = delegate{};
        public event Action<Collider> onTriggerExit = delegate{};
        public event Action<Collision> onCollisionEnter = delegate{};
        public event Action<Collision> onCollisionStay = delegate{};
        public event Action<Collision> onCollisionExit = delegate{};
        private void OnTriggerEnter(Collider other)
        {
            onTriggerEnter(other);
        }

        private void OnTriggerStay(Collider other)
        {
            onTriggerStay(other);
        }

        private void OnTriggerExit(Collider other)
        {
            onTriggerExit(other);
        }

        private void OnCollisionEnter(Collision other)
        {
            onCollisionEnter(other);
        }

        private void OnCollisionStay(Collision other)
        {
            onCollisionStay(other);
        }

        private void OnCollisionExit(Collision other)
        {
            onCollisionExit(other);
        }
    }
}