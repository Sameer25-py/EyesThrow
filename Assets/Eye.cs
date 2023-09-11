using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class Eye : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 250f;
        public                   bool  IsGameStarted = false;

        [SerializeField] private Vector3 _rotateDirection = Vector3.forward;

        private void ChangeDirection()
        {
            if (_rotateDirection == Vector3.forward)
            {
                _rotateDirection = Vector3.back;
            }
            else
            {
                _rotateDirection = Vector3.forward;
            }
        }

        private void IncreaseSpeed()
        {
            rotationSpeed += 25f;
        }

        public void StartRotate()
        {
            IsGameStarted = true;
            InvokeRepeating(nameof(ChangeDirection), 2f, 2f);
            InvokeRepeating(nameof(IncreaseSpeed), 10f, 10f);
        }


        public void StopRotate()
        {
            IsGameStarted = false;
            CancelInvoke(nameof(ChangeDirection));
            CancelInvoke(nameof(IncreaseSpeed));
        }

        public void ResetRotate()
        {
            IsGameStarted = false;
            rotationSpeed = 250f;
            CancelInvoke(nameof(ChangeDirection));
            CancelInvoke(nameof(IncreaseSpeed));
            transform.rotation = Quaternion.identity;
        }

        private void FixedUpdate()
        {
            if (!IsGameStarted) return;
            transform.Rotate(_rotateDirection * (rotationSpeed * Time.deltaTime));
        }
    }
}