using ScriptableObjects;
using System;
using UnityEngine;

namespace Components
{
    public class HealthComponent : MonoBehaviour
    {
        /// <summary>
        /// Object health stats
        /// </summary>
        [field: SerializeField]
        [field: Tooltip("Object health stats")]
        public ObjectHealthStats Stats { get; private set; }

        /// <summary>
        /// Object Health
        /// </summary>
        private float _health;

        /// <summary>
        /// Object protection in percent (0,23 == 23% || 1 == 100%)
        /// </summary>
        private float _protection;

        /// <summary>
        /// Event that fires when an object dies
        /// </summary>
        public Action onDead;

        public delegate void HealthComponentHandler(float startHealth, float currentHealth);
        public HealthComponentHandler OnValueChanged;
        private void Awake()
        {
            _health = Stats.Health;
            _protection = Stats.Protection;
        }

        /// <summary>
        /// Deal damage to an object
        /// </summary>
        /// <param name="damage"></param>
        public void Hit(float damage)
        {
            float startDamage = damage;
            float finalDamage = startDamage - (damage * _protection);

            _health -= Mathf.Max(1f, finalDamage);

            OnValueChanged?.Invoke(Stats.Health, _health);

            if (_health <= 0f)
                onDead?.Invoke();
        }
    }
}