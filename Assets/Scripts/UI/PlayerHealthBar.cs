using GameManagement;
using PlayerCharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerHealthBar : MonoBehaviour
    {
        [SerializeField]
        private Image _healthBar;

        private void Start()
        {
            PlayerManager.Instance.OnPlayerSpawn += SetEvents;
        }
        private void SetEvents(Player player)
        {
            player.Health.OnValueChanged += UpdateHealthBar;
        }
        private void UpdateHealthBar(float startHealth, float currentHealth)
        {
            float onePercent = startHealth / 100;
            float progress = currentHealth / onePercent;
            float result = progress / 100;

            _healthBar.fillAmount = result;
        }
    }
}