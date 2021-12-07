using System;
using UnityEngine;

namespace _TestObject
{
    /// <summary>
    /// �ڼ��� �ٰ����� ����ǰ�� ��������
    /// </summary>
    public class MagnetFeature : TestObjectFeature
    {
        [SerializeField] private CollisionCaster caster;
        private float distance;
        private bool isDefected => IsDefect;

        private void Awake()
        {
            caster.onTriggerStay += OnMagnetStay;
        }

        private void OnMagnetStay(Collider other)
        {
            if (!isDefected)
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

    }
}