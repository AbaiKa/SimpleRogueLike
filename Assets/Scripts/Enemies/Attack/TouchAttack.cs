using GameManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies.Attack
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class TouchAttack : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Touch damage")]
        private float _damage = 5;

        private Rigidbody _rigidbody;
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.isKinematic = true;
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag(PlayerManager.Instance.PlayerTag))
            {
                if (PlayerManager.Instance.Player)
                {
                    PlayerManager.Instance.Player.Health.Hit(_damage);
                }
            }
        }
    }
}