using System;
using TDS.Game.Enemy.Base;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyMeleeAttack : EnemyAttack
    {
        [SerializeField] private int _damage = 20;
        [SerializeField] private float _attackDelay;
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private EnemyAnimation _animation;
        

        private float _delayTimer;

        private void Update()
        {
            TickTimer();
        }

        public override void Attack()
        {
            if (CanAttack())
            {
                AttackInternal();
            }
        }

        public void PerformDamage()
        {
            Collider2D col = Physics2D.OverlapCircle(_attackPoint.position, _radius, _layerMask);
            if (col == null)
            {
                return;
            }

            if (col.TryGetComponent(out PlayerHealth playerHealth))
            {
                playerHealth.ApplyDamage(_damage);
            }
        }

        private void TickTimer()
        {
            _delayTimer -= Time.deltaTime;
        }

        private void AttackInternal()
        {
            _animation.PlayAttack();
            _delayTimer = _attackDelay;
            
        }

        private bool CanAttack() => 
            _delayTimer <= 0;
        
    }
}