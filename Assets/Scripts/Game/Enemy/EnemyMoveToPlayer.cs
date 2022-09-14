using System;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyMoveToPlayer : EnemyFollow
    {
        [SerializeField] private EnemyMovement _movement;
        [SerializeField] private TriggerObserver _triggerObserver;
        
        private Transform _playerTransform;

        

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerHealth>().transform;
            _triggerObserver.OnEntered += OnEntered;
            _triggerObserver.OnExited += OnExited;
        }

        private void OnEntered(Collider2D col)
        {
            SetTarget(_playerTransform);
        }

        private void OnExited(Collider2D other)
        {
            SetTarget(null);
        }

        private void SetTarget(Transform target)
        {
            _movement.SetTarger(target);
        }
    }
}