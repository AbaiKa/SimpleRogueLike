using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Attack", menuName = "Scriptable Objects/Object Attack Stats")]
    public class ObjectAttackStats : ScriptableObject
    {
        /// <summary>
        /// The layer on which the enemies
        /// </summary>
        [field: Header("Weapon")]
        [field: SerializeField]
        [field: Tooltip("The layer on which the enemies")]
        public LayerMask TargetLayerMask { get; private set; }

        /// <summary>
        /// The tag of the object to be attacked
        /// </summary>
        [field: SerializeField]
        [field: Tooltip("The tag of the object to be attacked")]
        public string TargetTag { get; private set; }

        /// <summary>
        /// Cooldown in seconds
        /// </summary>
        [field: SerializeField]
        [field: Tooltip("Cooldown in seconds")]
        public float Cooldown { get; private set; } = 1f;

        /// <summary>
        /// Attack radius
        /// </summary>
        [field: SerializeField]
        [field: Tooltip("Attack radius")]
        [field: Range(0, 20)]
        public float Range { get; private set; } = 3f;

        /// <summary>
        /// Bullet Damage
        /// </summary>
        [field: Header("Bullet")]
        [field: SerializeField]
        [field: Tooltip("Bullet Damage")]
        public float Damage { get; private set; }

        /// <summary>
        /// Bullet Speed
        /// </summary>
        [field: SerializeField]
        [field: Tooltip("Bullet Speed")]
        public float BulletSpeed { get; private set; }

        /// <summary>
        /// Bullet LifeTime
        /// </summary>
        [field: SerializeField]
        [field: Tooltip("Bullet LifeTime")]
        public float BulletLifeTime { get; private set; }
    }
}