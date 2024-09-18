using System;
using Cinemachine;
using UnityEngine;

namespace A1.A1P2
{
    public class CameraController : MonoBehaviour
    {
        private CinemachineVirtualCamera _virtualCamera;
        private void Awake()
        {
            _virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
            _virtualCamera.Follow = GameObject.FindWithTag("CameraTarget").transform;
        }
    }
}
