using Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManagement
{
    public class EnemyManager : MonoBehaviour
    {
        #region Properties
        public static EnemyManager Instance;

        #region Public
        public int killCounter { get; private set; }
        #endregion

        #region Editor
        [SerializeField]
        [Tooltip("Platform size")]
        private Vector3 _platformSize;

        [SerializeField]
        [Tooltip("Enemies prefab list")]
        private Enemy[] _enemies;

        /// <summary>
        /// Simultaneously active enemies on stage
        /// </summary>
        [SerializeField]
        [Range(0f, 150f)]
        [Tooltip("Simultaneously active enemies on stage")]
        private int _maxActiveEnemies;
        #endregion

        #region Events
        public delegate void OnValueChanged(int value);
        public OnValueChanged onKillChanged;
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
            GameManager.Instance.OnGameStarted += InitEnemies;
        }

        #endregion

        #region Public
        public void Spawn()
        {
            Instantiate(_enemies[Random.Range(0, _enemies.Length)], 
                GetRandomPoint(), Quaternion.identity, transform);
        }

        public void PlusKill()
        {
            killCounter++;
            onKillChanged?.Invoke(killCounter);
        }

        #endregion

        #region Private
        private void InitEnemies()
        {
            killCounter = 0;
            for(int i = 0; i < _maxActiveEnemies; i++)
            {
                Spawn();
            }
        }
        private Vector3 GetRandomPoint()
        {
            int x = (int)(_platformSize.x * 4f);
            int z = (int)(_platformSize.z * 4f);

            Vector3 point = new Vector3(Random.Range(-x, x), 2, Random.Range(-z, z));
            return point;
        }
        #endregion

        #endregion
    }
}