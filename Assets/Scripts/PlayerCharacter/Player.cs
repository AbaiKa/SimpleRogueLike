using Components;
using GameManagement;
using UnityEngine;

namespace PlayerCharacter
{
    [RequireComponent(typeof(PlayerMovement), typeof(HealthComponent))]
    public class Player : MonoBehaviour
    {
        public static Player Instance { get; private set; }

        public PlayerMovement Movement { get; private set; }
        public HealthComponent Health { get; private set; }

        public Vector3 Position => transform.position;


        private void Awake()
        {
            Instance = this;

            Movement = GetComponent<PlayerMovement>();
            Health = GetComponent<HealthComponent>();
        }

        private void Start()
        {
            Health.onDead += GameOver;
        }

        private void GameOver()
        {
            GameManager.Instance.GameOver();

            Destroy(gameObject);
        }
    }
}