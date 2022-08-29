using System;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _shotPosition;
        [SerializeField] private float _fireDelay = 0.3f;

        private float _timer;
        private Transform _cachedTransform;

        private void Awake()
        {
            _cachedTransform = transform;
        }

        private void Update()
        {
            if (CanAttack())
            {
                Attack();
            }

            TickTimer();
        }

        private void Attack()
        {
            Instantiate(_bulletPrefab, _shotPosition.position, _cachedTransform.rotation);
            _timer = _fireDelay;
        }

        private bool CanAttack()
        {
            return Input.GetButton("Fire1") && _timer <= 0;
        }

        private void TickTimer()
        {
            _timer -= Time.deltaTime;
        }
    }
}