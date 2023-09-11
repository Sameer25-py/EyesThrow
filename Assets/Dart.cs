using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Dart : MonoBehaviour
    {
        private bool  _isLaunched = false;
        private float _speed      = 15f;

        private void OnTriggerEnter2D(Collider2D col)
        {
            Stop();
            if (col.gameObject.name == "Eye")
            {
                transform.parent = col.transform;
                GameManager.HitEye?.Invoke();
                Destroy(this);
            }
            else
            {
                GetComponent<Rigidbody2D>()
                    .gravityScale = 1f;
                GameManager.HitDart?.Invoke();
            }
        }

        public void Launch()
        {
            _isLaunched = true;
        }

        public void Stop()
        {
            _isLaunched = false;
        }

        private void FixedUpdate()
        {
            if (!_isLaunched) return;
            transform.position += Vector3.up * (Time.deltaTime * _speed);
        }
    }
}