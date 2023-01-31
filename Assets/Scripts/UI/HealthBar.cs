using Components;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Health bar 'value image'")]
        private Image _healthBar;

        [SerializeField]
        [Tooltip("Object Health Component")]
        private HealthComponent _health;
        private void Awake()
        {
            if (_health != null)
                _health.OnValueChanged += UpdateHealthBar;
        }
        private void Update()
        {
            transform.rotation = Quaternion.identity;
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