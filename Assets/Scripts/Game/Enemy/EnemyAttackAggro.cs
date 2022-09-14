using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAttackAggro : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyAttack _attack;
        [SerializeField] private EnemyFollow _follow;

        private bool _isInRange;

        private void Start()
        {
            _triggerObserver.OnEntered += OnEntered;
            _triggerObserver.OnExited += OnExited;
        }

        private void Update()
        {
            if (_isInRange)
            {
                _attack.Attack();
            }
        }

        private void OnEntered(Collider2D col)
        {
            _isInRange = true;
            _follow.enabled = false;
        }

        private void OnExited(Collider2D col)
        {
            _isInRange = false;
            _follow.enabled = true;
        }
    }
}