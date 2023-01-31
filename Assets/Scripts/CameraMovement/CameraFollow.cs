using GameManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraMovement
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _offset;

        private void LateUpdate()
        {
            if (TargetExist() != true)
                return;

            transform.position = PlayerManager.Instance.Player.Position + _offset;
        }

        private bool TargetExist()
        {
            return PlayerManager.Instance && PlayerManager.Instance.Player;
        }
    }
}