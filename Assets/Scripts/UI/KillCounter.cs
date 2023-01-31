using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GameManagement;

namespace UI
{
    public class KillCounter : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI txtKillCounter;
        private void Start()
        {
            EnemyManager.Instance.onKillChanged += UpdateText;
        }
        private void UpdateText(int count)
        {
            txtKillCounter.text = count.ToString();
        }
    }
}
