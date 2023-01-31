using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public abstract class BaseWeapon : MonoBehaviour
    {
        #region Properties
        /// <summary>
        /// Object Attack Stats
        /// </summary>
        [field: SerializeField]
        [field: Tooltip("Object Attack Stats")]
        public ObjectAttackStats Stats { get; private set; }
        public Vector3 Position => transform.position;
        public bool IsAttacking { get; private set; } = false;

        [HideInInspector]
        public float currentCooldown;

        protected Collider[] ignoreColliders;

        #endregion

        #region Methods
        private void Awake()
        {
            ignoreColliders = GetComponentsInParent<Collider>();
        }

        #region Abstract
        protected abstract void DoAttack();

        #endregion

        #region Protected
        public void Attack()
        {
            DoAttack();
            currentCooldown = Stats.Cooldown;
            IsAttacking = true;
        }

        private void Update()
        {
            if (currentCooldown > 0)
            {
                currentCooldown -= Time.deltaTime;
            }
            else
            {
                IsAttacking = false;
            }
        }
        #endregion

        #region Helpers
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(Position, Stats.Range);
        }
        #endregion
        #endregion
    }
}