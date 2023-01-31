using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Movement", menuName = "Scriptable Objects/Object Movement Stats")]
    public class ObjectMovementStats : ScriptableObject
    {
        /// <summary>
        /// Object Movement Speed
        /// </summary>
        [field: SerializeField, Range(0f, 20f)]
        [field: Tooltip("Object Movement Speed")]
        public float MoveSpeed { get; private set; }

        // TODO: Jump && Rotation speed
    }
}