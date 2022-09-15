using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _health;
        [SerializeField] private EnemyAttack _attack;
        [SerializeField] private EnemyDirectMovement _movement;
        [SerializeField] private EnemyAnimation _animation;

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
            _attack.enabled = false;
            _movement.enabled = false;
            _animation.PlayDeath();
        }
    
    }
}