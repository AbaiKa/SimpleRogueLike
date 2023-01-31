using PlayerCharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManagement
{
    public class PlayerManager : MonoBehaviour
    {
        #region Properties
        public static PlayerManager Instance;

        #region Public
        public Player Player { get; private set; }

        [field: SerializeField]
        [field: Tooltip("Player tag")]
        public string PlayerTag { get; private set; }
        #endregion

        #region Editor
        [SerializeField]
        [Tooltip("Player prefab")]
        private Player _playerPrefab;
        #endregion

        #region Events

        public delegate void PlayerDelegate(Player player);
        public PlayerDelegate OnPlayerSpawn;

        #endregion

        #endregion

        #region Methods

        #region Unity
        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            GameManager.Instance.OnGameStarted += Init;
        }
        #endregion


        #region Private
        private void Init()
        {
            Player = Instantiate(_playerPrefab, Vector3.one, Quaternion.identity);
            OnPlayerSpawn?.Invoke(Player);
        }
        #endregion
        #endregion
    }
}
