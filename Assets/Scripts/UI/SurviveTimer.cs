using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GameManagement;

namespace UI
{
    public class SurviveTimer : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _txtTimer;
        private void Start()
        {
            GameManager.Instance.OnSurvivedTimeChanged += SurvivedTimeChanged;
        }
        private void SurvivedTimeChanged(int minutes, int seconds)
        {
            _txtTimer.text = $"{minutes:D2}:{seconds:D2}";
        }
    }
}