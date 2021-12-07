using System;
using UnityEngine;

namespace _TestObject
{
    /// <summary>
    /// 자석이 다가오면 결함품은 끌어당겨짐
    /// </summary>
    public class MagnetFeature : TestObjectFeature
    {
        [SerializeField] private CollisionCaster caster;
        private float distance;
        private bool defected;

        private void Start()
        {
            caster.onTriggerStay += OnMagnetStay;
        }

        private void OnMagnetStay(Collider other)
        {

            if (!defected)
                return;

            if (other.gameObject.tag == "Magnet")
            {
                Vector3 offset = other.transform.position - transform.parent.parent.position;
                distance = offset.sqrMagnitude;
                if (distance < 2f)
                {
                    distance = 2f;
                }
                transform.parent.parent.position += offset.normalized * Time.deltaTime / distance;
            }
        }



        protected override void OnNormal()
        {
            defected = false;
        }

        protected override void OnDefect()
        {
            Debug.Log("magnet");
            defected = true;
        }

    }
}