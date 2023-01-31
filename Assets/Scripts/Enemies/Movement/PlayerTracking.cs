using GameManagement;
using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies.Movement
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerTracking : MonoBehaviour
    {
        #region Properties

        #region Public
        public NavMeshAgent Agent { get; protected set; }
        public Vector3 Position => transform.position;
        #endregion

        #region Private
        /// <summary>
        /// Distance to the player when the enemy is at the target
        /// </summary>
        [SerializeField]
        [Tooltip("Distance to the player when the enemy is at the target")]
        private float playerReachedDistance = 0f;
        /// <summary>
        /// Distance to the player for pursuit. Specify 0 if you want to follow from anywhere
        /// </summary>
        [SerializeField]
        [Tooltip("Distance to the player for pursuit. Set 0 if you want to follow from anywhere")]
        private float playerIsNearby = 5;

        /// <summary>
        /// Object Movement stats
        /// </summary>
        [field: SerializeField]
        [field: Tooltip("Object Movement stats")]
        public ObjectMovementStats Stats { get; private set; }
        #endregion

        #endregion

        #region Methods

        #region Unity
        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            Agent.speed = Stats.MoveSpeed;
            Agent.stoppingDistance = playerReachedDistance;
        }

        private void Update()
        {
            if (PlayerExists() && PlayerIsNearby())
            {
                MovesTowardsThePlayer();
            }
        }
        #endregion

        #region Private
        /// <summary>
        /// Moves towards Player
        /// </summary>
        private void MovesTowardsThePlayer()
        {
            Agent.SetDestination(PlayerManager.Instance.Player.Position);
            RotationToThePlayer();
        }
        /// <summary>
        /// Rotation object to the player
        /// </summary>
        private void RotationToThePlayer()
        {
            Vector3 player = PlayerManager.Instance.Player.Position;

            transform.LookAt(new Vector3(player.x, Position.y, player.z));
        }
        /// <summary>
        /// Returns true if the player still exists
        /// </summary>
        /// <returns></returns>
        private bool PlayerExists()
        {
            return PlayerManager.Instance && PlayerManager.Instance.Player;
        }

        /// <summary>
        /// Returns true if the player is nearby
        /// </summary>
        /// <returns></returns>
        private bool PlayerIsNearby()
        {
            if (playerIsNearby == 0 || Vector3.Distance(PlayerManager.Instance.Player.Position, Position) < playerIsNearby)
            {
                return true;
            }

            return false;
        }
        #endregion

        #endregion
    }
}