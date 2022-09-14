using System;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyMoveToPlayer : EnemyFollow
    {
        [SerializeField] private EnemyMovement _movement;

        private Transform _playerTransform;

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerHealth>().transform;
        }

        public override void Activate()
        {
            base.Activate();
            SetTarget(_playerTransform);
        }

        public override void DeActivate()
        {
            base.DeActivate();
            SetTarget(null);
        }

        private void SetTarget(Transform target)
        {
            _movement.SetTarget(target);
        }
    }
}