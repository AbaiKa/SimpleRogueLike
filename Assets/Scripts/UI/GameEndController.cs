using GameManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class GameEndController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _background;

        [SerializeField]
        private Button _btnRestart;
        private void Start()
        {
            GameManager.Instance.OnGameEnding += Show;

            _btnRestart.onClick.AddListener(Restart);
            _background.SetActive(false);
        }

        private void Show()
        {
            _background.SetActive(true);
        }

        private void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
