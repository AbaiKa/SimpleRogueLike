using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManagement
{
    public class CursorManager : MonoBehaviour
    {
        #region Properties
        public static CursorManager Instance { get; private set; }

        #region Editor
        /// <summary>
        /// Regular texture for cursor
        /// </summary>
        [SerializeField]
        [Tooltip("Regular texture for cursor")]
        private Texture2D regularCursorTexture;
        /// <summary>
        /// Aim texture for cursor
        /// </summary>
        [SerializeField]
        [Tooltip("Aim texture for cursor")]
        private Texture2D aimCursorTexture;
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
            GameManager.Instance.OnGameStarted += () => SetCursor(false);
            GameManager.Instance.OnGameEnding += () => SetCursor(true);
        }
        #endregion

        #region Public
        /// <summary>
        /// Set cursor image
        /// </summary>
        /// <param name="aim"></param>
        public void SetCursor(bool aim)
        {
            Texture2D texture = aim ? aimCursorTexture : regularCursorTexture;
            Vector2 hotspot = new Vector2(texture.width / 2, texture.height / 2);

            Cursor.SetCursor(texture, hotspot, CursorMode.Auto);
        }
        #endregion

        #endregion
    }
}