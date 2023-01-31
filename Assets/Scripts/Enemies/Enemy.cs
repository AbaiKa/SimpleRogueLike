using Components;
using GameManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(HealthComponent))]
    public class Enemy : MonoBehaviour
    {
        public HealthComponent Health { get; private set; }
        private void Awake()
        {
            Health = GetComponent<HealthComponent>();

            Health.onDead += OnDead;
        }

        private void OnDead()
        {
            EnemyManager.Instance.Spawn();
            EnemyManager.Instance.PlusKill();
            Destroy(gameObject);
        }
    }
}