using Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons.Bullets
{
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class GunBullet : MonoBehaviour
    {
        private float _damage;
        private float _speed;
        private string _targetTag;

        private Collider _collider;
        private Rigidbody _rigidbody;

        private Collider[] _ignoreColliders;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
            _rigidbody = GetComponent<Rigidbody>();

            _collider.isTrigger = true;
            _rigidbody.useGravity = false;
            _rigidbody.isKinematic = true;
        }
        public void Init(Collider[] ignoreColliders, float damage, float speed, float lifeTime, string targetTag)
        {
            _damage = damage;
            _speed = speed;
            _targetTag = targetTag;

            _ignoreColliders = ignoreColliders;

            Invoke(nameof(Release), lifeTime);
        }
        private void Update()
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
        private void OnTriggerEnter(Collider other)
        {
            for (int i = 0; i < _ignoreColliders.Length; i++)
                if (_ignoreColliders[i] == other)
                    return;

            if (other.CompareTag(_targetTag))
            {
                other.TryGetComponent(out HealthComponent health);

                if (health != null)
                {
                    health.Hit(_damage);
                }
                else
                {
                    Debug.Log("Enemy is invulnerable or has no 'HealthComponent'");
                }
            }


            Release();
        }

        private void Release()
        {
            //TODO: Pool objects
            CancelInvoke(nameof(Release));
            Destroy(gameObject);
        }
    }
}