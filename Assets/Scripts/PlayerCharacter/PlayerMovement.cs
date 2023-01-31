using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerCharacter
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        #region Properties
        /// <summary>
        /// Object Movement stats
        /// </summary>
        [field: SerializeField]
        [field: Tooltip("Object Movement stats")]
        public ObjectMovementStats Stats { get; private set; }

        #region Private
        /// <summary>
        /// Player physics
        /// </summary>
        private Rigidbody _rigidbody;
        /// <summary>
        /// Player movement speed
        /// </summary>
        private float _moveSpeed = 8;
        #endregion

        #endregion

        #region Methods

        #region Unity
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();

            _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

            _moveSpeed = Stats.MoveSpeed;
        }
        private void FixedUpdate()
        {
            if (_rigidbody == null) return;

            Movement();
            Rotation();
        }
        #endregion

        #region Private
        /// <summary>
        /// Player movement
        /// </summary>
        private void Movement()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (horizontal != 0 || vertical != 0)
                _rigidbody.velocity = new Vector3(horizontal * _moveSpeed, _rigidbody.velocity.y, vertical * _moveSpeed);
            else
                _rigidbody.velocity = Vector3.zero;
        }

        /// <summary>
        /// Player rotation
        /// </summary>
        private void Rotation()
        {
            Ray point = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if (groundPlane.Raycast(point, out rayLength))
            {
                Vector3 pointToLook = point.GetPoint(rayLength);

                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }
        }
        #endregion

        #endregion
    }
}