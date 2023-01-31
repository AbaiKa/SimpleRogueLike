using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

namespace Enemies.Attack
{
    public class WeaponAttack : MonoBehaviour
    {
        public Vector3 Position => transform.position;
        /// <summary>
        /// The weapon from which the object will be fired
        /// </summary>
        [SerializeField]
        [Tooltip("The weapon from which the object will be fired")]
        private BaseWeapon _weapon;

        /// <summary>
        /// Target currently being tracked
        /// </summary>
        private Collider _currentTarget;

        private void Update()
        {
            if (_weapon.IsAttacking == false)
            {
                SearchTarget();

                if (_currentTarget == null)
                    return;

                //Vector3 dir = (_currentTarget.transform.position - Position).normalized;
                _weapon.Attack();
            }
        }

        private void SearchTarget()
        {
            Collider[] targets = Physics.OverlapSphere(Position, _weapon.Stats.Range, _weapon.Stats.TargetLayerMask.value);

            if (targets.Length > 0)
                _currentTarget = targets[Random.Range(0, targets.Length)];
            else
                _currentTarget = null;
        }
    }
}