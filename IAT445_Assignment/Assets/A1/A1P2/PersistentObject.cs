using System;
using UnityEngine;

namespace A1.A1P2
{
    public class PersistentObject : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
