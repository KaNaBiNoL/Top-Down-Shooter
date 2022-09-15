using System;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyRangeAttack : EnemyAttack
    {
        [SerializeField] private EnemyAnimation _animation;
        [SerializeField] private TriggerObserver _triggerObserver;
        
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _shotPosition;
        [SerializeField] private float _fireDelay = 2f;

        private float _timer;
        private bool _isInRange;
        private Transform _cachedTransform;

        private void Awake()
        {
            _cachedTransform = transform;
        }

        private void Start()
        {
            _triggerObserver.OnEntered += OnEntered;
            _triggerObserver.OnExited += OnExited;
        }

        private void OnEntered(Collider2D obj)
        {
            _isInRange = true;
        }

        private void OnExited(Collider2D obj)
        {
            _isInRange = false;
        }

        private void Update()
        {
            if (CanAttack())
            {
                Attack();
            }

            TickTimer();
        }

        public override void Attack()
        {
            _animation.PlayAttack();
            Instantiate(_bulletPrefab, _shotPosition.position, _cachedTransform.rotation);
            _timer = _fireDelay;
        }

        private bool CanAttack()
        {
            return  _isInRange && _timer <= 0;
        }

        private void TickTimer()
        {
            _timer -= Time.deltaTime;
        }
        
        
    }
}