using System;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Health", menuName = "Scriptable Objects/Object Health Stats")]
    public class ObjectHealthStats : ScriptableObject
    {
        /// <summary>
        /// Object Health
        /// </summary>
        [field: SerializeField, Range(0f, 100f)]
        [field: Tooltip("Object Health")]
        public float Health { get; private set; }

        /// <summary>
        /// Object protection in percent (0,23 == 23% || 1 == 100%)
        /// </summary>
        [field: SerializeField, Range(0f, 1f)]
        [field: Tooltip("Object protection in percent (0,23 == 23% || 1 == 100%)")]
        public float Protection { get; private set; }

        private void OnValidate()
        {
            Protection = (float)Math.Round(Protection, 2);
        }
    }
}