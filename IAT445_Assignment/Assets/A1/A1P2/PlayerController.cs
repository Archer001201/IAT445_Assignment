using System;
using Cinemachine;
using UnityEngine;

namespace A1.A1P2
{
    public class PlayerController : MonoBehaviour
    {
        public float jumpForce = 12f;
        public float maxHeight = 20f;
        public bool isDead;
        
        private Rigidbody2D _rb2d;
        private InputControls _inputControls;
        private CinemachineImpulseSource _impulseSource;

        private void Awake()
        {
            _rb2d = GetComponent<Rigidbody2D>();
            _impulseSource = GetComponent<CinemachineImpulseSource>();
            _inputControls = new InputControls();

            _inputControls.A1P2.Jump.performed += _ => OnJump();
        }

        private void OnEnable()
        {
            _inputControls.Enable();
        }

        private void OnDisable()
        {
            _inputControls.Disable();
        }

        private void Update()
        {
            if (transform.position.y < -maxHeight*2) gameObject.SetActive(false);
            if (!(transform.position.y > maxHeight) && !(transform.position.y < -maxHeight)) return;
            Die();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("CheckPoint"))
            {
                LevelManager.Instance.IncreaseScore(10);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Die();
        }

        private void OnJump()
        {
            if (isDead) return;
            _rb2d.velocity = Vector2.up * jumpForce;
        }

        private void Die()
        {
            if (isDead) return;
            LevelManager.Instance.ActiveGameOverPanel(true);
            isDead = true;
            _impulseSource.GenerateImpulse();
            LevelManager.Instance.RecordScore();
        }
    }
}
