using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAttackAggro : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyAttack _attack;
        [SerializeField] private EnemyFollow _follow;

        private void Start()
        {
            _triggerObserver.OnEntered += OnEntered;
            _triggerObserver.OnExited += OnExited;
        }

        private void OnEntered(Collider2D col)
        {
            _follow.DeActivate();
            _attack.Activate();
        }

        private void OnExited(Collider2D col)
        {
            _attack.DeActivate();
            _follow.Activate();
        }
    }
}