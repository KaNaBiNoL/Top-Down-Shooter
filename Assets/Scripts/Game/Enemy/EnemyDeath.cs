using TDS.Game.Enemy.Base;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _health;
        [SerializeField] private EnemyAttackAggro _attackAggro;
        [SerializeField] private EnemyAttack _attack;
        [SerializeField] private EnemyDirectMovement _movement;
        [SerializeField] private EnemyAnimation _animation;
        [SerializeField] private Collider2D _collider;



        public bool IsDead { get; private set; }

        private void Start()
        {
            _health.OnChanged += OnHpChanged;
        }

        private void OnHpChanged(int health)
        {
            if (IsDead || health > 0)
            {
                return;
            }

            IsDead = true;
            if (_attackAggro != null)
            {
                _attackAggro.enabled = false;
            }

            _attack.enabled = false;
            _movement.enabled = false;
            _collider.enabled = false;
            _animation.PlayDeath();
        }
    
    }
}