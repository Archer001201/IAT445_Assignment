using System;
using UnityEngine;

namespace A1.A1P2
{
    public class Pipe : MonoBehaviour
    {
        public float moveSpeed;
        public float endPosition;

        private void Update()
        {
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);

            if (transform.position.x < endPosition) gameObject.SetActive(false);
        }
    }
}
